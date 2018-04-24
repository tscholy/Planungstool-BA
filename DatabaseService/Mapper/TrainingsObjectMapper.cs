using Dapper.FluentMap.Mapping;
using Models;

namespace DatabaseService.Mapper
{
    public class TrainingsObjectMapper : EntityMap<Trainingsobject>
    {
        public TrainingsObjectMapper()
        {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Name).ToColumn("name");
            Map(x => x.Description).ToColumn("description");
            Map(x => x.Accessibility).ToColumn("accessibility");
            Map(x => x.Image).ToColumn("image");
        }
    }
}
