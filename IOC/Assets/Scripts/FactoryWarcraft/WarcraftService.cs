using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using Service;
using UnityEngine;

namespace FactoryWarcraft
{
    public class WarcraftService : IGameService
    {
        private int m_lumber = 0;
        private int m_rock = 0;
        private int m_tool = 0;
        [DependsOnService] private IUIService m_UIService;
        [DependsOnService] private IEntityFactoryService m_entityFactoryService;

        private GameObject newMinion = null;
        private Queue<GameObject> pool = new Queue<GameObject>();
        private UI_Warcraft UI = null;
        private bool BtnSet = false;
        private Vector3 TreePos = new Vector3(-42, -2, -12);
        private Vector3 RockPos = new Vector3(35, -2, 15);
        private Vector3 ForgePos = new Vector3(16, -2, -35);
        private GameObject PeonPrefab = null;

        [ServiceInit]
        private void InitService()
        {
            m_lumber = 0;
            m_rock = 0;
            m_tool = 0;
            BtnSet = false;

            m_UIService.ShowUIMainMenu();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Minion", GeneratePeon);

            OnUpdate();
        }

        private void AddWood(int nb)
        {
            m_lumber += nb;
        }
        
        private void AddRock(int nb)
        {
            m_rock += nb;
        }
        
        private void AddTool(int nb)
        {
            m_tool += nb;
        }

        private void GetRessourceToTool()
        {
            m_lumber -= 20;
            m_rock -= 20;
        }

        private void CheckRessource(Entity entity)
        {
            entity.OnReceiveInfo?.Invoke((m_lumber >= 20 && m_rock >= 20));
        }

        private void GeneratePeon(GameObject obj)
        {
            PeonPrefab = obj;
        }

        private void GenerateMinion(GameObject obj)
        {
            newMinion = Object.Instantiate(obj);
            newMinion.transform.position = Vector3.zero;

            Entity MyEntity = m_entityFactoryService.CreateLumberjack(newMinion.transform, TreePos);
            MyEntity.OnGainRessource += AddWood;
            
            newMinion.GetComponent<Peon>().SetComposite(MyEntity);

            MoveToTargetComponent MtC = MyEntity.myGetComponent<MoveToTargetComponent>();
            if (MtC != null)
            {
                MtC.Init(TreePos, newMinion.transform);
            }
        }
        
        private void GenerateMinionMiner(GameObject obj)
        {
            newMinion = Object.Instantiate(obj);
            newMinion.transform.position = Vector3.zero;

            Entity MyEntity = m_entityFactoryService.CreateLumberjack(newMinion.transform, RockPos);
            MyEntity.OnGainRessource += AddRock;
            
            newMinion.GetComponent<Peon>().SetComposite(MyEntity);

            MoveToTargetComponent MtC = MyEntity.myGetComponent<MoveToTargetComponent>();
            if (MtC != null)
            {
                MtC.Init(RockPos, newMinion.transform);
            }
        }
        
        private void GenerateMinionBlackSmith(GameObject obj)
        {
            newMinion = Object.Instantiate(obj);
            newMinion.transform.position = Vector3.zero;

            Entity MyEntity = m_entityFactoryService.CreateBlackSmith(newMinion.transform, ForgePos);
            MyEntity.OnGainRessource += AddTool;
            MyEntity.OnCreateTool += GetRessourceToTool;
            MyEntity.OnIdle += CheckRessource;
            
            newMinion.GetComponent<Peon>().SetComposite(MyEntity);

            MoveToTargetComponent MtC = MyEntity.myGetComponent<MoveToTargetComponent>();
            if (MtC != null)
            {
                MtC.Init(ForgePos, newMinion.transform);
            }
        }

        private void OnCreateLumber()
        {
            GenerateMinion(PeonPrefab);
        }
        
        private void OnCreatePeonMiner()
        {
            GenerateMinionMiner(PeonPrefab);
        }
        
        private void OnCreatePeonBlackSmith()
        {
            GenerateMinionBlackSmith(PeonPrefab);
        }

        private async void OnUpdate()
        {
            while (true)
            {
                await UniTask.DelayFrame(0);
                if (UI != null)
                {
                    UI.SetLumber(m_lumber);
                    UI.SetGold(m_rock);
                    UI.SetTool(m_tool);
                }
                else
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

        public void Switch()
        {
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}