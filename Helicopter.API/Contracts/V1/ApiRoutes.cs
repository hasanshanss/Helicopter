using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helicopter.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Game
        {
            public const string GetAll = Base + "/List";
            public const string Get = Base + "/{gameId}";
            public const string Create = Base +"/Create";
        }
    }
}
