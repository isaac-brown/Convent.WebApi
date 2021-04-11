// <copyright file="VersionResponse.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    /// <summary>
    /// Represents version information.
    /// </summary>
    public class VersionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionResponse"/> class.
        /// </summary>
        /// <param name="applicationVersion">The application version.</param>
        /// <param name="dotnetVersion">The version of the dotnet runtime.</param>
        public VersionResponse(string applicationVersion, string dotnetVersion)
        {
            this.ApplicationVersion = applicationVersion;
            this.DotnetVersion = dotnetVersion;
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        public string ApplicationVersion { get; }

        /// <summary>
        /// Gets the version of the dotnet runtime.
        /// </summary>
        public string DotnetVersion { get; }
    }
}
