//-----------------------------------------------------------------------
// <copyright file="PerformanceReporterSpecification{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Specifications.Performance
{
    using Xunit;
    using Leet;
    using Leet.Performance;
    using Ploeh.AutoFixture;
    using System.Threading;
    using System;    

    /// <summary>
    ///     A class that specifies behavior for <see cref="PerformanceReporter{TSeed,TResult}"/> delegate.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used to generate performance test input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    ///     Type of the performance test result.
    /// </typeparam>
    public abstract class PerformanceReporterSpecification<TSutFactory,TSeed,TResult> : IDelegateFactory<PerformanceScenario<TSeed, TResult>>
        where TSutFactory : PerformanceReporterSpecification<TSutFactory, TSeed, TResult>, IDelegateFactory<PerformanceScenario<TSeed, TResult>>, new()
    {
        /// <summary>
        ///     Creates an instance of the delegate whick will act as a System Under Test (SUT).
        /// </summary>
        /// <returns>
        ///     An instance of the delegate whick will act as a System Under Test (SUT).
        /// </returns>
        public abstract PerformanceScenario<TSeed, TResult> CreateDelegate();
        
        /// <summary>
        ///     Tests exception thrown when passed generator is <see langword="null"/>.
        /// </summary>
        [Theory]
        [AutoDomainData]
        public void Invocation_WithNullContext_Throws(TSutFactory factory)
        {
            // Fixture setup
            IFixture fixture = DomainFixture.CreateFor(this);
            MeasurementContext<TSeed> context = null;
            CancellationToken cancellationToken = fixture.Create<CancellationToken>();
            PerformanceScenario<TSeed, TResult> sut = factory.CreateDelegate();
            
            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentNullException>(nameof(context), () =>
            {
                sut(context, cancellationToken);
            });

            // Teardown
        }

        /// <summary>
        ///     Tests exception thrown when called with requested cancellation.
        /// </summary>
        [Theory]
        [AutoDomainData]
        public void Invocation_WithCancellationRequested_Throws(TSutFactory factory)
        {
            // Fixture setup
            IFixture fixture = DomainFixture.CreateFor(this);
            MeasurementContext<TSeed> context = fixture.Create<MeasurementContext<TSeed>>();
            CancellationToken cancellationToken = new CancellationToken(true);
            PerformanceScenario<TSeed, TResult> sut = factory.CreateDelegate();

            // Exercise system
            // Verify outcome
            Assert.Throws<OperationCanceledException>(() =>
            {
                sut(context, cancellationToken);
            });

            // Teardown
        }
    }
}
