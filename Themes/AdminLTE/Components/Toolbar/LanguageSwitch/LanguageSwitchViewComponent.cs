﻿using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Water.Theme.AdminLTE.Themes.AdminLTE.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponent : AbpViewComponent
    {
        private readonly ILanguageProvider _languageProvider;

        public LanguageSwitchViewComponent(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageProvider.GetLanguagesAsync();
            var currentLanguage = languages.FindByCulture(
                CultureInfo.CurrentCulture.Name,
                CultureInfo.CurrentUICulture.Name
            );

            var model = new LanguageSwitchViewComponentModel
            {
                CurrentLanguage = currentLanguage,
                OtherLanguages = languages.Where(l => l != currentLanguage).ToList()
            };

            return View("~/Themes/AdminLTE/Components/Toolbar/LanguageSwitch/Default.cshtml", model);
        }
    }
}
