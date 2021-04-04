// <copyright file="CommitsController.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.Commits
{
    using Convent.Commits;
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

        [HttpPost]
        [Route("documentation")]
        public ActionResult<CreateCommitResponse> CreateDocumentation([FromBody] CreateCommitRequest request)
        {
            CommitType commitType = MyCommitType.Documentation;
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
            return response;
        }
    }

    class MyCommitType : CommitType
    {
        public MyCommitType(string name)
            : base(name)
        {
        }

        public static CommitType Documentation => new MyCommitType("docs");
    }
}