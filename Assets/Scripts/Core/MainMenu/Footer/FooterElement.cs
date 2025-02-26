using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.MainMenu.Footer
{
    public class FooterElement : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image image;
        [SerializeField] private GameObject notificationIndicator;

        private Color defaultTextColor = Color.magenta;
        private Color defaultImageColor = Color.magenta;

        public void Init()
        {
            SetDefaultText();
            SetDefaultImage();
            SetNotificationIndicator();
        }

        public void SetCallback(Action<bool> onClick)
        {
            toggle.onValueChanged.AddListener(isOn =>
            {
                if (isOn) Activate();
                else Deactivate();

                onClick?.Invoke(isOn);
            });
        }

        public void Press()
        {
            toggle.isOn = true;
        }

        private void Activate()
        {
            text.color = toggle.colors.selectedColor;
            image.color = toggle.colors.selectedColor;
        }

        private void Deactivate()
        {
            SetDefaultText();
            SetDefaultImage();
        }

        private void SetDefaultImage()
        {
            if (defaultImageColor == Color.magenta)
                defaultImageColor = image.color;

            image.color = defaultImageColor;
        }

        private void SetDefaultText()
        {
            if (defaultTextColor == Color.magenta)
                defaultTextColor = text.color;

            text.color = defaultTextColor;
        }

        private void SetNotificationIndicator()
        {
            notificationIndicator.SetActive(false);
        }
    }
}