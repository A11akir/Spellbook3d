using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstraper GameBootstraperPrefab;
        private void Awake()
        {
            var bootstrapper = FindObjectsOfType<GameBootstraper>();

            if (bootstrapper == null)
            {
                Instantiate(GameBootstraperPrefab);
            }
        }
    }
}