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
            return dbConnection.Query<Trainingsobject>("SELECT * FROM user_trainingsobject a JOIN trainingsobject b ON a.ID_trainingsobject = b.ID WHERE a.ID_user = @userID", new { userID = userID }).ToList();
        }

        public List<Trainingsobject> InsertObject(IDbConnection connection, int userID, Trainingsobject trainingsobject)
        {
            connection.Query("INSERT INTO trainingsobject(name, description, accessibility, image, owner) VALUES(@name,@description,@accessibility,@image,@owner)", new { name = trainingsobject.Name, description = trainingsobject.Description, accessibility = trainingsobject.Accessibility, image = trainingsobject.Image, owner = trainingsobject.Owner });
            return connection.Query<Trainingsobject>("SELECT * FROM user_trainingsobject a JOIN trainingsobject b ON a.ID_trainingsobject = b.ID WHERE a.ID_user = @userID", new { userID = userID }).ToList();
        }
    }
}
