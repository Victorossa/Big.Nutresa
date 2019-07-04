namespace Big.Nutresa.Imagix.UI.Common.Helpers
{
    using Big.Nutresa.Imagix.UI.Common.Models;
    using Newtonsoft.Json;
    using RestSharp;
    using System.Collections.Generic;
    using System.Configuration;

    public class ApiService
    {
        #region Properties
        public static string SiteBase { get { return ConfigurationManager.AppSettings["ApiBase"]; } }
        #endregion

        
        public static Response<T> Get<T>(string baseAPI, string action, string token)
        {
            Response<T> data = new Response<T>
            {
                Status = false,
                
            };            
            try
            {

                var client = new RestClient(SiteBase);
                string uri = string.Format("{0}/{1}", baseAPI, action);
                var request = new RestRequest(uri, Method.GET);
                if (!string.IsNullOrEmpty(token))
                {
                    request.AddHeader("Token", token);
                }

                IRestResponse response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    data.Status = false;
                    data.Message.Add(new MessageResult{ Message = response.StatusCode.ToString() });
                }
                if (response.Content != null)
                {
                    var result = response.Content.ToString();
                    var list = JsonConvert.DeserializeObject<T>(result);
                    data.Status = true;
                    data.Message.Add(new MessageResult { Message = "Petición Completa" });
                    data.ObjectResponse= list;
                    
                }



            }
            catch (System.Exception ex)
            {

                data.Message.Add(new MessageResult { Message = "No se pudo realizar la petición"+ex });
            }

            return data;

        }

        public static Response<T> Post<T>(string baseAPI, string action, string token, dynamic model)
        {
            Response<T> data = new Response<T>
            {
                Status = false,
                
            };
            try
            {

                var client = new RestClient(SiteBase);
                string uri = string.Format("{0}/{1}", baseAPI, action);
                var request = new RestRequest(uri, Method.POST);
                if (token != null)
                {
                    request.AddHeader("Token", token);
                }
                if(model!= null)
                {
                    request.AddJsonBody(model);
                }                
                IRestResponse response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    data.Status = false;
                    data.Message.Add(new MessageResult { Message = response.StatusCode.ToString() });
                }
                
                if (response.Content != null)
                {
                    var result = response.Content.ToString();
                    var list = JsonConvert.DeserializeObject<Response<T>>(result);


                    return list;

                }



            }
            catch (System.Exception ex)
            {

                data.Message.Add(new MessageResult{ Message = "No se pudo realizar la petición" + ex });
            }

            return data;

        }
  
      



    }
}