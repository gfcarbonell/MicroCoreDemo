using Core.CrossCutting.Utils;
using Core.Domain.Models.Security;
using Core.Domain.Security;
using Core.GraphQL.Main.GraphQL.InputTypes.Authentications;
using Core.GraphQL.Main.GraphQL.Types;
using Core.Service.Contract.IServices;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Mutations
{
    public class AuthenticationMutation : ObjectGraphType
    {
        public AuthenticationMutation(IUserService  userService, IUserAuthenticationService userAuthenticationService)
        {
            Name = "AuthMutation";

            FieldAsync<UserAuthenticationType>(
                name: "loginByUsername",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginByUsernameInputType>> { Name = "login" }),

                resolve: async contextAsync =>
                {
                    var login = contextAsync.GetArgument<Login>("login");

                    var user = await userService.GetByUsernameAsync(login.Username);

                    if(user == null)
                    {
                        contextAsync.Errors.Add(new ExecutionError(Util.NOT_FOUND_USER));
                    }

                    if(user.Password != null)
                    {
                        
                    }
                    return user;
                });

            FieldAsync<UserAuthenticationType>(
                name: "loginByEmail",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginByEmailInputType>> { Name = "login" }),
                resolve: async contextAsync =>
                {
                    var login = contextAsync.GetArgument<Login>("login");
                    return login;
                });

            FieldAsync<UserAuthenticationType>(
                name: "loginByCellphone",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginByCellphoneInputType>> { Name = "login" }),
                resolve: async contextAsync =>
                {
                    var login = contextAsync.GetArgument<Login>("login");
                    return login;
                });
        }
    }
}
