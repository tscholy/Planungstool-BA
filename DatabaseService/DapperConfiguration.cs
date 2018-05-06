using Dapper.FluentMap;
using DatabaseService.Mapper;
using System;

namespace DatabaseService
{
    public static class DapperConfiguration
    {
        private static bool mapped;
        public static void Map()
        {
            if (mapped)
            {
                return;
            }
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMapper());
                config.AddMap(new TrainingsObjectMapper());
                config.AddMap(new TrainingsExerciseMapper());
                config.AddMap(new TrainingsUnitMapper());
            });
        }
    }
}
