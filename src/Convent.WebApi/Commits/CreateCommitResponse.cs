// <copyright file="CreateCommitResponse.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.Commits
{
    /// <summary>
    /// Represents the response body when creating a commit.
    /// </summary>
    public class CreateCommitResponse
    {
        /// <summary>
        /// Gets or sets the commit message.
        /// </summary>
        public string Message { get; set; }
    }
}