using TMPro;
using UnityEngine;

namespace _clone.Scripts.Core.MainMenu.Tabs.GamesTab
{
    public class DomainRoot : MonoBehaviour
    {
        [SerializeField] private TMP_Text domainName;
        
        public void SetDomainName(string gameName) => domainName.SetText(gameName);
    }
}