using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    public class UserMapper : EntityMap<User>
    {
        public UserMapper()
        {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Firstname).ToColumn("firstname");
            Map(x => x.Lastname).ToColumn("lastname");
            Map(x => x.Username).ToColumn("username");
            Map(x => x.Password).ToColumn("password");
        }
    }
}
