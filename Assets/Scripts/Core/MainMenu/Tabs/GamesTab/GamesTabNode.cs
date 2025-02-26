using System;
using UnityEngine;
using _clone.Scripts.Data.MainMenu;

namespace _clone.Scripts.Core.MainMenu.Tabs.GamesTab
{
    public class GamesTabNode : BaseTabNode
    {
        [SerializeField] private RectTransform root;

        private DomainFiller domainFiller;
        
        public void SetData(GamesTabContainer data)
        {
            domainFiller = new DomainFiller(data, root.transform);
        }

        public void SetCallback(Action<string> onGamePressed)
        {
            domainFiller.SetCallback(onGamePressed);
        }

        public override void Enable()
        {
            domainFiller.Fill();
            base.Enable();
        }
    }
}