﻿using Models;
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
    }
}