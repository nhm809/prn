using System.Configuration;
using System.Data;
using System.Windows;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetBrowserFeatureControl();
        }
        private void SetBrowserFeatureControl()
        {
            var fileName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            using (var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
            {
                key?.SetValue(fileName, 11001, Microsoft.Win32.RegistryValueKind.DWord); // 11001 = IE11
            }
        }
    }

}
