namespace _clone.Scripts.Core.MainMenu.Tabs.MainTab
{
    public class MainTabController : ITabController
    {
        private readonly MainTabNode view;

        public MainTabController(MainTabNode view)
        {
            this.view = view;
        }

        public void Enable()
        {
            view.Enable();
        }

        public void Disable()
        {
            view.Disable();
        }
    }
}