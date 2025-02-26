namespace _clone.Scripts.Core.MainMenu.Tabs.ProfileTab
{
    public class ProfileTabController : ITabController
    {
        private readonly ProfileTabNode view;

        public ProfileTabController(ProfileTabNode view)
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