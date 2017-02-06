//-----------------------------------------------------------------------
// <copyright file="ISampler{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    ///     Provides a mechanism for collecting performance measurement samples of the performance scenarios.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used to generate performance test input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    ///     Type of the performance test result.
    /// </typeparam>
    public interface ISampler<TSeed,TResult>
    {
        /// <summary>
        ///     Collects performance samples of the specified performance scenarios.
        /// </summary>
        /// <param name="scenarios">
        ///     A collection of performance scenarios to execute.
        /// </param>
        /// <param name="context">
        ///     Contains information about performance scenario execution.
        /// </param>
        /// <param name="cancellationToken">
        ///     An object which shall be monitored for a test cancellation request.
        /// </param>
        /// <returns>
        ///     A performance sample of each performance scenario execution.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="scenarios"/> or <paramref name="context"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="scenarios"/> is empty or contains <see langword="null"/> element.
        /// </exception>
        /// <exception cref="ResultMismatchException">
        ///     At least two scenarios produced different result.
        /// </exception>
        PerformanceSample<TSeed> Collect(IReadOnlyList<PerformanceScenario<TSeed, TResult>> scenarios, MeasurementContextFactory<TSeed> contextFactory, CancellationToken cancellationToken);
    }
}
