//-----------------------------------------------------------------------
// <copyright file="ProgressPercentageDoubleCustomization.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

#if NET451
namespace Leet
{
    using System;
    using Conventions;
    using Ploeh.AutoFixture.Kernel;

    /// <summary>
    ///     Customizes an <see cref="IFixture"/> by algorithm for generating <see cref="double"/> values used in <see cref="ProgressPercentage"/> construction.
    /// </summary>
    public class ProgressPercentageDoubleCustomization : ISpecimenBuilder
    {
        /// <summary>
        ///     Holds a read-only reference to the random number generator.
        /// </summary>
        private readonly Random generator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProgressPercentageDoubleCustomization"/> class.
        /// </summary>
        public ProgressPercentageDoubleCustomization()
        {
            this.generator = new Random();
        }

        /// <summary>
        ///     Creates a new specimen based on a request.
        /// </summary>
        /// <param name="request">
        ///     The request that describes what to create.
        /// </param>
        /// <param name="context">
        ///     A context that can be used to create other specimens.
        /// </param>
        /// <returns>
        ///     The requested specimen if possible; otherwise a <see cref="NoSpecimen"/> instance.
        /// </returns>
        /// <remarks>
        ///     The request can be any object, but will often be a <see cref="Type"/> or other <see cref="MemberInfo"/> instances.
        ///     <para/>
        ///     Note to implementers: Implementations are expected to return a <see cref="NoSpecimen"/> instance if they can't satisfy the request.
        /// </remarks>
        public object Create(object request, ISpecimenContext context)
        {
            if (ProgressPercentageDoubleConvention.Matches(request))
            {
                double result = this.generator.NextDouble();
                if (result.Equals(0d))
                {
                    return double.Epsilon;
                }

                return result;
            }

            return new NoSpecimen();
        }
    }
}
#endif