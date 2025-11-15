using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetManagment
{
    public interface IAssetProvider : IService

    {
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    }
}