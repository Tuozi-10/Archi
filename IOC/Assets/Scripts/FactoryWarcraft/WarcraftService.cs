using System;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using Observer;
using Service;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FactoryWarcraft
{
    public enum TypeOfEntity
    {
        Peon,
        PeonMiner,
        PeonBlacksmith
    }
    
    public class WarcraftService : IGameService
    {
        [DependsOnService] private IUIService m_UIService;
        [DependsOnService] private IEntityFactoryService m_entityFactoryService;

        private Queue<GameObject> pool = new Queue<GameObject>();
        private UI_Warcraft UI = null;
        private bool BtnSet = false;
        private Vector3 TreePos = new Vector3(-42, -2, -12);
        private Vector3 RockPos = new Vector3(35, -2, 15);
        private Vector3 ForgePos = new Vector3(16, -2, -35);
        private GameObject PeonPrefab = null;
        private RessourceManager m_ressourceManager = null;
        private MeshFactory m_meshFactory = null;

        [ServiceInit]
        private void InitService()
        {
            m_ressourceManager = new RessourceManager();
            BtnSet = false;

            m_UIService.ShowUIMainMenu();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Minion", GeneratePeon);
            
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
            m_meshFactory = new MeshFactory(PeonPrefab);
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

        private void GenerateMinion()
        {
            GameObject newMinion =  m_meshFactory.GenerateMinion();

            Entity MyEntity = m_entityFactoryService.CreateLumberjack(newMinion.transform, TreePos);
            MyEntity.OnGainRessource += m_ressourceManager.AddWood;
            
            m_entityFactoryService.SetEntityToMesh(newMinion, MyEntity, ForgePos); 
        }
        
        private void GenerateMinionMiner()
        {
            GameObject newMinion =  m_meshFactory.GenerateMinion();

            Entity MyEntity = m_entityFactoryService.CreateLumberjack(newMinion.transform, RockPos);
            MyEntity.OnGainRessource += m_ressourceManager.AddRock;
            
            m_entityFactoryService.SetEntityToMesh(newMinion, MyEntity, ForgePos);
        }
        
        private void GenerateMinionBlackSmith()
        {
            GameObject newMinion =  m_meshFactory.GenerateMinion();
            Entity MyEntity = m_entityFactoryService.CreateBlackSmith(newMinion.transform, ForgePos);
            MyEntity.OnGainRessource += m_ressourceManager.AddTool;
            MyEntity.OnCreateTool += m_ressourceManager.GetRessourceToTool;
            MyEntity.OnIdle += CheckRessource;

            m_entityFactoryService.SetEntityToMesh(newMinion, MyEntity, ForgePos); 

        }

        private void OnCreateLumber()
        {
            EventManager.Trigger(TypeOfEntity.Peon);
            //GenerateMinion(PeonPrefab);
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
                if (!UI)
                {
                    UI = ((WarcraftHUD)m_UIService).GetTextManager();
                    if (UI)
                    {
                        UI.btnPeon.onClick.AddListener(OnCreateLumber);
                        UI.btnPeonMiner.onClick.AddListener(OnCreatePeonMiner);
                        UI.btnPeonBlacksmith.onClick.AddListener(OnCreatePeonBlackSmith);
                        BtnSet = true;
                    }
                }
            }
        }
    }
}