using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Plugins;
using MvvmCross.Uwp.Platform;
using Windows.UI.Xaml.Controls;

namespace Base.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxPluginManager CreatePluginManager()
        {
            return base.CreatePluginManager();
        }

        protected override void InitializeFirstChance()
        {

        }
    }
}

