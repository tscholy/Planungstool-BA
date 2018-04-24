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
    }
}
