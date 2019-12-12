using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace HouseHoldManagementSystem.ABP.Localization
{
    public static class ABPLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags england"));
            localizationConfiguration.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flags tr"));
            localizationConfiguration.Languages.Add(new LanguageInfo("zh-Hans", "Chinese", "famfamfam-flags zh-Hans", isDefault: true));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ABPConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ABPLocalizationConfigurer).GetAssembly(),
                        "HouseHoldManagementSystem.ABP.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}