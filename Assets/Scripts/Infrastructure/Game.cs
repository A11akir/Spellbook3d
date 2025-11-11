using Services.Input;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        public static IInputServices InputService;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}