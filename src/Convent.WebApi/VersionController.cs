// <copyright file="VersionController.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides methods for getting version information.
    /// </summary>
    public class VersionController : ControllerBase
    {
        /// <summary>
        /// Gets version information.
        /// </summary>
        /// <returns>A new <see cref="VersionResponse"/>.</returns>
        [Route("api/version")]
        [HttpGet]
        public ActionResult<VersionResponse> GetVersion()
        {
            string version = this.GetType().Assembly.GetName().Version!.ToString();
            string dotnetVersion = Environment.Version.ToString();

            return new VersionResponse(applicationVersion: version, dotnetVersion: dotnetVersion);
        }
    }
}
