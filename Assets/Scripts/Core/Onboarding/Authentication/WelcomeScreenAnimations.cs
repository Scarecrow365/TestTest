//using DG.Tweening;
using UnityEngine;

namespace _clone.Scripts.Core.Onboarding.Authentication
{
    public class WelcomeScreenAnimations : MonoBehaviour
    {
        [SerializeField] private CanvasGroup[] commonElementsContainers = new CanvasGroup[2];

        private const float TransitionDuration = 0.5f;

        //private Sequence animationSequence;

        public void ShowContainer(int showingContainerIndex)
        {
            int hidingContainerIndex = showingContainerIndex == 0 ? 1 : 0;
            float duration = (1f - commonElementsContainers[showingContainerIndex].alpha) * TransitionDuration;

            commonElementsContainers[showingContainerIndex].interactable = true;
            commonElementsContainers[showingContainerIndex].blocksRaycasts = true;
            commonElementsContainers[showingContainerIndex].gameObject.SetActive(true);

            commonElementsContainers[hidingContainerIndex].interactable = false;
            commonElementsContainers[hidingContainerIndex].blocksRaycasts = false;
            commonElementsContainers[hidingContainerIndex].gameObject.SetActive(false);

            // animationSequence?.Kill();
            // animationSequence = DOTween.Sequence();
            // animationSequence.Append(commonElementsContainers[showingContainerIndex].DOFade(1f, duration));
            // animationSequence.Join(commonElementsContainers[hidingContainerIndex].DOFade(0f, duration));
        }
    }
}