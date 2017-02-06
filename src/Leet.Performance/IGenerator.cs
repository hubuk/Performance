//-----------------------------------------------------------------------
// <copyright file="IGenerator.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    /// <summary>
    ///     Provides a mechanism for creating objects of specified types based on a specified seed.
    /// </summary>
    public interface IGenerator
    {
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
        T Generate<T>(T seed);
    }
}
