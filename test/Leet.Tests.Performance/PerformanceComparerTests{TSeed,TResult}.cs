//-----------------------------------------------------------------------
// <copyright file="PerformanceComparerTests{TSeed,TResult}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Leet.Specifications.Performance;

public class PerformanceComparerTestsObjectObject : PerformanceComparerSpecification<object, object>
{
}

public class PerformanceComparerTestsInt32Int32 : PerformanceComparerSpecification<int, int>
{
}

public class PerformanceComparerTestsActionAction : PerformanceComparerSpecification<Action, Action>
{
}

public class PerformanceComparerTestsDateTimeDateTime : PerformanceComparerSpecification<DateTime, DateTime>
{
}

public class PerformanceComparerTestsDateTimeKindDateTimeKind : PerformanceComparerSpecification<DateTimeKind, DateTimeKind>
{
}

public class PerformanceComparerTestsIDisposableIDisposable : PerformanceComparerSpecification<IDisposable, IDisposable>
{
}

public class PerformanceComparerTestsFlagsAttributeFlagsAttribute : PerformanceComparerSpecification<FlagsAttribute, FlagsAttribute>
{
}

public class PerformanceComparerTestsArrayArray : PerformanceComparerSpecification<Array, Array>
{
}
