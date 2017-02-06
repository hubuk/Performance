//-----------------------------------------------------------------------
// <copyright file="ProgressPercentageBuilder.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

#if NET451
namespace Leet
{
    using Performance;
    using Ploeh.AutoFixture.Kernel;
    using System;
    using System.Reflection;

    /// <summary>
    ///     Customizes an <see cref="IFixture"/> by algorithm for generating parameters for <see cref="ProgressPercentage"/> constructor.
    /// </summary>
    public class ProgressPercentageBuilder : ISpecimenBuilder
    {
        /// <summary>
        ///     Holds a read-only reference to the random number generator.
        /// </summary>
        private readonly Random generator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProgressPercentageBuilder"/> class.
        /// </summary>
        public ProgressPercentageBuilder()
        {
            this.generator = new Random(0);
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
            var pi = request as ParameterInfo;
            if (object.ReferenceEquals(pi, null))
            {
                return new NoSpecimen();
            }

            var ci = pi.Member as ConstructorInfo;
            if (object.ReferenceEquals(ci, null))
            {
                return new NoSpecimen();
            }

            if (ci.GetParameters().Length != 0)
            {
                return new NoSpecimen();
            }

            if (pi.Member.DeclaringType != typeof(ProgressPercentage) ||
                pi.ParameterType != typeof(double) ||
                pi.Name != "value")
                return new NoSpecimen();

            return this.generator.NextDouble();
        }
    }
}
#endif