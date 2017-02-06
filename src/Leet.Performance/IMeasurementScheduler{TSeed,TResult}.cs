//-----------------------------------------------------------------------
// <copyright file="IMeasurementScheduler{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Handles execution of the performance scenario measurement.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used to generate performance test input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    ///     Type of the performance test result.
    /// </typeparam>
    public interface IMeasurementScheduler<TSeed,TResult>
    {
        /// <summary>
        ///     Queues a measurement of the specified scenario to the scheduler.
        /// </summary>
        /// <param name="scenario">
        ///     Performance scenario which measurement to be queued.
        /// </param>
        /// <param name="context">
        ///     Contains information about performance scenario execution.
        /// </param>
        /// <param name="cancellationToken">
        ///     An object which shall be monitored for a test cancellation request.
        /// </param>
        /// <returns>
        ///     A <see cref="Task{T}">Task&lt;MeasurementResult&lt;TResult>></see> that represents a queued measurement operation.
        /// </returns>
        Task<MeasurementResult<TResult>> QueueMeasurement(PerformanceScenario<TSeed, TResult> scenario, MeasurementContext<TSeed> context, CancellationToken cancellationToken);
    }
}
