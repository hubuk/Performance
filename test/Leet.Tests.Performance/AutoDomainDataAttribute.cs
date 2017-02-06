﻿// -----------------------------------------------------------------------
// <copyright file="AutoDomainDataAttribute.cs" company="Leet">
//     Copyright (c) Leet. All rights reserved.
//     Licensed under the MIT License.
//     See License.txt in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Leet.Performance
{
    using Ploeh.AutoFixture.Xunit2;

    /// <summary>
    ///     Provides auto-generated data specimens generated by AutoFixture with
    ///     a domain related customizations as an extension to xUnit.net's Theory attribute.
    /// </summary>
    internal class AutoDomainDataAttribute : AutoDataAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoDomainDataAttribute"/> class.
        /// </summary>
        public AutoDomainDataAttribute()
            : base(new DomainFixture())
        {
        }
    }
}
