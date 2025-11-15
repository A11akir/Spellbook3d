using Infrastructure.AssetManagment;
using Infrastructure.Factory;
using Infrastructure.Services;
using Services.Input;
using Services.PersistentProgress;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly string INITIAL = "Initial";
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }
            
        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(INITIAL, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("Main");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputServices>(new InputServices());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
        }

        public void Exit()
        {
                
        }
    }
}