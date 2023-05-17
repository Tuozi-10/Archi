using System;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using Observer;
using Service;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace FactoryWarcraft
{
    public enum TypeOfEntity
    {
        Peon,
        PeonMiner,
        PeonBlacksmith
    }
    
    public struct RessourceData
    {
        public int nbRemaining;
        public Vector3 pos;
        public GameObject go;
        
       public RessourceData(int nb, Vector3 _pos, GameObject _go = null)
        {
            nbRemaining = nb;
            pos = _pos;
            go = _go;
        }
    }

    public class WarcraftService : IGameService
    {
        [DependsOnService] private IUIService m_UIService;
        [DependsOnService] private IEntityFactoryService m_entityFactoryService;

        private Queue<GameObject> pool = new Queue<GameObject>();
        private UI_Warcraft UI = null;
        private bool BtnSet = false;
        private RessourceData TreePos;
        private RessourceData RockPos =  new (1000, new Vector3(35, 0, 15));
        private RessourceData ForgePos =  new (50, new Vector3(16, 0, -35));
        private GameObject PeonPrefab = null;
        private RessourceManager m_ressourceManager = null;
        private MeshFactory m_meshFactory = null;
        private List<Entity> m_waitingLumber = new ();

        [ServiceInit]
        private void InitService()
        {
            m_ressourceManager = new RessourceManager();
            BtnSet = false;

            m_UIService.ShowUIMainMenu();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Minion", GeneratePeon);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Lumber", GenerateTree);

            EventManager.AddListener<TypeOfEntity>(CheckEntityToSpawn);

            OnUpdate();
        }

        public void Switch(){}

        public void Enable(){}

        public void Disable(){}


        private void CheckRessource(Entity entity)
        {
            entity.OnReceiveInfo?.Invoke(m_ressourceManager.EnoughToTool());
        }

        private void GeneratePeon(GameObject obj)
        {
            m_meshFactory = new MeshFactory(obj);
        }
        
        private void GenerateTree(GameObject obj)
        {
            Vector3 pos = new Vector3(-42, -0.5f, -12);
           GameObject newTree = Object.Instantiate(obj, pos, Quaternion.identity);
           pos.y = 0;
           TreePos = new RessourceData(50, pos, newTree);
        }

        private void CheckEntityToSpawn(TypeOfEntity data)
        {
            switch (data)
            {
                case TypeOfEntity.Peon:
                    GenerateMinion();
                    break;
                case TypeOfEntity.PeonMiner:
                    GenerateMinionMiner();
                    break;
                case TypeOfEntity.PeonBlacksmith:
                    GenerateMinionBlackSmith();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(data), data, null);
            }
        }
        
        private async void ReplantTree(Entity entity)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(10));
            TreePos.go.SetActive(true);
            TreePos.nbRemaining = 50;
            entity.SetRessourceData(TreePos);
        }

        private void GenerateMinion()
        {
            GameObject newMinion = m_meshFactory.GenerateMinion();

            Entity MyEntity = m_entityFactoryService.CreateLumberjack(newMinion.transform, TreePos);
            MyEntity.OnGainRessource += m_ressourceManager.AddWood;
            
            MyEntity.OnNoRessource += ReplantTree;

            m_entityFactoryService.SetEntityToMesh(newMinion, MyEntity, ForgePos);
        }

        private void GenerateMinionMiner()
        {
            GameObject newMinion = m_meshFactory.GenerateMinion();

            Entity MyEntity = m_entityFactoryService.CreateLumberjack(newMinion.transform, RockPos);
            MyEntity.OnGainRessource += m_ressourceManager.AddRock;
            m_entityFactoryService.SetEntityToMesh(newMinion, MyEntity, ForgePos);
        }

        private void GenerateMinionBlackSmith()
        {
            GameObject newMinion = m_meshFactory.GenerateMinion();

            Entity MyEntity = m_entityFactoryService.CreateBlackSmith(newMinion.transform, ForgePos);
            MyEntity.OnGainRessource += m_ressourceManager.AddTool;
            MyEntity.OnCreateTool += m_ressourceManager.GetRessourceToTool;
            MyEntity.OnIdle += CheckRessource;

            m_entityFactoryService.SetEntityToMesh(newMinion, MyEntity, ForgePos);
        }

        private void OnCreateLumber()
        {
            EventManager.Trigger(TypeOfEntity.Peon);
        }

        private void OnCreatePeonMiner()
        {
            EventManager.Trigger(TypeOfEntity.PeonMiner);
        }

        private void OnCreatePeonBlackSmith()
        {
            EventManager.Trigger(TypeOfEntity.PeonBlacksmith);
        }

        private async void OnUpdate()
        {
            while (true)
            {
                await UniTask.DelayFrame(0);
                
                if (UI) continue;
                UI = ((WarcraftHUD)m_UIService).GetTextManager();
                if (!UI) continue;
                UI.btnPeon.onClick.AddListener(OnCreateLumber);
                UI.btnPeonMiner.onClick.AddListener(OnCreatePeonMiner);
                UI.btnPeonBlacksmith.onClick.AddListener(OnCreatePeonBlackSmith);
                BtnSet = true;
                
                m_ressourceManager.OnLumberUpdate += UI.PrintLumber;
                m_ressourceManager.OnRockUpdate += UI.PrintGold;
                m_ressourceManager.OnToolUpdate += UI.PrintTool;
            }
        }
    }
}