using UnityEngine;

namespace DefaultNamespace
{
    public class Perso : MonoBehaviour
    {
        [SerializeField] private ScriptableObject SO;
        
        public ScriptableObject GetSO()
        {
            return SO;
        }
        
        public void SetSO(ScriptableObject so)
        {
            SO = so;
        }
    }
}