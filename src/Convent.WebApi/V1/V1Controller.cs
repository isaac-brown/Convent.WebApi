// <copyright file="V1Controller.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.V1
{
    using Convent.WebApi.V1.Commits;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for version 1 resources.
    /// </summary>
    [ApiController]
    [Route("api/v1")]
    public class V1Controller : ControllerBase
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
                    new LinkResponse(this.Url.ActionLink(action: nameof(ApiController.Describe), controller: "Api"), rel: "parent", "GET"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(CommitsController.Describe), controller: "Commits"), rel: "commits", "GET"),
                },
            };

            return response;
        }
    }
}
