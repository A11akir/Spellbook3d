using Services.Input;

namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
            
        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Game.InputService = new InputServices();
        }

        public void Exit()
        {
                
        }
    }
}