//-----------------------------------------------------------------------
// <copyright file="PerformanceScenario{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System.Threading;

    /// <summary>
    ///     A delegate that represents a method which executes performance test and reports its results.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used to generate performance test input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    ///     Type of the performance test result.
    /// </typeparam>
    /// <param name="context">
    ///     A reference to the object which contains information about performance scenario esxecution.
    /// </param>
    /// <param name="cancellationToken">
    ///     An object which shall be monitored for a test cancellation request.
    /// </param>
    /// <returns>
    ///     Report of the performance test execution.
    /// </returns>
    public delegate MeasurementResult<TResult> PerformanceScenario<TSeed, TResult>(MeasurementContext<TSeed> context, CancellationToken cancellationToken);
}
