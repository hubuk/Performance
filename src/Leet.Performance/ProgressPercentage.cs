//-----------------------------------------------------------------------
// <copyright file="ProgressPercentage.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Properties;

    /// <summary>
    ///     Represents a decimal value of the operation progress percentage in a range from 0 to 1.
    /// </summary>
    public struct ProgressPercentage : IComparable, IComparable<ProgressPercentage>, IEquatable<ProgressPercentage>, IFormattable
#if NET_STANDARD_1_3
        , IConvertible
#endif
    {
        /// <summary>
        ///     A read-only value that represtns a zero progress.
        /// </summary>
        public static readonly ProgressPercentage Zero = new ProgressPercentage(0d);
        
        /// <summary>
        ///     A read-only value that represtns a fully completed operation progress.
        /// </summary>
        public static readonly ProgressPercentage One = new ProgressPercentage(1d);

        /// <summary>
        ///     Holds a read-only decimal value of the progress percentage.
        /// </summary>
        private readonly double value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProgressPercentage"/> class.
        /// </summary>
        /// <param name="progressPercentage">
        ///     Percentage progress value.
        /// </param>
        public ProgressPercentage(double progressPercentage)
        {
            if (double.IsNaN(progressPercentage))
            {
                throw new ArgumentException(Resources.Exception_Argument_ProgressPercentageValueNaN, nameof(progressPercentage));
            }

            if (progressPercentage < 0d || progressPercentage > 1d)
            {
                throw new ArgumentOutOfRangeException(nameof(progressPercentage), Resources.Exception_ArgumentOutOfRange_ProgressPercentageValue);
            }

            this.value = progressPercentage;
        }

        /// <summary>
        ///     Explicitly converts a speciied percentage progress to a decimal value.
        /// </summary>
        /// <param name="percentage">
        ///     A value to convert.
        /// </param>
        public static implicit operator double(ProgressPercentage percentage)
        {
            return percentage.value;
        }

        /// <summary>
        ///     Implicitly converts a speciied decimal value to percentage progress.
        /// </summary>
        /// <param name="percentage">
        ///     A value to convert.
        /// </param>
        public static implicit operator ProgressPercentage(double value)
        {
            return new ProgressPercentage(value);
        }

        /// <summary>
        ///     Gets a deimal value of the progress percentage.
        /// </summary>
        public double Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        ///     Determines whether the specified progress percentage represents a zero value.
        /// </summary>
        /// <param name="progress">
        ///     Progress percentage to examin.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the specified <paramref name="progress"/> represents a zero value;
        ///     <see langword="false"/>, otherwise.
        /// </returns>
        public static bool IsZero(ProgressPercentage progress)
        {
            return progress.value == Zero.value;
        }

        /// <summary>
        ///     Determines whether the specified progress percentage represents a fully completed operation.
        /// </summary>
        /// <param name="progress">
        ///     Progress percentage to examin.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the specified <paramref name="progress"/> represents a fully completed operation;
        ///     <see langword="false"/>, otherwise.
        /// </returns>
        public static bool IsOne(ProgressPercentage progress)
        {
            return progress.value == One.value;
        }

        /// <summary>
        ///     Compares the current instance with another object of the same type and returns an integer
        ///     that indicates whether the current instance precedes, follows, or occurs in the same position
        ///     in the sort order as the other object.
        /// </summary>
        /// <param name="obj">
        ///     An object to compare with this instance.
        /// </param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes obj in the sort order. Zero This instance occurs in the same position in the sort order as obj. Greater than zero This instance follows obj in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="obj"/> is not the same type as this instance.
        /// </exception>
        public int CompareTo(object obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return 1;
            }

            if (!(obj is ProgressPercentage))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_Argument_UnexpectedObjectType, obj.GetType()));
            }

            return this.CompareTo((ProgressPercentage)obj);
        }

        /// <summary>
        ///     Compares the current instance with another object of the same type and returns an integer
        ///     that indicates whether the current instance precedes, follows, or occurs in the same position
        ///     in the sort order as the other object.
        /// </summary>
        /// <param name="other">
        ///     An object to compare with this instance.
        /// </param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared.
        ///     The return value has these meanings:
        ///     <list type="table">
        ///         <listheader>
        ///             <term>
        ///                 Value
        ///             </term>
        ///             <description>
        ///                 Meaning
        ///             </description>
        ///         </listheader>
        ///         <item>
        ///             <term>
        ///                 Less than zero
        ///             </term>
        ///             <description>
        ///                 This instance precedes other in the sort order.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <term>
        ///                 Zero
        ///             </term>
        ///             <description>
        ///                 This instance occurs in the same position in the sort order as other.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <term>
        ///                 Greater than zero
        ///             </term>
        ///             <description>
        ///                 This instance follows other in the sort order.
        ///             </description>
        ///         </item>
        ///     </list>
        /// </returns>
        public int CompareTo(ProgressPercentage other)
        {
            return this.value.CompareTo(other.value);
        }

        /// <summary>
        ///     Compares two <see cref="ProgressPercentage"/> values and returns an integer that indicates
        ///     whether the first value is less than, equal to, or greater than the second value.
        /// </summary>
        /// <param name="left">
        ///     The first progress percentage to compare. 
        /// </param>
        /// <param name="right">
        ///     The second progress percentage to compare. 
        /// </param>
        /// <returns>
        ///     One of the following values:
        ///     <list type="table">
        ///         <listheader>
        ///             <term>
        ///                 Value
        ///             </term>
        ///             <description>
        ///                 Description
        ///             </description>
        ///         </listheader>
        ///         <item>
        ///             <term>
        ///                 -1
        ///             </term>
        ///             <description>
        ///                 <paramref name="left"/> is less than <paramref name="right"/>.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <term>
        ///                 0
        ///             </term>
        ///             <description>
        ///                 <paramref name="left"/> is equal to <paramref name="right"/>.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <term>
        ///                 1
        ///             </term>
        ///             <description>
        ///                 <paramref name="left"/> is greater than <paramref name="right"/>.
        ///             </description>
        ///         </item>
        ///     </list>
        /// </returns>
        public static int Compare(ProgressPercentage left, ProgressPercentage right)
        {
            return left.value.CompareTo(right);
        }
        public static bool Equals(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public bool Equals(ProgressPercentage other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj is ProgressPercentage)
            {
                return this.Equals((ProgressPercentage)obj);
            }

            return false;
        }

        public static Double Parse(string s)
        {
            throw new NotImplementedException();
        }

        public static Double Parse(string s, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public static Double Parse(string s, NumberStyles style)
        {
            throw new NotImplementedException();
        }
        public static Double Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public static bool TryParse(string s, out Double result)
        {
            throw new NotImplementedException();
        }
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Double result)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public string ToString(string format)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public static bool operator true(ProgressPercentage left)
        {
            throw new NotImplementedException();
        }

        public static bool operator false(ProgressPercentage left)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }
        public static bool operator <(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }
        public static bool operator >(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }
        public static bool operator <=(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }
        public static bool operator >=(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage operator +(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage operator -(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage operator *(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage operator /(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage operator %(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }


        public static ProgressPercentage Add(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage Subtract(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage Multiply(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage Divide(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }

        public static ProgressPercentage Remainder(ProgressPercentage left, ProgressPercentage right)
        {
            throw new NotImplementedException();
        }
    }
}
