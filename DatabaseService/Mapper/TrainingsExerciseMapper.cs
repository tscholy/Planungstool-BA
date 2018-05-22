using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    class TrainingsExerciseMapper : EntityMap<Trainingsexercise>
    {
        public TrainingsExerciseMapper()
        {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Name).ToColumn("name");
            Map(x => x.Process).ToColumn("process");
            Map(x => x.Type).ToColumn("type");
            Map(x => x.Accessibility).ToColumn("accessibility");
            Map(x => x.ImagePath).ToColumn("image");
            Map(x => x.Owner).ToColumn("owner");
            Map(x => x.Parent).ToColumn("parent");

        }
    }
}
