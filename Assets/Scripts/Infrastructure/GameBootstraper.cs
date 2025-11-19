using Infrastructure.States;
using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        public LoadingCurtain LoadingCurtainPrefab;
        
        private void Awake()
        {
            _game = new Game(this, Instantiate(LoadingCurtainPrefab));
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}
