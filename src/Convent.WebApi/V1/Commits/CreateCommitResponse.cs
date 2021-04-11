// <copyright file="CreateCommitResponse.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.V1.Commits
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the response body when creating a commit.
    /// </summary>
    public class CreateCommitResponse
    {
        /// <summary>
        /// Gets or sets the commit message.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the links related to this resource.
        /// </summary>
        [JsonPropertyName("_links")]
        public IEnumerable<LinkResponse> Links { get; set; } = Enumerable.Empty<LinkResponse>();
    }
}
