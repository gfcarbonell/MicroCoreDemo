using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Name = "RootMutation";
            Field<NonNullGraphType<UserMutation>>("UserMutation", resolve: context => new { });
        }
    }
}
