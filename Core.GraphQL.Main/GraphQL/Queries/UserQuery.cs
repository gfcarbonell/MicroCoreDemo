using Core.GraphQL.Main.GraphQL.Types;
using Core.Service.Contract.IServices;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUserService userService)
        {
            Name = "UserQuery";

            Field<ListGraphType<UserType>>(
                 name: "users",
                 resolve: context => userService.GetAll()
            );

            Field<UserType>(
                name: "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => userService.GetById(context.GetArgument<int>("id"))
           );
        }
    }
}
