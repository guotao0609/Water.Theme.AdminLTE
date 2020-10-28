using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Water.Theme.AdminLTE.Bundling
{
    public class AdminLTEThemeGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/themes/adminlte/js/adminlte.min.js");
            context.Files.Add("/themes/adminlte/js/demo.js");
            context.Files.Add("/themes/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
        }
    }
}
