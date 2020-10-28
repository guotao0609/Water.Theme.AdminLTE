﻿using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Water.Theme.AdminLTE
{
    [ThemeName(Name)]
    public class AdminLTETheme : ITheme, ITransientDependency
    {
        public const string Name = "Basic";

        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/AdminLTE/Layouts/Application.cshtml";

                case StandardLayouts.Account:
                    return "~/Themes/AdminLTE/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/AdminLTE/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/AdminLTE/Layouts/Empty.cshtml" : null;
            }
        }
    }
}
