using Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planungstool_Client.WebService
{
    public class UserRestClient : BaseRestClient
    {
        public UserRestClient(int userid) : base(userid)
        {
        }

        public User CurrentUser { get; set; }
        public bool Login(string username, string password)
        {
            try
            {
                var request = new RestRequest("user/login", Method.POST);
                request.AddParameter("username", username);
                request.AddParameter("password", password);

                request.AddHeader("header", "value");

                var response = client.Execute<User>(request);
                var content = response.Content;
               
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   CurrentUser = response.Data;
                   return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
