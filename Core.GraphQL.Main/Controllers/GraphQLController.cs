using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.GraphQL.Main.Config;
using Core.GraphQL.Main.GraphQL.Queries;
using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.GraphQL.Main.Controllers
{
    [Route(GraphQLConfig.GraphQLPath)]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly IDocumentWriter _documentWriter;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter documentExecuter, IDocumentWriter documentWriter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _documentWriter = documentWriter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = query.Variables.ToInputs();
                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}