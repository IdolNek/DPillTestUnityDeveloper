using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameLoader GameBootstrapperPrefab;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameLoader>();
            if (bootstrapper == null)
                Instantiate(GameBootstrapperPrefab);
        }
    }
}