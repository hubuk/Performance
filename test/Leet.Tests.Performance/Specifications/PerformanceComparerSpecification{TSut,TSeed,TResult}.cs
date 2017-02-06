//-----------------------------------------------------------------------
// <copyright file="PerformanceComparerSpecification{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Specifications.Performance
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Leet.Performance;
    using Ploeh.AutoFixture;
    using Xunit;

    /// <summary>
    ///     A class that specifies behavior for <see cref="PerformanceComparer{TSeed,TResult}"/> delegate.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used to generate performance test input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    ///     Type of the performance test result.
    /// </typeparam>
    public abstract class PerformanceComparerSpecification<TSeed, TResult>
    {
        //[Theory]
        //[AutoDomainData]
        //public void Constructor_WithNullParametrizer_Throws(ISampler<TSeed, TResult> sampler)
        //{
        //    // Fixture setup
        //    IParametrizer<TSeed> parametrizer = null;

        //    // Exercise system
        //    // Verify outcome
        //    Assert.Throws<ArgumentNullException>(nameof(parametrizer), () =>
        //    {
        //        new PerformanceComparer<TSeed, TResult>(parametrizer, sampler);
        //    });

        //    // Teardown
        //}

        //[Theory]
        //[AutoDomainData]
        //public void Constructor_WithNullBalancer_Throws(IParametrizer<TSeed> parametrizer)
        //{
        //    // Fixture setup
        //    ISampler<TSeed, TResult> sampler = null;

        //    // Exercise system
        //    // Verify outcome
        //    Assert.Throws<ArgumentNullException>(nameof(sampler), () =>
        //    {
        //        new PerformanceComparer<TSeed, TResult>(parametrizer, sampler);
        //    });

        //    // Teardown
        //}

        //[Theory]
        //[AutoDomainData]
        //public void Constructor_WithNullParametrizerAndBalancer_Throws()
        //{
        //    // Fixture setup
        //    IParametrizer<TSeed> parametrizer = null;
        //    ISampler<TSeed, TResult> sampler = null;

        //    // Exercise system
        //    // Verify outcome
        //    Assert.Throws<ArgumentNullException>(nameof(parametrizer), () =>
        //    {
        //        new PerformanceComparer<TSeed, TResult>(parametrizer, sampler);
        //    });

        //    // Teardown
        //}

        //[Theory]
        //[AutoDomainData]
        //public void Constructor_Always_AssignsFields(IParametrizer<TSeed> parametrizer, ISampler<TSeed, TResult> sampler)
        //{
        //    // Fixture setup
        //    // Exercise system
        //    var sut = new PerformanceComparer<TSeed, TResult>(parametrizer, sampler);

        //    // Verify outcome
        //    Assert.Same(parametrizer, sut.Parametrizer);
        //    Assert.Same(sampler, sut.Sampler);

        //    // Teardown
        //}

        [Theory]
        [AutoDomainData]
        public void Compare_WithNullScenarios_Throws(PerformanceComparer<TSeed, TResult> sut)
        {
            // Fixture setup
            DomainFixture fixture = new DomainFixture();
            IReadOnlyList<PerformanceScenario<TSeed, TResult>> scenarios = null;
            CancellationToken cancellationToken = fixture.Create<CancellationToken>();
            IProgress<ProgressPercentage> progress = fixture.Create<IProgress<ProgressPercentage>>();

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentNullException>(nameof(scenarios), () =>
            {
                sut.Compare(scenarios, cancellationToken, progress);
            });

            // Teardown
        }

        [Theory]
        [AutoDomainData]
        public void Compare_WithEmptyScenarios_Throws(PerformanceComparer<TSeed, TResult> sut)
        {
            // Fixture setup
            DomainFixture fixture = new DomainFixture();
            IReadOnlyList<PerformanceScenario<TSeed, TResult>> scenarios = new PerformanceScenario<TSeed, TResult>[0];
            CancellationToken cancellationToken = fixture.Create<CancellationToken>();
            IProgress<ProgressPercentage> progress = fixture.Create<IProgress<ProgressPercentage>>();

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentException>(nameof(scenarios), () =>
            {
                sut.Compare(scenarios, cancellationToken, progress);
            });

            // Teardown
        }

        [Theory]
        [AutoDomainData]
        public void Compare_WithNullScenario_Throws(PerformanceComparer<TSeed, TResult> sut, PerformanceScenario<TSeed, TResult>[] scenarios)
        {
            // Fixture setup
            DomainFixture fixture = new DomainFixture();
            int nullIndex = fixture.Create<int>() % scenarios.Length;
            scenarios[nullIndex] = null;
            CancellationToken cancellationToken = fixture.Create<CancellationToken>();
            IProgress<ProgressPercentage> progress = fixture.Create<IProgress<ProgressPercentage>>();

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentException>(nameof(scenarios), () =>
            {
                sut.Compare(scenarios, cancellationToken, progress);
            });

            // Teardown
        }

        ///// <summary>
        /////     Tests exception thrown when passed generator is <see langword="null"/>.
        ///// </summary>
        //[Theory]
        //[AutoDomainData]
        //public void Invocation_WithNullContext_Throws(TSutFactory factory)
        //{
        //    // Fixture setup
        //    IFixture fixture = new DomainFixture();
        //    var parametersCollection = fixture.Create<IEnumerable<MeasurementParameters<TSeed>>>();
        //    var balancer = fixture.Create<IMeasurementBalancer<TSeed, TResult>>();
        //    PerformanceComparer<TSeed, TResult> comparer = new PerformanceComparer<TSeed, TResult>(parametersCollection, balancer);

        //    // Exercise system
        //    // Verify outcome
        //    Assert.Equal(.Throws<ArgumentNullException>(nameof(context), () =>
        //    {
        //        sut(context, cancellationToken);
        //    });

        //    // Teardown
        //}
    }
}
