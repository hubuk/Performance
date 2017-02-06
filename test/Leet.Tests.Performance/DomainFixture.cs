//-----------------------------------------------------------------------
// <copyright file="DomainFixture.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using System;

    /// <summary>
    ///     Provides anonymous object creation services with current domain customizations.
    /// </summary>
    internal class DomainFixture : Fixture
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DomainFixture"/> class.
        /// </summary>
        public DomainFixture()
        {
            this.Customize(new DomainCustomization());
            this.Customizations.Add(new ProgressPercentageBuilder());
            this.Customizations.Add(new ProgressPercentageDoubleCustomization());
        }
    }
}
