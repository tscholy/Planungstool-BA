using DatabaseService.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace WebService.Models
{
    public class TrainingService : BaseService
    {
        TrainingsDataRepository trainingsDataRepository = new TrainingsDataRepository(provider);

        private const string imgPathExercise =  "exercises\\";

        public List<Trainingsobject> GetAllTrainingsObjects(int userid)
        {
            List<Trainingsobject> newObjects = new List<Trainingsobject>();
            using (IDbConnection connection = provider.GetConnection())
            {
                newObjects = trainingsDataRepository.GetAllTrainingsObjects(connection, userid);
            }
           
            return newObjects;
          
        }

        internal object InsertObject(Trainingsobject trainingsobject, int userid)
        {
            List<Trainingsobject> newObjects = new List<Trainingsobject>();
            using (IDbConnection connection = provider.GetConnection())
            {
                newObjects = trainingsDataRepository.InsertObject(connection, userid, trainingsobject);
            }

            return newObjects;
        }

        internal object GetAllPublicTrainingsObjects()
        {
            List<Trainingsobject> newObjects = new List<Trainingsobject>();
            using (IDbConnection connection = provider.GetConnection())
            {
                newObjects = trainingsDataRepository.GetAllPublicTrainingsObjects(connection);
            }

            return newObjects;
        }

        internal List<Trainingsexercise> GetAllPublicTrainingExercises()
        {
            List<Trainingsexercise> newObjects = new List<Trainingsexercise>();
            using (IDbConnection connection = provider.GetConnection())
            {
                newObjects = trainingsDataRepository.GetAllPublicTrainingExercises(connection);
            }

            foreach(Trainingsexercise trainEx in newObjects)
            {
                MemoryStream memoryStream = new MemoryStream();
                using (FileStream fs = new FileStream(trainEx.ImagePath, FileMode.Open))
                {
                    fs.CopyTo(memoryStream);
                    trainEx.Image = memoryStream.ToArray();
                }
            }

            return newObjects;
        }

        internal List<Trainingsexercise> GetAllTrainingsExercisesForOwner(int userid)
        {
            List<Trainingsexercise> newObjects = new List<Trainingsexercise>();
            using (IDbConnection connection = provider.GetConnection())
            {
                newObjects = trainingsDataRepository.GetAllTrainingsExercisesOwner(connection, userid);
            }
            foreach(Trainingsexercise trainEx in newObjects)
            {
                MemoryStream memoryStream = new MemoryStream();
                using (FileStream fs = new FileStream(trainEx.ImagePath, FileMode.Open))
                {
                    fs.CopyTo(memoryStream);
                    trainEx.Image = memoryStream.ToArray();
                }
            }
            return newObjects;
        }

        internal Trainingsexercise InsertExercise(Trainingsexercise trainingsexercise, int owner)
        {
            
            string name = trainingsexercise.Name + ".jpeg";
            name = name.Replace(" ", string.Empty);
            using (MemoryStream stream = new MemoryStream(trainingsexercise.Image))
            {
                Image img = System.Drawing.Image.FromStream(stream);
                img.Save(@"C:\Users\Christina\Documents\Visual Studio 2017\Projects\BA\Planungstool-BA\WebService\Exercises\" + name, ImageFormat.Jpeg);
                trainingsexercise.ImagePath = @"C:\Users\Christina\Documents\Visual Studio 2017\Projects\BA\Planungstool-BA\WebService\Exercises\" + name;
            }
           
            using (IDbConnection connection = provider.GetConnection())
            {
                return trainingsDataRepository.InsertExercise(connection, trainingsexercise, owner);
            }
        }

        internal object GetAllTrainingsObjectsForOwner(int userid)
        {
            List<Trainingsobject> newObjects = new List<Trainingsobject>();
            using (IDbConnection connection = provider.GetConnection())
            {
                newObjects = trainingsDataRepository.GetAllTrainingsObjectsOwner(connection, userid);
            }

            return newObjects;
        }
    }
}