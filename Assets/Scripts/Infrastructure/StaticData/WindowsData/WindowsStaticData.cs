using Infrastructure.StaticData.WindowsData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData.WindowsData
{
    [CreateAssetMenu(fileName = "WindowsData", menuName = "StaticData/Windows")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}