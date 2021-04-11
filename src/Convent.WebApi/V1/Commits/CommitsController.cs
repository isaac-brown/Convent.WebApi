// <copyright file="CommitsController.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.V1.Commits
{
    using Convent.Commits;
    using Convent.WebApi;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides HTTP methods for working with commit resources.
    /// </summary>
    [ApiController]
    [Route("api/v1/commits")]
    public class CommitsController : ControllerBase
    {
        private readonly ConventionalCommitMessageFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommitsController"/> class.
        /// </summary>
        public CommitsController()
        {
            this.factory = new ConventionalCommitMessageFactory();
        }

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
                    new LinkResponse(this.Url.ActionLink(action: nameof(V1Controller.Describe), controller: "V1"), rel: "parent", method: "GET"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(this.Describe)), rel: "self", method: "GET"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(this.CreateChore)), rel: "create_chore_commit", method: "POST"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(this.CreateDocumentation)), rel: "create_documentation_commit", method: "POST"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(this.CreateFeature)), rel: "create_feature_commit", method: "POST"),
                    new LinkResponse(this.Url.ActionLink(action: nameof(this.CreateFix)), rel: "create_fix_commit", method: "POST"),
                },
            };

            return response;
        }

        /// <summary>
        /// Creates a single feature commit message.
        /// </summary>
        /// <param name="request">The request to create a commit message.</param>
        /// <returns>A new <see cref="CreateCommitResponse"/>.</returns>
        [HttpPost]
        [Route("feature")]
        public ActionResult<CreateCommitResponse> CreateFeature([FromBody] CreateCommitRequest request)
        {
            CommitType commitType = CommitType.Feature;
            return this.CreateTypedCommit(request, commitType);
        }

        /// <summary>
        /// Creates a single fix commit message.
        /// </summary>
        /// <param name="request">The request to create a commit message.</param>
        /// <returns>A new <see cref="CreateCommitResponse"/>.</returns>
        [HttpPost]
        [Route("fix")]
        public ActionResult<CreateCommitResponse> CreateFix([FromBody] CreateCommitRequest request)
        {
            CommitType commitType = CommitType.Fix;
            return this.CreateTypedCommit(request, commitType);
        }

        /// <summary>
        /// Creates a single chore commit message.
        /// </summary>
        /// <param name="request">The request to create a commit message.</param>
        /// <returns>A new <see cref="CreateCommitResponse"/>.</returns>
        [HttpPost]
        [Route("chore")]
        public ActionResult<CreateCommitResponse> CreateChore([FromBody] CreateCommitRequest request)
        {
            CommitType commitType = CommitType.Chore;
            return this.CreateTypedCommit(request, commitType);
        }

        /// <summary>
        /// Create a single documentation commit message.
        /// </summary>
        /// <param name="request">The request to create a commit message.</param>
        /// <returns>A new <see cref="CreateCommitResponse"/>.</returns>
        [HttpPost]
        [Route("documentation")]
        public ActionResult<CreateCommitResponse> CreateDocumentation([FromBody] CreateCommitRequest request)
        {
            CommitType commitType = ExtendedCommitType.Documentation;
            return this.CreateTypedCommit(request, commitType);
        }

        private CreateCommitResponse CreateTypedCommit(CreateCommitRequest request, CommitType commitType)
        {
            var options = request.ToCommitMessageOptions();
            var message = this.factory.CreateCommitMessage(commitType, options);
            var response = new CreateCommitResponse
            {
                Message = message,
            };
            HttpRequest httpRequest = this.HttpContext.Request;
            response.Links = new[]
            {
                new LinkResponse(href: this.Url.ActionLink(nameof(this.Describe)), rel: "parent", method: "GET"),
                new LinkResponse(
                    href: $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.Path}",
                    rel: "self",
                    method: "GET"),
            };
            return response;
        }
    }
}
