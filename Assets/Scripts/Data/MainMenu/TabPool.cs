using System;
using System.Collections.Generic;
using System.Linq;
using _clone.Scripts.Core.MainMenu.Tabs;
using Object = UnityEngine.Object;

namespace _clone.Scripts.Data.MainMenu
{
    public class TabPool : IDisposable
    {
        private List<BaseTabNode> nodes = new();

        public bool TryGetTab<TTab>(out BaseTabNode result)
        {
            foreach (var node in nodes.Where(node => node is TTab))
            {
                result = node;
                return true;
            }

            result = null;
            return false;
        }

        public void AddNew(BaseTabNode node)
        {
            nodes.Add(node);
        }

        public void ReleaseCurrentTab<TTab>() where TTab : BaseTabNode
        {
            
        }

        public void Dispose()
        {
            var count = nodes.Count;
            for (int i = 0; i < count; i++)
            {
                Object.Destroy(nodes[i].gameObject);
            }
            
            nodes.Clear();
        }
    }
}