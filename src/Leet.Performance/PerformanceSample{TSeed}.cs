//-----------------------------------------------------------------------
// <copyright file="PerformanceSample{TSeed}.cs" company="Leet">
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
    public class PerformanceSample<TSeed>
    {
        /// <summary>
        ///     Holds a read-only reference to the performance measurement parameters.
        /// </summary>
        private readonly MeasurementParameters<TSeed> parameters;

        /// <summary>
        ///     Holds a read-only reference to the read-only list of execution times scored by the corresponding scenarios.
        /// </summary>
        private readonly IReadOnlyList<long> executionTimes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PerformanceSample{TSeed}"/> class.
        /// </summary>
        /// <param name="parameters">
        ///     Performance measurement parameters.
        /// </param>
        /// <param name="executionTimes">
        ///     Reference to the read-only list of execution times scored by the corresponding scenarios.
        /// </param>
        public PerformanceSample(MeasurementParameters<TSeed> parameters, IReadOnlyList<long> executionTimes)
        {
            this.parameters = parameters;
            this.executionTimes = executionTimes;
        }

        /// <summary>
        ///     Gets the performance measurement parameters.
        /// </summary>
        public MeasurementParameters<TSeed> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        /// <summary>
        ///     Gets the reference to the read-only list of execution times scored by the corresponding scenarios.
        /// </summary>
        public IReadOnlyList<long> ExecutionTimes
        {
            get
            {
                return this.executionTimes;
            }
        }
    }
}
