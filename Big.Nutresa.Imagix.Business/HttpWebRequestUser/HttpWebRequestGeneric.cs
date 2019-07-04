using Big.Nutresa.Imagix.Integration.HttpWebRequestSOAP;
using Big.Nutresa.Imagix.UI.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big.Nutresa.Imagix.Business.HttpWebRequestUser
{
    public class HttpWebRequestGeneric
    {
        public static T ConsumeServiceUserByAction<T>(string action, string serialize, string service) where T: class
        {
            T response = Activator.CreateInstance<T>();
            string result = string.Empty;
            HttpWebRequestServiceSOAP HttpWebReq = HttpWebRequestServiceSOAP.GetInstance("text/xml;charset=\"utf-8\"", "text/xml", "POST", service);

            result = HttpWebReq.ConsumeServiceUserByAction(action, serialize);
            response = SerializerXML.Deserialize<T>(result);

            return response;
        }
    }
}
