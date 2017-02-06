//-----------------------------------------------------------------------
// <copyright file="MeasurementResult{TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using Leet.Performance.Properties;

    /// <summary>
    ///     Represents a performance test execution measurement.
    /// </summary>
    /// <typeparam name="TResult">
    ///     Type of the performance test return value.
    /// </typeparam>
    public class MeasurementResult<TResult>
    {
        /// <summary>
        ///     Holds a read-only performance test result.
        /// </summary>
        private readonly TResult result;

        /// <summary>
        ///     Holds a read-only number of ticks that the performance test execution took.
        /// </summary>
        private readonly long ticksElapsed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MeasurementResult{TResult}"/> class.
        /// </summary>
        /// <param name="result">
        ///     The performance test result.
        /// </param>
        /// <param name="ticksElapsed">
        ///     Number of ticks that the performance test execution took.
        /// </param>
        public MeasurementResult(TResult result, long ticksElapsed)
        {
            if (ticksElapsed < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ticksElapsed), ticksElapsed, Resources.Exception_ArgumentOutOfRange_TicksElapsed);
            }

            this.result = result;
            this.ticksElapsed = ticksElapsed;
        }

        /// <summary>
        ///     Gets the performance test result.
        /// </summary>
        public TResult Result
        {
            get
            {
                return this.result;
            }
        }

        /// <summary>
        ///     Gets the number of ticks that the performance test execution took.
        /// </summary>
        public long TicksElapsed
        {
            get
            {
                return this.ticksElapsed;
            }
        }
    }
}
