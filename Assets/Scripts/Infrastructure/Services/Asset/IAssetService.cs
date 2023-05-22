using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Asset
{
    public interface IAssetService : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}