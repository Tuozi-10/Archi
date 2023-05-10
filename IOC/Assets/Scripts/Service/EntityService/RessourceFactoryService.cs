using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Components;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;
namespace Service
{
    public class RessourceFactoryService : IRessourceFactoryService
    {
        private RessourceSO _treeSO;
        private Entity _treePrefab;
        private LoaderAdressable loaderAdressable;
        private int _currentLoad;
      
        private const string _treeAdressableName = "Tree";
        private const string _treeSOAdressableName = "TreeSO";
        
        [ServiceInit]
        void Init()
        {
            loaderAdressable = new LoaderAdressable(2);
        }

        public void EnabledService(Action callback)
        {
            loaderAdressable.CurrentLoad = 0;
            loaderAdressable.TempEnabledCallback = callback;
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<RessourceSO>(_treeSOAdressableName, SetTreeSO );
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_treeAdressableName, SetTreePrefab);
        }
        
        private void SetTreeSO(RessourceSO entitySo)
        {
            _treeSO = entitySo;
            loaderAdressable.CheckAmountLoad();
        }

        private void SetTreePrefab(GameObject entity)
        {
            _treePrefab = entity.GetComponent<Entity>();
            loaderAdressable.CheckAmountLoad();
        }
        public void DisabledService(Action callback)
        {
            Release(_treeSO);
            Release(_treePrefab);
            callback?.Invoke();
        }

        public bool GetIsActiveService { get; }
        public Entity CreateRock(Vector3 pos)
        {
            throw new NotImplementedException();
        }

        public Entity CreateTree(Vector3 pos)
        {
            var tree = Object.Instantiate(_treePrefab, pos, Quaternion.identity);
            tree.AddComponent(new RessourceComponent()).Init(tree, _treeSO.RessourceComponentData);
            return tree;
        }
    }
    
}
