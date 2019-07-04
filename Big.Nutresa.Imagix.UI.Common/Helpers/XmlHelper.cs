using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Big.Nutresa.Imagix.UI.Common.Helpers
{
    public class XmlHelper
    {
        public static string GetValueByCurrentLanguage(string data,string Language)
        {
            try
            {
                String rawXml = data;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(rawXml);
                XmlNodeList nNombre = xmlDoc.GetElementsByTagName(Language);
                string result = nNombre[0].InnerText;
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
