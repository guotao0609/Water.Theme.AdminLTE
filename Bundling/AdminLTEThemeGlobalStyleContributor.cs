using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Water.Theme.AdminLTE.Bundling
{
    public class AdminLTEThemeGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
         
            context.Files.Add("/themes/adminlte/css/adminlte.min.css");
            context.Files.Add("/themes/plugins/overlayScrollbars/css/OverlayScrollbars.min.css");
            context.Files.Add("/themes/adminlte/css/style.css");
            // context.Files.Add("/themes/adminlte/layout.css");
        }
    }
}
