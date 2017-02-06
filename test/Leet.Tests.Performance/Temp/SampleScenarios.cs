//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Threading;
//using System.Threading.Tasks;
//using Leet.Performance;

//namespace Leet.Tests
//{
//    public class Complexer<TSeed> : IEnumerable<PerformanceContext<TSeed>>
//    {
//        private readonly IEnumerable<TSeed> complexer;
//        private readonly IEnumerable<long> repeater;
//        private readonly IGeneratorFactory generatorFactory;

//        public IEnumerator<PerformanceContext<TSeed>> GetEnumerator()
//        {
//            foreach (var repetitions in repeater)
//            {
//                foreach (var seed in complexer)
//                {
//                    yield return new PerformanceContext<TSeed>(repetitions, seed, this.generatorFactory);
//                }
//            }
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return this.GetEnumerator();
//        }
//    }
    

//    public class SampleScenarios
//    {
//        static PerformanceScenario<ulong, ulong> scenario1 = TestSparse;
//        static PerformanceScenario<ulong, ulong> scenario2 = Test;
//        static PerformanceScenario<ulong, ulong>[] scenarios = new PerformanceScenario<ulong, ulong>[] { TestSparse, Test };
//        public static PerformanceReport<ulong> TestSparse(IGenerator generator, ulong seed, long repetitions, CancellationToken cancellationToken)
//        {
//            ulong result = 0;
//            long testStart = Stopwatch.GetTimestamp();
//            for (long i = 0; i < repetitions; ++i)
//            {
//                result += (ulong)BitCountSparse((ulong)seed);
//            }
//            long endTime = Stopwatch.GetTimestamp();
//            return new PerformanceReport<ulong>(result, endTime - testStart);
//        }
//        public static PerformanceReport<ulong> Test(IGenerator generator, ulong seed, long repetitions, CancellationToken cancellationToken)
//        {
//            ulong result = 0;
//            long testStart = Stopwatch.GetTimestamp();
//            for (long i = 0; i < repetitions; ++i)
//            {
//                result += BitCountPow2Minus1((ulong)seed);
//            }
//            long endTime = Stopwatch.GetTimestamp();
//            return new PerformanceReport<ulong>(result, endTime - testStart);
//        }

//        public static void Run()
//        {
//            CancellationTokenSource source = new CancellationTokenSource();

//            var r = Compare(scenarios, source.Token);
//        }


//        public static IReadOnlyList<long> Run1(IReadOnlyList<PerformanceScenario<ulong, ulong>> scenarios, IGeneratorFactory factory, IEnumerable<ulong> complexer, IEnumerable<long> repeater, CancellationToken cancellationToken, IEqualityComparer<ulong> comparer)
//        {
//            foreach (long repetitions in repeater)
//            {
//                return Run(scenarios, factory, complexer, repetitions, cancellationToken, comparer);
//            }
//        }

//        public static IReadOnlyList<long> Run(IReadOnlyList<PerformanceScenario<ulong, ulong>> scenarios, IGeneratorFactory factory, IEnumerable<ulong> complexer, long repetitions, CancellationToken cancellationToken, IEqualityComparer<ulong> comparer)
//        {
//            foreach (ulong seed in complexer)
//            {
//                return Compare(scenarios, factory, seed, repetitions, cancellationToken, comparer);
//            }
//        }

//        public class Runner
//        {
//            public IReadOnlyList<PerformanceScenario<ulong, ulong>> scenarios;
//            public IGeneratorFactory factory;
//            public IEqualityComparer<ulong> comparer;
//        }

//        public class PerformanceComparer<TSeed, TResult>
//        {
//            IReadOnlyList<PerformanceScenario<TSeed, TResult>> scenarios;
//            IGeneratorFactory factory;
//            IEqualityComparer<TResult> comparer;

//            public IReadOnlyList<long> Compare(IEnumerable<long> repeater, IEnumerable<TSeed> complexer, CancellationToken cancellationToken)
//            {
//                foreach (long repetitions in repeater)
//                {
//                    foreach (TSeed seed in complexer)
//                    {
//                        return this.Compare(seed, repetitions, cancellationToken);
//                    }
//                }
//            }

//            public IReadOnlyList<long> Compare(TSeed seed, long repetitions, CancellationToken cancellationToken)
//            {
//                bool stored = false;
//                TResult resultValue = default(TResult);
//                List<long> times = new List<long>(scenarios.Count);
//                foreach (var scenario in scenarios)
//                {
//                    IGenerator generator = factory.Create(seed);
//                    var result = scenario(generator, seed, repetitions, cancellationToken);
//                    if (stored)
//                    {
//                        if (!this.comparer.Equals(resultValue, result.Result))
//                        {
//                            throw null;
//                        }
//                    }
//                    else
//                    {
//                        resultValue = result.Result;
//                        stored = true;
//                    }

//                    times.Add(result.TicksElapsed);
//                }

//                return times.AsReadOnly();

//            }
//        }

//        public static IReadOnlyList<long> Compare(IReadOnlyList<PerformanceScenario<ulong, ulong>> scenarios, IGeneratorFactory factory, ulong seed, long repetitions, CancellationToken cancellationToken, IEqualityComparer<ulong> comparer)
//        {
//            ulong? resultValue = default(ulong?);
//            List<long> times = new List<long>(scenarios.Count);
//            foreach (var scenario in scenarios)
//            {
//                IGenerator generator = factory.Create(seed);
//                var result = scenario(generator, seed, repetitions, cancellationToken);
//                if (resultValue.HasValue)
//                {
//                    if (resultValue.Value != result.Result)
//                    {
//                        throw null;
//                    }
//                }
//                else
//                {
//                    resultValue = result.Result;
//                }

//                times.Add(result.TicksElapsed);
//            }

//            return times.AsReadOnly();
            
//        }

//        /// <summary>
//        ///     Counts a 1-bits in a specified sparsely filled value with two's complement representation.
//        /// </summary>
//        /// <param name="value">
//        ///     A value which 1-bits shall be counted.
//        /// </param>
//        /// <returns>
//        ///     Number of 1-bits in a specified value with two's complement representation.
//        /// </returns>
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        [CLSCompliant(false)]
//        public static int BitCountSparse(ulong value)
//        {
//            //Contract.Ensures(Contract.Result<int>() >= 0);
//            //Contract.Ensures(Contract.Result<int>() <= Bits.UInt64BitSize);

//            int result = 0;
//            ulong temp = value;

//            while (temp != 0)
//            {
//                ++result;
//                temp &= temp - 1;
//            }

//            return result;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        [CLSCompliant(false)]
//        public static ulong BitCountPow2Minus1(ulong value)
//        {
//            //Contract.Ensures(Contract.Result<int>() >= 0);
//            //Contract.Ensures(Contract.Result<int>() <= Bits.UInt64BitSize);

//            unchecked
//            {
//                int result = 0;
//                ulong copy = value;
//                int temporary = (int)((copy & 0x100000000UL) >> 27); // test bit 32
//                copy >>= temporary;
//                result += temporary;
//                temporary = (int)((copy & 0x10000) >> 12); // test bit 16
//                copy >>= temporary;
//                result += temporary;
//                temporary = (int)((copy & 0x100) >> 5); // test bit 8
//                copy >>= temporary;
//                result += temporary;
//                temporary = (int)((copy & 0x10) >> 2); // test bit 4
//                copy >>= temporary;
//                result += temporary;
//                temporary = (int)((copy & 4UL) >> 1); // test bit 2
//                copy >>= temporary;
//                result += temporary;
//                temporary = (int)((copy & 2UL) >> 1); // test bit 1
//                copy >>= temporary;
//                result += temporary;
//                result += (int)(copy & 1); // test bit 0
//                return (ulong)result;
//            }
//        }
//    }
//}
