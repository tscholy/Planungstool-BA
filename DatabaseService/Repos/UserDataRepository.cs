using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DatabaseService.Repos
{
    public class UserDataRepository
    {
        public UserDataRepository(ConnectionProvider provider)
        {
            this.provider = provider;
        }

        private ConnectionProvider provider;

        public User Login(IDbConnection connection, string username, string password)
        {
            return connection.Query<User>("SELECT * FROM user WHERE username = @username AND password = @password", new { username = username, password = password }).FirstOrDefault();
        }
    }
}
