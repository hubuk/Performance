//-----------------------------------------------------------------------
// <copyright file="MeasurementSummary{TSeed}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System.Collections.Generic;

    /// <summary>
    ///     A comparison of execution performance result of multiple performance scenarios.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used to generate performance test input data.
    /// </typeparam>
    public class MeasurementSummary<TSeed>
    {
        /// <summary>
        ///     Holds a read-only reference to the read-only list of various performacne comparison runs.
        /// </summary>
        private readonly IReadOnlyList<PerformanceSample<TSeed>> samples;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MeasurementSummary{TSeed}"/> class.
        /// </summary>
        /// <param name="samples">
        ///     List of various performacne comparison runs.
        /// </param>
        public MeasurementSummary(IReadOnlyList<PerformanceSample<TSeed>> samples)
        {
            this.samples = samples;
        }

        /// <summary>
        ///     Gets the read-only list of various performacne comparison runs.
        /// </summary>
        public IReadOnlyList<PerformanceSample<TSeed>> Samples
        {
            get
            {
                return this.samples;
            }
        }
    }
}
