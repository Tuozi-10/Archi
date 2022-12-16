using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using UnityEngine;

namespace Service
{
    public class FightService : IFightService
    {
        private float timer;
        private float time = 2;
        private FightServiceSO so;
        private GameObject burger;
        [ServiceInit]
        private void SetupFight()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<FightServiceSO>("BurgerFighterSO", SetupBurgerFighterSo);
        }
        private void SetupBurgerFighterSo(FightServiceSO fightServiceSo)
        {
            so = fightServiceSo;
        }
        [TickServiceFunction]
        public void ListenTick()
        {
            /*
            if (timer >= time)
            {
                timer -= time;
                Fight();
            }
            else
            {
                timer += TickService.getTickTime;
            }
            */
        }
        public void Fight()
        {/*
            burger.transform.Rotate(Vector3.up, so.rotateSpeed);
            */
        }

        public GameObject fighter {  set => burger = value; }
    }
}