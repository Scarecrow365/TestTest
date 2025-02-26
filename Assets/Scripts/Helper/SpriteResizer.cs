using UnityEngine;

namespace _clone.Scripts.Helper
{
    public class SpriteResizer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer targetSprite;
        [SerializeField] private bool saveAspect;

        private void Awake() => ResizeCameraToSprite();

        private void ResizeCameraToSprite()
        {
            var worldSpriteSize = new Vector2(targetSprite.bounds.size.x, targetSprite.bounds.size.y);
            var screenAspect = (float)Screen.width / Screen.height;

            var cameraHeight = Camera.main.orthographicSize * 2;
            var cameraWidth = cameraHeight * screenAspect;

            var scaleX = cameraWidth / worldSpriteSize.x;
            var scaleY = cameraHeight / worldSpriteSize.y;

            if (saveAspect)
            {
                var scale = Mathf.Max(scaleX, scaleY);
                transform.localScale = new Vector2(scale, scale);
            }
            else
            {
                transform.localScale = new Vector2(scaleX, scaleY);
            }
        }
    }
}