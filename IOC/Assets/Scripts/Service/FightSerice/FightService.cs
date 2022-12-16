using System;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Service.TickService;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Service.FightSerice
{
    public class FightService : IFightService
    {
        [DependsOnService] 
        private ITickService m_tickService;

        private List<GameObject> gameObjectDependency;
        private bool enable = true;
        
        [ServiceInit]
        void Initialize()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("EnemySpawner", GenerateSpawner);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Player", GeneratePlayer);
            m_tickService.OnUpdate += OnFightUpdate;
        }

        void OnFightUpdate()
        {
            OnFightAction?.Invoke();
        }

        void GenerateSpawner(GameObject obj)
        {
            var spawner = Object.Instantiate(obj);
            var spawnerScript = spawner.GetComponent<EnemySpawner>();
            spawnerScript.Setup(this, m_tickService);
        }

        void GeneratePlayer(GameObject obj)
        {
            var player = Object.Instantiate(obj);
            var playerScript = player.GetComponent<Player>();
            playerScript.Setup(this);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<PlayerStatSO>("MainPlayerSO", playerScript.InitSO);
        }

        public void SetServiceState(bool state)
        {
            Debug.Log("Set fightService to " + state);
            state = enable;
            for (int i = 0; i < gameObjectDependency.Count; i++)
            {
                gameObjectDependency[i].SetActive(state);
            }
        }

        public void SwitchServiceState()
        {
            SetServiceState(!enable);
        }

        public Action OnFightAction { get; set; }
        
    }
}