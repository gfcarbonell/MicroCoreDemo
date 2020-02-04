using Core.Domain.Models;
using GraphQL.Types;
using Core.Service.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.GraphQL.Main.GraphQL.Types;
using Core.GraphQL.Main.GraphQL.InputTypes.Users;

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
                           new QueryArgument<NonNullGraphType<AddUserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return userService.Add(user);
                });
        }
    }
}
