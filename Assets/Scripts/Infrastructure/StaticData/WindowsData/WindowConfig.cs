using System;
using UnityEngine;

namespace Infrastructure.StaticData.WindowsData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowsId WindowsId;
        public GameObject WindowsPrefab;
    }
}