using DatabaseService.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace WebService.Models
{
    public class TrainingService : BaseService
    {
        TrainingsDataRepository trainingsDataRepository = new TrainingsDataRepository(provider);

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
    }
}