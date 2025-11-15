using UnityEngine;

namespace Infrastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            var hero = Object.Instantiate(heroPrefab, at, Quaternion.identity);
            return hero;
        }
    }
}