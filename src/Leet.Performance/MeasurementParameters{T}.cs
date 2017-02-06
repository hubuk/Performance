//-----------------------------------------------------------------------
// <copyright file="MeasurementParameters{T}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using Properties;

    /// <summary>
    ///     Carries parameters for the performance measurement.
    /// </summary>
    /// <typeparam name="TSeed">
    ///     Type of the seed object used by performance scenario.
    /// </typeparam>
    public class MeasurementParameters<T>
    {
        /// <summary>
        ///     Holds a read-only requested number of single performance scenario executions.
        /// </summary>
        private readonly long repetitions;

        /// <summary>
        ///     Holds a read-only seed that may be used by the performance scenario.
        /// </summary>
        private readonly T parameter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MeasurementParameters{TSeed}"/> class.
        /// </summary>
        /// <param name="repetitions">
        ///     Requested number of single performance scenario executions.
        /// </param>
        /// <param name="seed">
        ///     Seed that may be used by the performance scenario.
        /// </param>
        public MeasurementParameters(long repetitions, T parameter)
        {
            if (repetitions < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repetitions), repetitions, Resources.Exception_ArgumentOutOfRange_RepetitionsNonPositive);
            }

            if (object.ReferenceEquals(parameter, null))
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            this.repetitions = repetitions;
            this.parameter = parameter;
        }

        /// <summary>
        ///     Holds a read-only requested number of single performance scenario executions.
        /// </summary>
        public long Repetitions
        {
            get
            {
                return this.repetitions;
            }
        }

        /// <summary>
        ///     Holds a read-only seed that may be used by the performance scenario.
        /// </summary>
        public T Parameter
        {
            get
            {
                return this.parameter;
            }
        }
    }
}
