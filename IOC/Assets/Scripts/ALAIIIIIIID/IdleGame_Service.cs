using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using Service;
using UnityEngine;

namespace ALAIIIIIIID
{
    public class IdleGame_Service : IGameService
    {
        private int lumber = 0;
        private int rock = 0;
        private int tool = 0;
        [DependsOnService] private IUIService UIService;
        [DependsOnService] private IEntityFactoryService entityFactoryService;

        private GameObject newMinion = null;
        private Vector3 TreePos;
        private Vector3 RockPos;
        private Vector3 ForgePos;
        private GameObject MinionPrefab = null;
        
        [ServiceInit]
        public void InitService()
        {
            lumber = 0;
            rock = 0;
            tool = 0;

            TreePos = GameObject.Find("Lumbers").transform.position;
            RockPos = GameObject.Find("Rock").transform.position;
            ForgePos = GameObject.Find("Forge").transform.position;
            UIService.ShowUIMainMenu();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Minion", GenerateMinion);
        }

        private void AddWood(int nb)
        {
            lumber += nb;
        }
        
        private void AddRock(int nb)
        {
            rock += nb;
        }
        
        private void AddTool(int nb)
        {
            tool += nb;
        }

        private void GetRessourceToTool()
        {
            lumber -= 5;
            rock -= 5;
        }

        private void CheckRessource(Entity entity)
        {
            entity.OnReceiveInfo?.Invoke((lumber >= 20 && rock >= 20));
        }

        private void GenerateMinion(GameObject obj)
        {
            MinionPrefab = obj;
            if (MinionPrefab != null) Debug.Log("Minion generated");
            for (int i = 0; i < 10; i++)
            {
                MakeMinecraft();
                MakeLumberJack();
                MakeDavidLaforge();
            }
        }

        private void GenerateLumberJack(GameObject obj)
        {
            newMinion = Object.Instantiate(obj);
            newMinion.transform.position = Vector3.zero;

            Entity MyEntity = entityFactoryService.CreateLumberjack(newMinion.transform, TreePos);
            MyEntity.OnGainRessource += AddWood;
            
            newMinion.GetComponent<MinionScript>().SetComposite(MyEntity);

            MoveToTargetComponent MtC = MyEntity.myGetComponent<MoveToTargetComponent>();
            if (MtC != null)
            {
                MtC.Init(TreePos, newMinion.transform);
            }
        }
        
        private void GenerateMinecraft(GameObject obj)
        {
            newMinion = Object.Instantiate(obj);
            newMinion.transform.position = Vector3.zero;

            Entity MyEntity = entityFactoryService.CreateLumberjack(newMinion.transform, RockPos);
            MyEntity.OnGainRessource += AddRock;
            
            newMinion.GetComponent<MinionScript>().SetComposite(MyEntity);

            MoveToTargetComponent MtC = MyEntity.myGetComponent<MoveToTargetComponent>();
            if (MtC != null)
            {
                MtC.Init(RockPos, newMinion.transform);
            }
        }
        
        private void GenerateBlackSmith(GameObject obj)
        {
            newMinion = Object.Instantiate(obj);
            newMinion.transform.position = Vector3.zero;

            Entity MyEntity = entityFactoryService.CreateBlackSmith(newMinion.transform, ForgePos);
            MyEntity.OnGainRessource += AddTool;
            MyEntity.OnCreateTool += GetRessourceToTool;
            MyEntity.OnIdle += CheckRessource;
            
            newMinion.GetComponent<MinionScript>().SetComposite(MyEntity);

            MoveToTargetComponent moveComponent = MyEntity.myGetComponent<MoveToTargetComponent>();
            if (moveComponent != null)
            {
                moveComponent.Init(ForgePos, newMinion.transform);
            }
        }

        public void MakeLumberJack()
        {
            GenerateLumberJack(MinionPrefab);
        }
        
        public void MakeMinecraft()
        {
            GenerateMinecraft(MinionPrefab);
        }
        
        public void MakeDavidLaforge()
        {
            GenerateBlackSmith(MinionPrefab);
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