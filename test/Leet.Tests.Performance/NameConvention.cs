//-----------------------------------------------------------------------
// <copyright file="DomainFixture.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

#if NET451
namespace Leet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ploeh.Albedo;

    public abstract class NameConvention : ReflectionVisitor<bool>
    {
        private readonly string expected;

        private readonly bool value;

        public override bool Value
        {
            get
            {
                return this.value;
            }
        }

        protected string Expected
        {
            get
            {
                return this.expected;
            }
        }

        public NameConvention(string expected, bool value)
        {
            this.expected = expected;
            this.value = value;
        }

        public abstract IReflectionVisitor<bool> Proceed(string expected, bool value);

        public override IReflectionVisitor<bool> Visit(ParameterInfoElement parameterInfoElement)
        {
            if (object.ReferenceEquals(parameterInfoElement, null))
            {
                throw new ArgumentNullException(nameof(parameterInfoElement));
            }

            var pi = parameterInfoElement.ParameterInfo;

            return this.Proceed(expected, this.value || this.IsMatch(pi.ParameterType, pi.Name));
        }

        public override IReflectionVisitor<bool> Visit(FieldInfoElement fieldInfoElement)
        {
            if (object.ReferenceEquals(fieldInfoElement, null))
            {
                throw new ArgumentNullException(nameof(fieldInfoElement));
            }

            var fi = fieldInfoElement.FieldInfo;

            return this.Proceed(expected, this.value || this.IsMatch(fi.FieldType, fi.Name));
        }

        public override IReflectionVisitor<bool> Visit(PropertyInfoElement propertyInfoElement)
        {
            if (object.ReferenceEquals(propertyInfoElement, null))
            {
                throw new ArgumentNullException(nameof(propertyInfoElement));
            }

            var pi = propertyInfoElement.PropertyInfo;

            return this.Proceed(expected, this.value || this.IsMatch(pi.PropertyType, pi.Name));
        }

        private bool IsMatch(Type type, string name)
        {
            if (object.ReferenceEquals(type, null))
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (object.ReferenceEquals(name, null))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (type != typeof(double))
            {
                return false;
            }

            return this.IsMatchCore(name);
        }

        protected abstract bool IsMatchCore(string name);
    }
}
#endif
