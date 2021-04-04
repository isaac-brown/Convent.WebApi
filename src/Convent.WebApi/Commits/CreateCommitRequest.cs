// <copyright file="CreateCommitRequest.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.Commits
{
    using Convent.Commits;

    /// <summary>
    /// Represents the request body when creating a commit.
    /// </summary>
    public class CreateCommitRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not a scope should be included in a commit message.
        /// Default is false.
        /// </summary>
        public bool HasScope { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether or not a scope should be included in a commit message.
        /// Default is false.
        /// </summary>
        public bool HasBody { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether or not a scope should be included in a commit message.
        /// Default is false.
        /// </summary>
        public bool HasIssue { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether or not a scope should be included in a commit message.
        /// Default is false.
        /// </summary>
        public bool HasBreakingChange { get; set; } = false;

        /// <summary>
        /// Maps this instance to a new <see cref="CommitMessageOptions"/> instance.
        /// </summary>
        /// <returns>A new <see cref="CommitMessageOptions"/> instance.</returns>
        public CommitMessageOptions ToCommitMessageOptions()
        {
            return new CommitMessageOptions
            {
                HasBody = this.HasBody,
                HasBreakingChange = this.HasBreakingChange,
                HasIssue = this.HasIssue,
                HasScope = this.HasScope,
            };
        }
    }
}