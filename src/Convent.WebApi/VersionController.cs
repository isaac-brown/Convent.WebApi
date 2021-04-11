// <copyright file="VersionController.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    using System;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides methods for getting version information.
    /// </summary>
    public class VersionController : ControllerBase
    {
        private readonly VersionResponse versionResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionController"/> class.
        /// </summary>
        public VersionController()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
            string dotnetVersion = Environment.Version.ToString();

            this.versionResponse = new VersionResponse(applicationVersion: version, dotnetVersion: dotnetVersion);
        }

        /// <summary>
        /// Gets version information.
        /// </summary>
        /// <returns>A new <see cref="VersionResponse"/>.</returns>
        [Route("api/version")]
        [HttpGet]
        public ActionResult<VersionResponse> GetVersion()
        {
            return this.versionResponse;
        }
    }
}
