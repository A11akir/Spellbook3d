using DG.Tweening;
using UnityEngine;

namespace Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }
        
        public void Hide()
        {
            Curtain.DOFade(0, 1).OnComplete(() => gameObject.SetActive(false));
        }
    }
}