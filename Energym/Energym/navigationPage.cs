using Xamarin.Forms;

namespace Energym
{
    internal class navigationPage : Page
    {
        private AppShell appShell;

        public navigationPage(AppShell appShell)
        {
            this.appShell = appShell;
        }
    }
}