//-----------------------------------------------------------------------
// <copyright file="MeasurementContext{TSeed}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;

    /// <summary>
    ///     Contains information about performance scenario execution.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used by performance scenario.
    /// </typeparam>
    public class MeasurementContext<TSeed> : IGenerator, IProgress<ProgressPercentage>
    {
        /// <summary>
        ///     Holds a read-only seed that may be used by the performance scenario.
        /// </summary>
        private readonly MeasurementParameters<TSeed> parameters;

        /// <summary>
        ///     Holds a read-only reference to the test object generator factory.
        /// </summary>
        private readonly IGenerator generator;

        /// <summary>
        ///     Holds a read-only reference to the measurement progress reporter.
        /// </summary>
        private readonly IProgress<ProgressPercentage> progress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MeasurementContext{TSeed}"/> class.
        /// </summary>
        /// <param name="parameters">
        ///     Performance scenario parameters.
        /// </param>
        /// <param name="seed">
        ///     Seed that may be used by the performance scenario.
        /// </param>
        /// <param name="generator">
        ///     Test object generator.
        /// </param>
        /// <param name="progress">
        ///     Measurement progress reporter.
        /// </param>
        public MeasurementContext(MeasurementParameters<TSeed> parameters, IGenerator generator, IProgress<ProgressPercentage> progress)
        {
            if (object.ReferenceEquals(parameters, null))
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (object.ReferenceEquals(generator, null))
            {
                throw new ArgumentNullException(nameof(generator));
            }

            this.parameters = parameters;
            this.generator = generator;
            this.progress = progress;
        }

        /// <summary>
        ///     Gets a parameters for the performance scenario measurement.
        /// </summary>
        public MeasurementParameters<TSeed> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        /// <summary>
        ///     Returns an object of the specified type <typeparamref name="T"/> based on a specified <paramref name="seed"/>.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the object to obtain.
        /// </typeparam>
        /// <param name="seed">
        ///     A seed for the generation algorithm.
        /// </param>
        /// <returns>
        ///     An object of the specified type <typeparamref name="T"/> based on a specified <paramref name="seed"/>.
        /// </returns>
        /// <remarks>
        ///     Calling this method with the same seed multiple time shall generate same result each time.
        /// </remarks>
        public T Generate<T>(T seed)
        {
            return this.generator.Generate<T>(seed);
        }
        
        /// <summary>
        ///     Reports a progress update.
        /// </summary>
        /// <param name="value">
        ///     The value of the updated progress.
        /// </param>
        public void Report(ProgressPercentage value)
        {
            this.progress.Report(value);
        }
    }
}
