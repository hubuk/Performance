using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ploeh.Albedo;
using Ploeh.Albedo.Refraction;

namespace Leet.Conventions
{
    public class ProgressPercentageDoubleConvention : NameContainsConvention
    {
        private const string expectedName = "progressPercentage";
        public ProgressPercentageDoubleConvention(bool value)
            : base(expectedName, value)
        {
        }

        public override IReflectionVisitor<bool> Proceed(string expected, bool value)
        {
            return new ProgressPercentageDoubleConvention(value);
        }

        public static bool Matches(object request)
        {
            var refraction = new CompositeReflectionElementRefraction<object>(
                new ParameterInfoElementRefraction<object>(),
                new PropertyInfoElementRefraction<object>(),
                new FieldInfoElementRefraction<object>()
                );

            var reflection = refraction.Refract(new[] { request });
            return reflection.Accept(new ProgressPercentageDoubleConvention(false)).Value;
        }
    }
}
