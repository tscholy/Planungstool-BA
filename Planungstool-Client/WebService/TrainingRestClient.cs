using Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planungstool_Client.WebService
{
    public class TrainingRestClient : BaseRestClient
    {
        public TrainingRestClient(int userId) : base(userId)
        {
                       
        }

        public List<Trainingsobject> GetAllTrainingsobjectsForUser(int userID)
        {
            try
            {
                var request = new RestRequest("training/alltrainingsobjects", Method.GET);
                request.AddParameter("userid", userID);
                IRestResponse response = client.Execute(request);
                List<Trainingsobject> objects = JsonConvert.DeserializeObject<List<Trainingsobject>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   return objects;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new List<Trainingsobject>();
        }



        public bool SaveObject(Trainingsobject tobject)
        {
            try
            {
                var request = new RestRequest("training/insertobject", Method.POST);


                var json = JsonConvert.SerializeObject(tobject);
                request.AddParameter("text/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute<List<Trainingsobject>>(request);
                List<Trainingsobject> objects = JsonConvert.DeserializeObject<List<Trainingsobject>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

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
