//-----------------------------------------------------------------------
// <copyright file="PerformanceComparer{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using Properties;

    /// <summary>
    ///     Provides a mechanism for algorithms comparison.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used by performance scenario.
    /// </typeparam>
    /// <typeparam name="TResult">
    ///     Type of the performance test result.
    /// </typeparam>
    public class PerformanceComparer<TSeed, TResult>
    {
        /// <summary>
        ///     Holds a read-only reference to the performance measurement parameterizer.
        /// </summary>
        private readonly IParametrizer<TSeed> parametrizer;

        /// <summary>
        ///     Holds a read-only reference to the performance measurement sampler.
        /// </summary>
        private readonly ISampler<TSeed, TResult> sampler;

        /// <summary>
        ///     Holds a read-only reference to the performance scenario objects generator factory.
        /// </summary>
        private readonly IGeneratorFactory generatorFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PerformanceComparer{TSeed,TResult}"/> class.
        /// </summary>
        /// <param name="parametrizer">
        ///     An object that provides parameters for performance scenarios.
        /// </param>
        /// <param name="balancer">
        ///     Performance measurement execution sampler.
        /// </param>
        /// <param name="generatorFactory">
        ///     Performance scenario objects generator factory.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="parametrizer"/>, <paramref name="balancer"/> or <paramref name="generatorFactory"/> is <see langword="null"/>.
        /// </exception>
        public PerformanceComparer(IParametrizer<TSeed> parametrizer, ISampler<TSeed, TResult> sampler, IGeneratorFactory generatorFactory)
        {
            if (object.ReferenceEquals(parametrizer, null))
            {
                throw new ArgumentNullException(nameof(parametrizer));
            }

            if (object.ReferenceEquals(sampler, null))
            {
                throw new ArgumentNullException(nameof(sampler));
            }

            if (object.ReferenceEquals(sampler, null))
            {
                throw new ArgumentNullException(nameof(generatorFactory));
            }

            this.parametrizer = parametrizer;
            this.sampler = sampler;
            this.generatorFactory = generatorFactory;
        }

        /// <summary>
        ///     Gets a reference to the performance measurement parameterizer.
        /// </summary>
        public IParametrizer<TSeed> Parametrizer
        {
            get
            {
                return this.parametrizer;
            }
        }

        /// <summary>
        ///     Gets a reference to the performance measurement sampler.
        /// </summary>
        public ISampler<TSeed, TResult> Sampler
        {
            get
            {
                return this.sampler;
            }
        }

        /// <summary>
        ///     Gets a reference to the performance scenario objects generator factory.
        /// </summary>
        public IGeneratorFactory GeneratorFactory
        {
            get
            {
                return this.generatorFactory;
            }
        }

        /// <summary>
        ///     Compares specified scenarios performance.
        /// </summary>
        /// <param name="scenarios">
        ///     A collection of performance scenarios to compare.
        /// </param>
        /// <param name="cancellationToken">
        ///     Comparison cancellation token.
        /// </param>
        /// <param name="progress">
        ///     Used to report comparison prgoress.
        /// </param>
        /// <returns>
        ///     A measurement summary.
        /// </returns>
        /// <exception cref="OperationCanceledException">
        ///     Comparison has been canceled.
        /// </exception>
        public MeasurementSummary<TSeed> Compare(IReadOnlyList<PerformanceScenario<TSeed, TResult>> scenarios, CancellationToken cancellationToken, IProgress<ProgressPercentage> progress)
        {
            if (object.ReferenceEquals(scenarios, null))
            {
                throw new ArgumentNullException(nameof(scenarios));
            }
            
            if (scenarios.Count == 0)
            {
                throw new ArgumentException(Resources.Exception_Argument_NullList, nameof(scenarios));
            }

            if (scenarios.Contains(null))
            {
                throw new ArgumentException(Resources.Exception_Argument_NullListItem, nameof(scenarios));
            }

            List<PerformanceSample<TSeed>> samples = new List<PerformanceSample<TSeed>>();
            ComparisonProgress comparisonProgress = new ComparisonProgress(progress, scenarios.Count);
            
            foreach (MeasurementParameters<TSeed> parameters in this.parametrizer.GetParameters(comparisonProgress))
            {
                cancellationToken.ThrowIfCancellationRequested();
                var contextFactory = new MeasurementContextFactory<TSeed>(parameters, comparisonProgress, this.generatorFactory);
                // 1. create context factory with a generator factory and multiplier progress and pass it.
                var sample = this.sampler.Collect(scenarios, contextFactory, cancellationToken);
                samples.Add(sample);
            }

            return new MeasurementSummary<TSeed>(new ReadOnlyCollection<PerformanceSample<TSeed>>(samples));
        }
    }
}
