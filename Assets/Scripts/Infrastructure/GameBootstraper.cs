using UnityEngine;

namespace Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        private void Awake()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}
