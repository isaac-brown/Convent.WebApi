// <copyright file="ExtendedCommitType.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi.V1.Commits
{
    using Convent.Commits;

    /// <summary>
    /// Extended <see cref="CommitType"/>.
    /// </summary>
    internal class ExtendedCommitType : CommitType
    {
        private ExtendedCommitType(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Gets a commit type which represents modifying documentation.
        /// </summary>
        public static CommitType Documentation => new ExtendedCommitType("docs");
    }
}
