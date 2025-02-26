using UnityEngine;

namespace _clone.Scripts.Core.MainMenu.Tabs
{
    public abstract class BaseTabNode : MonoBehaviour
    {
        public BaseTabNode NextNode { get; private set; }

        public virtual void SetNextNode(BaseTabNode parentNode)
        {
        }

        public virtual void Enable()
        {
            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }

        public virtual void Dispose()
        {
            NextNode?.Dispose();
            NextNode = null;
        }
    }
}