////-----------------------------------------------------------------------
//// <copyright file="ParallelMeasurementBalancer{TSeed,TResult}.cs" company="Leet">
////     © 2016 Leet. Licensed under the MIT License.
////     See License.txt in the project root for license information.
//// </copyright>
////-----------------------------------------------------------------------

//namespace Leet.Performance
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Threading;
//    using System.Threading.Tasks;

//    /// <summary>
//    ///     Balances performance measurement by queueing each scenario execution in parallel.
//    /// </summary>
//    /// <typeparam name="TSeed">
//    ///     Type of the seed object used to generate performance test input data.
//    /// </typeparam>
//    /// <typeparam name="TResult">
//    ///     Type of the performance test result.
//    /// </typeparam>
//    public abstract class ParallelMeasurementBalancer<TSeed, TResult> : IMeasurementBalancer<TSeed, TResult>
//    {
//        /// <summary>
//        ///     Holds a read-only reference to the performance scenario execution result comparer.
//        /// </summary>
//        private readonly IEqualityComparer<TResult> resultComparer;

//        /// <summary>
//        ///     Holds a read-only reference to the performance scenario measurement scheduler.
//        /// </summary>
//        private readonly IMeasurementScheduler<TSeed,TResult> scheduler;

//        /// <summary>
//        ///     Initializes a new instance of the <see cref="ParallelMeasurementBalancer{TSeed,TResult}"/> class.
//        /// </summary>
//        /// <param name="scheduler">
//        ///     Performance scenario measurement scheduler.
//        /// </param>
//        /// <param name="resultComparer">
//        ///     The performance scenario execution result comparer.
//        /// </param>
//        public ParallelMeasurementBalancer(IMeasurementScheduler<TSeed, TResult> scheduler, IEqualityComparer<TResult> resultComparer)
//        {
//            this.scheduler = scheduler;
//            this.resultComparer = resultComparer;
//        }
        
//        /// <summary>
//        ///     Initializes a new instance of the <see cref="ParallelMeasurementBalancer{TSeed,TResult}"/> class.
//        /// </summary>
//        /// <param name="scheduler">
//        ///     Performance scenario measurement scheduler.
//        /// </param>
//        public ParallelMeasurementBalancer(IMeasurementScheduler<TSeed, TResult> scheduler)
//            : this(scheduler, EqualityComparer<TResult>.Default)
//        {
//        }

//        private class Nullable<T>
//        {
//            public Nullable(T value)
//            {
//                this.value = value;
//            }
//            public T value;
//        }

//        /// <summary>
//        ///     Balances executes of performance scenario measurement.
//        /// </summary>
//        /// <param name="scenarios">
//        ///     A collection of performance scenarios to execute.
//        /// </param>
//        /// <param name="context">
//        ///     Contains information about performance scenario execution.
//        /// </param>
//        /// <param name="cancellationToken">
//        ///     An object which shall be monitored for a test cancellation request.
//        /// </param>
//        /// <returns>
//        ///     A measurement sample of each performance scenario execution.
//        /// </returns>
//        public MeasurementSample<TSeed> Execute(IReadOnlyList<PerformanceScenario<TSeed, TResult>> scenarios, MeasurementContext<TSeed> context, CancellationToken cancellationToken)
//        {
//            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

//            Nullable<TResult> lazy = null;

//            var tasks = scenarios.Select(scenario =>
//            {
//                return this.scheduler.QueueMeasurement(scenario, context, linkedTokenSource.Token).ContinueWith((Task<MeasurementResult<TResult>> task) =>
//                {
//                    if (task.IsCompleted)
//                    {
//                        var resultValue = task.Result.Result;
//                        Nullable<TResult> nullableResultValue = new Nullable<TResult>(resultValue);
//                        var firstResult = Interlocked.CompareExchange<Nullable<TResult>>(ref lazy, nullableResultValue, null);
//                        if (!object.ReferenceEquals(firstResult, null))
//                        {
//                            if (!this.resultComparer.Equals(nullableResultValue.value, firstResult.value))
//                            {
//                                linkedTokenSource.Cancel();
//                                throw new Exception("Result does not match");
//                            }
//                        }
//                    }

//                    if (task.IsFaulted)
//                    {
//                        linkedTokenSource.Cancel();
//                    }

//                    return task.Result.TicksElapsed;
//                });
//            });

//            var allTimes = Task.WhenAll(tasks);

//            return new MeasurementSample<TSeed>(context.Parameters, allTimes.Result.ToArray());
//        }
//    }
//}
