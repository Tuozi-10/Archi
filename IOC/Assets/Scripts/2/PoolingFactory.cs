using UnityEngine;

namespace _2
{
    public class PoolingFactory
    {
        private GameObject m_lumberjackPrefab;
        private GameObject m_diggerPrefab;
        private GameObject m_forgerPrefab;

        private GameObject[] pool;

        private int poolSize = 10;
        
        void Start()
        {
        }

        public GameObject CreateForger()
        {
            m_forgerPrefab = Resources.Load<GameObject>("Prefabs/Forger");
            return m_forgerPrefab;
        }

        public GameObject CreateDigger()
        {
            m_diggerPrefab = Resources.Load<GameObject>("Prefabs/Digger");
            return m_diggerPrefab;
        }

        public GameObject CreateLumberJack()
        {
            m_lumberjackPrefab = Resources.Load<GameObject>("Prefabs/Lumberjack");
            return m_lumberjackPrefab;
        }

        public void CreatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                var newDigger = CreateDigger();
                var newForger = CreateForger();
                var newLumberJack = CreateLumberJack();
                
                newDigger.gameObject.SetActive(false);
                newForger.gameObject.SetActive(false);
                newLumberJack.gameObject.SetActive(false);
            }
        }
    }
}