using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace sigtest.Middleware
{
    public class JwtVerify 
    {
        private readonly RequestDelegate next;

        public JwtVerify(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// This Middleware validates a JWT token, by calling out to a separate service
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context) 
        {
            // Test if caller is authenticated 
            if (context.Request.Headers["Connection"] == "Upgrade")
            {
                context.Request.Query.TryGetValue("token", out var token);
                if (token == "") {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                context.Request.Headers.Add("Authorization", "Bearer " + token[0]);
            } 

           // bool IsAuthenticated = context.User.Identity.IsAuthenticated;
           // string AuthenticationType = string.Empty;

            // if true we need to test if the token has been issued to the current sender/caller
            // if (IsAuthenticated)
            // {     
            //      // get the type of authentication
            //      AuthenticationType = context.User.Identity.AuthenticationType.ToLower();

            //     // test if  AuthTppe is bearer (authenticationTypes.federation)
            //     if (AuthenticationType == "authenticationtypes.federation")
            //     {
            //         var header = context.Request.Headers["Authorization"];

            //         Console.WriteLine("Bearer Token: " + header);

            //         var validBearerToken = await VerifyBearer(header);

            //         if (!validBearerToken)
            //         {
            //             // if token not verfied send 401 unauthorised
            //             context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //         }
            //     }
             
            // }

            await next(context);
        }

        private async Task<bool> VerifyBearer(string token)
        {
            /*
             * @TODO Implement OAuth call to server
             */
            var result = false;
            if (token != "") {
                result = await Task.FromResult<bool>(true);
            }

            return result;
        }
    }
}