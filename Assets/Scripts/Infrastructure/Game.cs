using Services.Input;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        public static IInputServices InputService;

        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}