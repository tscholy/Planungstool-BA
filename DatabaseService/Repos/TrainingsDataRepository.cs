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
            List<Trainingsobject> objects = dbConnection.Query<Trainingsobject>("SELECT * FROM user_trainingsobject a JOIN trainingsobject b ON a.ID_trainingsobject = b.ID WHERE a.ID_user = @userID", new { userID = userID }).ToList();
            List<Trainingsobject> objects1 = GetAllTrainingsObjectsOwner(dbConnection, userID);
            objects.AddRange(objects1);

            return objects;
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
        public void InsertUserTrainingsObject(IDbConnection connection, int ID_trainingsobject, int ID_user)
        {
            connection.Query("INSERT INTO user_trainingsobject(ID_user, ID_trainingsobject) VALUES (@ID_user, @ID_trainingsobject)", new { ID_user = ID_user, ID_trainingsobject = ID_trainingsobject });
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
