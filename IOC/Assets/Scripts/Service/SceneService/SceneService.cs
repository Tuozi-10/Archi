using System.Collections.Generic;
using Addressables;
using Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Service.SceneService
{
    public class SceneService : ISceneService
    {
        private List<Object> dependencyObjetcs;
        
        public void LoadScene()
        {
            //SceneManager.LoadScene("New Scene");
            

        }

        public void LoadScene(string name)
        {
           // SceneManager.LoadScene(name);
        }

        public ISceneService SetDependency(Object obj)
        {
            dependencyObjetcs.Add(obj);
            Debug.Log($"Add {obj.name} to SceneService");
            return this;
        }
    }
}