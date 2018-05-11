using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    public class TrainingsUnitMapper :  EntityMap<Trainingsunit>
    {
        public TrainingsUnitMapper()
        {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Name).ToColumn("name");
            Map(x => x.Description).ToColumn("description");
            Map(x => x.Owner).ToColumn("owner");
            Map(x => x.Accessibility).ToColumn("accessibility");
        }
    }
}
