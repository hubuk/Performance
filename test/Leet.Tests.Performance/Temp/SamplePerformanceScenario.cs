//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Leet.Performance;
//using Leet.Specifications;

//public class SamplePerformanceScenario : PerformanceReporterSpecification<SamplePerformanceScenario, long, long>
//{
//    private PerformanceReport<long> PerformanceScenario(IGenerator generator, long seed, long repetitions, CancellationToken cancellationToken)
//    {
//        if (object.ReferenceEquals(generator, null))
//        {
//            throw new ArgumentNullException(nameof(generator));
//        }

//        if (repetitions <= 0)
//        {
//            throw new ArgumentOutOfRangeException(nameof(repetitions), repetitions, null);
//        }

//        cancellationToken.ThrowIfCancellationRequested();

//        long testBegin = Stopwatch.GetTimestamp();
//        long result = 0;

//        for (long repetition = 0; repetition < repetitions; ++repetition)
//        {

//        }

//        return new PerformanceReport<long>(result, Stopwatch.GetTimestamp() - testBegin);
//    }

//    public override PerformanceScenario<long, long> CreateDelegate()
//    {
//        return PerformanceScenario;
//    }
//}