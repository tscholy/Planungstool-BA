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

        public List<Trainingsobject> GetAllTrainingsobjectsForOwner(int userID)
        {
            try
            {
                var request = new RestRequest("training/allownertrainingsobjects", Method.GET);
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

        internal Trainingsunit SaveUnit(Trainingsunit trainingsunit)
        {
            try
            {
                var request = new RestRequest("training/insertunit", Method.POST);

                var json = JsonConvert.SerializeObject(trainingsunit);
                request.AddParameter("text/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute<Trainingsunit>(request);
                Trainingsunit unit = JsonConvert.DeserializeObject<Trainingsunit>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return unit;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new Trainingsunit();
        }

        internal List<Trainingsexercise> GetExercisesForUnit(int id)
        {
            try
            {
                var request = new RestRequest("training/allexercisesforunit", Method.GET);
                request.AddParameter("unitid", id);
                IRestResponse response = client.Execute(request);
                List<Trainingsexercise> objects = JsonConvert.DeserializeObject<List<Trainingsexercise>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return objects;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new List<Trainingsexercise>();
        }

        internal List<Trainingsunit> GetPublicTrainingsUnits()
        {
            try
            {
                var request = new RestRequest("training/allpublictrainingsunits", Method.GET);
                IRestResponse response = client.Execute(request);
                List<Trainingsunit> objects = JsonConvert.DeserializeObject<List<Trainingsunit>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return objects;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new List<Trainingsunit>();
        }

        internal bool InsertUserTrainingsObject(int trainid)
        {
            try
            {
                var request = new RestRequest("training/insertusertrainingsobject", Method.GET);
                request.AddParameter("trainObj", trainid);
                request.AddParameter("userid", userID);
                IRestResponse response = client.Execute(request);               
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

        internal List<Trainingsobject> GetAllPublicTrainingsobjects()
        {
            try
            {
                var request = new RestRequest("training/allpublictrainingsobjects", Method.GET);
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
        

        public List<Trainingsexercise> GetAllTrainingsExercisesForOwner(int userID)
        {
            try
            {
                var request = new RestRequest("training/allownertrainingsexercises", Method.GET);
                request.AddParameter("userid", userID);
                IRestResponse response = client.Execute(request);
                List<Trainingsexercise> objects = JsonConvert.DeserializeObject<List<Trainingsexercise>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return objects;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new List<Trainingsexercise>();
        }
        public List<Trainingsunit> GetAllTrainingsUnitForOwner(int userID)
        {
            try
            {
                var request = new RestRequest("training/allownertrainingsunits", Method.GET);
                request.AddParameter("userid", userID);
                IRestResponse response = client.Execute(request);
                List<Trainingsunit> objects = JsonConvert.DeserializeObject<List<Trainingsunit>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return objects;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new List<Trainingsunit>();

        }

        internal List<Trainingsexercise> GetAllPublicTrainingsExercises()
        {
            try
            {
                var request = new RestRequest("training/allpublictrainingsexercises", Method.GET);
                IRestResponse response = client.Execute(request);
                List<Trainingsexercise> objects = JsonConvert.DeserializeObject<List<Trainingsexercise>>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return objects;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new List<Trainingsexercise>();
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

        public bool SaveExercise(Trainingsexercise trainingsexercise)
        {
            try
            {
                var request = new RestRequest("training/insertexercise", Method.POST);
                var json = JsonConvert.SerializeObject(trainingsexercise);
                request.AddParameter("text/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute<List<Trainingsexercise>>(request);
                List<Trainingsexercise> objects = JsonConvert.DeserializeObject<List<Trainingsexercise>>(response.Content);
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

    }
}
