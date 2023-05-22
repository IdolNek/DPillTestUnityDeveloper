using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.WindowsData
{
    [CreateAssetMenu(fileName = "WindowsData", menuName = "StaticData/Windows")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}