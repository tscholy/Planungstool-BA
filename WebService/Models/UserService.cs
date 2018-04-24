using DatabaseService.Repos;
using Models;
using System;
using System.Data;

namespace WebService.Models
{
    public class UserService : BaseService
    {

        private UserDataRepository userDataRepo = new UserDataRepository(provider);


        public User Login(string username, string password)
        {
            User newUser;
            using (IDbConnection connection = provider.GetConnection())
            {
                newUser = userDataRepo.Login(connection, username, password);
            }
            if (newUser != null)
            {
                return newUser;
            }
            else
            {
                throw new Exception("User does not exist");
            }
        }
    }
}