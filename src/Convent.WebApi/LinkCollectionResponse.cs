// <copyright file="LinkCollectionResponse.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a collection of links to one or more resources.
    /// </summary>
    public class LinkCollectionResponse
    {
        /// <summary>
        /// Gets or sets the links related to a resource.
        /// </summary>
        [JsonPropertyName("_links")]
        public IEnumerable<LinkResponse> Links { get; set; } = Enumerable.Empty<LinkResponse>();
    }
}
