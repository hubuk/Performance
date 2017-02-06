//-----------------------------------------------------------------------
// <copyright file="ComparisonProgress.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using Properties;

    /// <summary>
    ///     Provides a mechanism for calculating progression of the performance comparison.
    /// </summary>
    public class ComparisonProgress : IProgress<ProgressPercentage>, IProgress<ProgressPercentageIncrease>
    {
        /// <summary>
        ///     Holds a read-only reference to the progress reporter that will receive final progress calculations.
        /// </summary>
        private readonly IProgress<ProgressPercentage> reporter;

        /// <summary>
        ///     Holds a read-only number of the measured performance scenarios.
        /// </summary>
        private readonly int scenarioCount;

        /// <summary>
        ///     Holds a read-only reference to the object used in synchroniztion of access to progress reporter.
        /// </summary>
        private readonly object synchronizationLock = new object();

        /// <summary>
        ///     Holds a value of the current parameter generation progress.
        /// </summary>
        private ProgressPercentageIncrease generationProgressIncrease;

        /// <summary>
        ///     Holds a value of the current performance scenario measurement progress.
        /// </summary>
        private double currentMeasurementProgress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComparisonProgress"/> class.
        /// </summary>
        /// <param name="reporter">
        ///     An progress reporter that will receive final progress calculations.
        /// </param>
        /// <param name="scenarioCount">
        ///     Number of performance scenarios compared.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reporter"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="scenarioCount"/> is less than or equal to zero.
        /// </exception>
        public ComparisonProgress(IProgress<ProgressPercentage> reporter, int scenarioCount)
        {
            if (object.ReferenceEquals(reporter, null))
            {
                throw new ArgumentNullException(nameof(reporter));
            }

            if (scenarioCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(scenarioCount), scenarioCount, Resources.Exception_ArgumentOutOfRange_ScenarioCountNonPositive);
            }

            this.reporter = reporter;
            this.scenarioCount = scenarioCount;
        }

        /// <summary>
        ///     Reports a parameters generation progress update.
        /// </summary>
        /// <param name="value">
        ///     The value of the updated progress.
        /// </param>
        void IProgress<ProgressPercentage>.Report(ProgressPercentage value)
        {
            lock (this.synchronizationLock)
            {
                this.generationProgressIncrease = new ProgressPercentageIncrease(this.generationProgressIncrease.CurrnetProgress, value);
                this.currentMeasurementProgress = ProgressPercentage.Zero;

                this.ReportOverall();
            }
        }

        /// <summary>
        ///     Reports a performance scenario measurement progress update.
        /// </summary>
        /// <param name="value">
        ///     The value of the updated progress.
        /// </param>
        void IProgress<ProgressPercentageIncrease>.Report(ProgressPercentageIncrease value)
        {
            lock (this.synchronizationLock)
            {
                this.currentMeasurementProgress += value.Increase / this.scenarioCount;
                this.ReportOverall();
            }
        }

        /// <summary>
        ///     Reports overall progress to the assigned progress reporter.
        /// </summary>
        private void ReportOverall()
        {
            this.reporter.Report(this.generationProgressIncrease.PreviousProgress + (this.generationProgressIncrease.Increase) * this.currentMeasurementProgress);
        }
    }
}
