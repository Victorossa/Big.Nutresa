
using System.Collections.Generic;

namespace Big.Nutresa.Imagix.UI.Common.Models
{
    public class FAQ
    {
        public string question;
        public string answer;
        public int number;
    }

    public class Step
    {
        public string imageUrl;
        public string title;
        public string description;
        public int number;
    }

    public class StandarContent
    {
        public string viewNameUrl;
    }

    public class ContentProviderSettingModel
    {
        public StandarContent StandarContent;
        public List<dynamic> Content;
    }
}
