using Data;
using Infrastructure;
using Infrastructure.Services;
using Services.Input;
using Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero
{
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        private CharacterController _characterController;
        public float MovementSpeed;
        private IInputServices _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputServices>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Start() => _camera = Camera.main;

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constans.EPSILON)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
            }

            movementVector += Physics.gravity;

            _characterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null)
                    Warp(to: savedPosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector();
            _characterController.enabled = true;
        }

        private static string CurrentLevel()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}