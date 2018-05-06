using Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Text;
using System.Data;
using System.Linq;

namespace DatabaseService.Repos
{
    public class TrainingsDataRepository
    {
        private ConnectionProvider provider;

        public TrainingsDataRepository(ConnectionProvider connection)
        {
            this.provider = connection;
        }

        public List<Trainingsobject> GetAllTrainingsObjects(IDbConnection dbConnection, int userID)
        {
            return dbConnection.Query<Trainingsobject>("SELECT * FROM user_trainingsobject a JOIN trainingsobject b ON a.ID_trainingsobject = b.ID WHERE a.ID_user = @userID  OR b.accessibility = 'public' GROUP BY b.ID", new { userID = userID }).ToList();
        }

        public List<Trainingsobject> InsertObject(IDbConnection connection, int userID, Trainingsobject trainingsobject)
        {
            connection.Query("INSERT INTO trainingsobject(name, description, accessibility, image, owner) VALUES(@name,@description,@accessibility,@image,@owner)", new { name = trainingsobject.Name, description = trainingsobject.Description, accessibility = trainingsobject.Accessibility, image = trainingsobject.Image, owner = trainingsobject.Owner });
            return connection.Query<Trainingsobject>("SELECT * FROM user_trainingsobject a JOIN trainingsobject b ON a.ID_trainingsobject = b.ID WHERE a.ID_user = @userID", new { userID = userID }).ToList();
        }

        public List<Trainingsobject> GetAllPublicTrainingsObjects(IDbConnection dbConnection)
        {
            return dbConnection.Query<Trainingsobject>("SELECT * FROM trainingsobject WHERE accessibility = 'public'").ToList();
        }

        public List<Trainingsexercise> GetAllPublicTrainingExercises(IDbConnection dbConnection)
        {
            return dbConnection.Query<Trainingsexercise>("SELECT * FROM trainingexercise WHERE accessibility = 'public'").ToList();
        }

        public Trainingsexercise InsertExercise(IDbConnection connection, Trainingsexercise trainingsexercise, int owner)
        {
            return connection.Query<Trainingsexercise>("INSERT INTO trainingexercise(name, process, accessibility, type, image, owner) VALUES(@name, @process, @accessibility, @type, @image, @owner)", new { name = trainingsexercise.Name, process = trainingsexercise.Process, accessibility = trainingsexercise.Accessibility, type = trainingsexercise.Type, image = trainingsexercise.ImagePath, owner = trainingsexercise.Owner }).FirstOrDefault();
        }

        public List<Trainingsobject> GetAllTrainingsObjectsOwner(IDbConnection connection, int userid)
        {
            return connection.Query<Trainingsobject>("SELECT * FROM trainingsobject WHERE owner = @userid", new { userid = userid }).ToList();
        }

        public List<Trainingsexercise> GetAllTrainingsExercisesOwner(IDbConnection connection, int userid)
        {
            return connection.Query<Trainingsexercise>("SELECT * FROM trainingexercise WHERE owner = @userid", new { userid = userid }).ToList();
        }
    
    }
}
