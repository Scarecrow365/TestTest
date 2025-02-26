namespace _clone.Scripts.Core.MainMenu.Tabs.StatsTab
{
    public class StatsTabController : ITabController
    {
        private readonly StatsTabNode view;

        public StatsTabController(StatsTabNode view)
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