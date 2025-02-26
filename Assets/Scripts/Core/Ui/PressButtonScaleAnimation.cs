//using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Ui
{
    public class PressButtonScaleAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float scaleDuration = .25f;
        [SerializeField] private float scaleDiff = .2f;
        
        private Button button;
        //private Tween scaleTween;
        private Vector3 defaultScale;
        
        private void Awake()
        {
            button = GetComponent<Button>();
            defaultScale = transform.localScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //if (button is {interactable: false}) return;   
            
            var newScale = defaultScale - Vector3.one * scaleDiff;
            ScaleAnimation(newScale, scaleDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //if (button is {interactable: false}) return;
            
            ScaleAnimation(defaultScale, scaleDuration);
        }
        
        private void ScaleAnimation(Vector3 scale, float duration)
        {
            //scaleTween.Kill();
            //scaleTween = transform.DOScale(scale, duration);
        }
    }
}