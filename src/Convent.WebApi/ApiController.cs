// <copyright file="ApiController.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    using Convent.WebApi.V1;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides methods to show what's possible.
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// Describes the resource and related resources.
        /// </summary>
        /// <returns>A new <see cref="LinkCollectionResponse"/>.</returns>
        [HttpGet]
        public ActionResult<LinkCollectionResponse> Describe()
        {
            var response = new LinkCollectionResponse
            {
                Links = new LinkResponse[]
                {
                    new LinkResponse(this.Url.ActionLink(action: nameof(this.Describe)), rel: "self", "GET"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(V1Controller.Describe), controller: "V1"), rel: "version_1", "GET"),
                },
            };

            return response;
        }
    }
}
