//-----------------------------------------------------------------------
// <copyright file="IDelegateFactory{TDelegate}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet
{
    /// <summary>
    ///     Creates an instance of the delegate.
    /// </summary>
    /// <typeparam name="TDelegate">
    ///     Type of the delegate created by this factory.
    /// </typeparam>
    public interface IDelegateFactory<TDelegate>
    {
        /// <summary>
        ///     Creates an instance of the <typeparamref name="TDelegate"/>.
        /// </summary>
        /// <returns>
        ///     An instance of the <typeparamref name="TDelegate"/>.
        /// </returns>
        TDelegate CreateDelegate();
    }
}
