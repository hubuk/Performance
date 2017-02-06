//-----------------------------------------------------------------------
// <copyright file="NameContainsConvention.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class NameContainsConvention : NameConvention
    {
        public NameContainsConvention(string expected, bool value)
            : base(expected, value)
        {
        }

        protected override bool IsMatchCore(string name)
        {
            return name.IndexOf(this.Expected, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
