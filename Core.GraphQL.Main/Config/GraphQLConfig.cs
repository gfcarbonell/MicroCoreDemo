using Core.GraphQL.Main.GraphQL.Schemas;
using GraphiQl;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.Config
{
    public static class GraphQLConfig
    {
        public const string GraphQLPath = "/graphql";

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            // GraphQL
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<ISchema, RootSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = false;
            })
            .AddWebSockets() // Add required services for web socket support
            .AddDataLoader() // Add required services for DataLoader support
            .AddGraphTypes(ServiceLifetime.Singleton);
            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {

            // use HTTP middleware for ChatSchema at path /graphql
            app.UseGraphQL<ISchema>(GraphQLPath);

            // use websocket middleware for RootSchema at path /graphql
            app.UseGraphQLWebSockets<ISchema>(GraphQLPath);

            //app.UseGraphiQl(GraphQLPath, "/graphiql");
      

            // use graphiQL middleware at default url /graphiql
            app.UseGraphiQLServer(new GraphiQLOptions());

            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());

            return app;
        }

    }
}
