using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planungstool_Client.WebService
{
    public abstract class BaseRestClient
    {
        protected RestClient client;

        public BaseRestClient(int userId)
        {
            client = new RestClient("http://localhost:63406/api/");
            this.userID = userId;
        }

        protected int userID;


        public IEnumerable<T> Get<T>(string route)
        {
            var request = new RestRequest(route, Method.GET);
            request.AddParameter("userid", userID);
            IRestResponse response = client.Execute(request);
            List<T> objects = JsonConvert.DeserializeObject<List<T>>(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return objects;
            }
            else
            {
                return null;
            }
        }
    }
}
