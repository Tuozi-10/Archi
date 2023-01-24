using UnityEngine;

namespace Service.UIService
{
    public interface IUIService : IService
    {
        public Transform staticCanvas { get;}
        public Transform updateCanvas { get;}
        
        public void LoadUI();
    }
}


