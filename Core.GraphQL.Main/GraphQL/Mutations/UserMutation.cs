using Core.Domain.Models;
using Core.GraphQL.Main.GraphQL.InputTypes;
using Core.GraphQL.Main.GraphQL.Types;
using Core.Service.Contract.IServices;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IUserService userService)
        {
            Name = "UserMutation";

            Field<UserType>(
                name: "addUser",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return userService.Add(user);
                });
        }
    }
}
