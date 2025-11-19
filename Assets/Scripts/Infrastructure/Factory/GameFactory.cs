using System;
using System.Collections.Generic;
using Infrastructure.AssetManagment;
using Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public GameObject HeroGameObject { get; set; }
        public event Action HeroCreated;
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        
        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            HeroGameObject = InstantiateRegistered(AssetPath.PLAYER_PATH, initialPoint.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }
            

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader savedProgressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(savedProgressReader);
            }
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 atPosition)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath, atPosition);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void Register(ISavedProgressReader savedProgressReader)
        {
            if (ProgressReaders is ISavedProgress savedProgressWriter)
            {
                ProgressReaders.Add(savedProgressWriter);  
            }
            
            ProgressReaders.Add(savedProgressReader);
        }
    }
}