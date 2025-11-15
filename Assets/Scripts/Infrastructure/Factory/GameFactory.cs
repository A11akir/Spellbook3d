using Infrastructure.AssetManagment;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;


        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        public GameObject CreateHero(GameObject initialPoint)
        {
            return _assetProvider.Instantiate(AssetPath.PLAYER_PATH, at: initialPoint.transform.position);
        }
        

    }
}