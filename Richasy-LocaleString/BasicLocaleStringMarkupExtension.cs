using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Markup;

namespace Richasy.LocaleString.UWP
{
    [MarkupExtensionReturnType(ReturnType = typeof(string))]
    public class BasicLocaleStringMarkupExtension : MarkupExtension
    {
        public string Name { get; set; }
        protected override object ProvideValue()
        {
            ResourceLoader resourceLoader = ResourceLoader.GetForViewIndependentUse();
            string result = resourceLoader.GetString(Name);
            return result;
        }
    }
}
