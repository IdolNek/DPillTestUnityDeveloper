using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpawnPool
{
    public interface IPool
    {
        List<GameObject> GameObjPool { get; }
    }
}