// <copyright file="LinkResponse.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    /// <summary>
    /// Represents a link to a single resource.
    /// </summary>
    public class LinkResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkResponse"/> class.
        /// </summary>
        /// <param name="href">The url to the resource.</param>
        /// <param name="rel">The relation of the link.</param>
        /// <param name="method">The HTTP method used to request the link.</param>
        public LinkResponse(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }

        /// <summary>
        /// Gets the url to the resource.
        /// </summary>
        public string Href { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the relation of the resource to the another resource.
        /// </summary>
        public string Rel { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the HTTP method used to request the resource.
        /// </summary>
        public string Method { get; private set; } = string.Empty;
    }
}
