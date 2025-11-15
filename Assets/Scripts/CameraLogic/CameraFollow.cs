using UnityEngine;
using Cinemachine;

namespace CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera vcam;
        private Transform target;

        private void Start()
        {
            if (vcam != null && target != null)
                vcam.Follow = target;
        }
        
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
                vcam.Follow = target;
        }
    }
}