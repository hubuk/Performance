//-----------------------------------------------------------------------
// <copyright file="IGeneratorFactory.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    /// <summary>
    ///     A factory for <see cref="IGenerator"/> interface.
    /// </summary>
    public interface IGeneratorFactory
    {
        /// <summary>
        ///     Creates an instance of the generator using a specified object as a seed.
        /// </summary>
        /// <param name="seed">
        ///     A seed for the factory.
        /// </param>
        /// <returns>
        ///     An instance of the generator created using a specified object as a seed.
        /// </returns>
        /// <remarks>
        ///     Calling this method with the same seed multiple time shall create new instances of generator which all behaves exactly the same.
        /// </remarks>
        IGenerator Create(object seed);
    }
}
