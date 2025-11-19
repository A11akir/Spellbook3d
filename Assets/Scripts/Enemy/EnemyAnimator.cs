using UnityEditor;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath() => _animator.SetTrigger(Die);
    }
}