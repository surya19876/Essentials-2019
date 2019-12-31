using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.DynamoDBv2.Model;
using GroundBooking.Repository.IRepository;
using GroundBooking.Repository.Repository;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using GroundBooking.Repository.DbContext;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSServerlessTemplate2
{

    public class Functions
    {
        private IGroundRepository groundRepository;
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
            groundRepository = new GroundRepository();
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var result = groundRepository.GetGrounds();

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(result),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            

            return response;
        }

        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse Post(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var requestObject = JsonConvert.DeserializeObject<Grounds>(request.Body);
            groundRepository.AddGround(requestObject);
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.Created,
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }
    }
}
