using System;
using _clone.Scripts.Data.MainMenu;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _clone.Scripts.Core.MainMenu.Tabs.GamesTab
{
    public class DomainFiller
    {
        private Transform root;
        private GamesTabContainer data;
        private Action<string> onTilePressed;

        public DomainFiller(GamesTabContainer data, Transform root)
        {
            this.data = data;
            this.root = root;
        }
        
        public void SetCallback(Action<string> onTilePressed)
        {
            this.onTilePressed = onTilePressed;
        }

        public void Fill()
        {
            var childCount = root.transform.childCount;
            for (var i = 0; i < data.DomainsDataCount; i++)
            {
                DomainRoot parent;
                var domainData = data.GetDomainData(i);

                if (childCount < data.DomainsDataCount)
                { 
                    parent = Object.Instantiate(data.DomainRoot, root);
                    parent.SetDomainName(domainData.GetName());
                }
                else
                {
                    parent = root.transform.GetChild(i).GetComponent<DomainRoot>();
                }

                FillGames(domainData, parent.transform);
            }
        }

        private void FillGames(DomainData domainData, Transform parent)
        {
            if (parent.childCount >= domainData.GamesCount) 
                return;
            
            for (var i = 0; i < domainData.GamesCount; i++)
            {
                var gameData = domainData.GetGameData(i);
                var tile = Object.Instantiate(data.GameTilePrefab, parent);
                tile.SetCallback(OnTilePressed);
                tile.SetGameInfo(gameData);
            }
        }

        private void OnTilePressed(string tileId) => onTilePressed?.Invoke(tileId);
    }
}