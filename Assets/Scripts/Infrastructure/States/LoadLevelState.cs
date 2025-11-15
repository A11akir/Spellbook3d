using CameraLogic;
using Infrastructure.Factory;
using Logic;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        public const string PLAYER_INITIAL_POINT = "PlayerInitialPoint";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {   
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(PLAYER_INITIAL_POINT));
            CameraFollow(hero);
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject hero)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().SetTarget(hero.transform);
        } 

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }
}