using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6.Training.Views
{
    [HtmlTargetElement("app-name")]
    [HtmlTargetElement(Attributes = "app-name")]
    public class AppNameTagHelper : TagHelper
    {
        MyConfig _config;

        [HtmlAttributeName("emoji")]
        public string Emoji { get; set; }

        public AppNameTagHelper(MyConfig config)
        {
            this._config = config;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent(_config.AppName);
        }
    }
}
