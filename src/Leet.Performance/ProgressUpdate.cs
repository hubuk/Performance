//-----------------------------------------------------------------------
// <copyright file="ProgressUpdate.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;

    /// <summary>
    ///     Provides mechanism for automatic calculation of prgoress increase.
    /// </summary>
    internal class ProgressUpdate : IProgress<ProgressPercentage>
    {
        /// <summary>
        ///     Holds a read-only reference to the destination progress updates receiver.
        /// </summary>
        private readonly IProgress<ProgressPercentageIncrease> receiver;

        /// <summary>
        ///     Holds a current opertaion progress value.
        /// </summary>
        private ProgressPercentage currentProgress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProgressUpdate"/> class.
        /// </summary>
        /// <param name="receiver">
        ///     Destination progress updates receiver.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="receiver"/> is <see langword="null"/>.
        /// </exception>
        public ProgressUpdate(IProgress<ProgressPercentageIncrease> receiver)
        {
            if (object.ReferenceEquals(receiver, null))
            {
                throw new ArgumentNullException(nameof(receiver));
            }

            this.receiver = receiver;
            this.currentProgress = ProgressPercentage.Zero;
        }

        /// <summary>
        ///     Gets a current progress value.
        /// </summary>
        public ProgressPercentage CurrentProgress
        {
            get
            {
                return this.currentProgress;
            }
        }

        /// <summary>
        ///     Reports a progress update.
        /// </summary>
        /// <param name="value">
        ///     The value of the updated progress.
        /// </param>
        void IProgress<ProgressPercentage>.Report(ProgressPercentage value)
        {
            ProgressPercentage previousProgress = this.currentProgress;
            this.currentProgress = value;
            this.receiver.Report(new ProgressPercentageIncrease(previousProgress, this.currentProgress));
        }
    }
}
