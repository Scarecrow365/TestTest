using System;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.MainMenu.Tabs.ActivityTab
{
    public class ActivityTabNode : BaseTabNode
    {
        [SerializeField] private Button button1;
        [SerializeField] private Button button2;
        private Action onButton1;
        private Action onButton2;

        private void Start()
        {
            button1.onClick.AddListener(OnButton1Pressed);
            button2.onClick.AddListener(OnButton2Pressed);
        }

        public void SetCallbacks(Action onButton1, Action onButton2)
        {
            this.onButton1 = onButton1;
            this.onButton2 = onButton2;
        }

        private void OnButton1Pressed()
        {
            onButton1?.Invoke();
        }

        private void OnButton2Pressed()
        {
            onButton2.Invoke();
        }
    }
}