//-----------------------------------------------------------------------
// <copyright file="DomainCustomization.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using Leet;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;

    /// <summary>
    ///     Customizes an <see cref="IFixture"/> by using customizations related to current domain.
    /// </summary>
    internal class DomainCustomization : DomainCustomizationBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DomainCustomization"/> class.
        /// </summary>
        public DomainCustomization()
            : base(new AutoNSubstituteCustomization(), new ProgressPercentageDoubleCustomization())
        {
        }
    }
}
