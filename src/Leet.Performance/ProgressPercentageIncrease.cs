//-----------------------------------------------------------------------
// <copyright file="ProgressPercentageIncrease.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public struct ProgressPercentageIncrease
    {
        private readonly ProgressPercentage previousProgress;
        private readonly ProgressPercentage currnetProgress;

        public ProgressPercentageIncrease(ProgressPercentage previousProgress, ProgressPercentage currnetProgress)
        {
            this.previousProgress = previousProgress;
            this.currnetProgress = currnetProgress;
        }

        public ProgressPercentage PreviousProgress
        {
            get
            {
                return this.previousProgress;
            }
        }
        public ProgressPercentage CurrnetProgress
        {
            get
            {
                return this.currnetProgress;
            }
        }

        public ProgressPercentage Increase
        {
            get
            {
                return this.currnetProgress - previousProgress;
            }
        }
    }
}
