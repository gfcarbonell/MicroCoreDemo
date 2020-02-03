using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Name = "RootQuery";
            Field<NonNullGraphType<UserQuery>>("UserQuery", resolve: context => new { });
        }
    }
}
