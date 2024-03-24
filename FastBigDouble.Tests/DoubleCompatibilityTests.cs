using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LD.Tests
{
    [TestFixture]
    public class DoubleCompatibilityTests
    {
        [Test]
        public void SpecialValuesEquality()
        {
            Assert.That(FastBigDouble.PositiveInfinity.Equals(double.PositiveInfinity));
            Assert.That(FastBigDouble.NegativeInfinity.Equals(double.NegativeInfinity));
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Add(BinaryTestCase testCase)
        {
            testCase.AssertEqual((d1, d2) => d1 + d2, (bd1, bd2) => bd1 + bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Subtract(BinaryTestCase testCase)
        {
            testCase.AssertEqual((d1, d2) => d1 - d2, (bd1, bd2) => bd1 - bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Multiply(BinaryTestCase testCase)
        {
            testCase.AssertEqual((d1, d2) => d1 * d2, (bd1, bd2) => bd1 * bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Divide(BinaryTestCase testCase)
        {
            testCase.AssertEqual((d1, d2) => d1 / d2, (bd1, bd2) => bd1 / bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Negate(UnaryTestCase testCase)
        {
            testCase.AssertEqual(d => -d, bd => -bd);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Equality(BinaryTestCase testCase)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            testCase.AssertComparison((d1, d2) => d1 == d2, (bd1, bd2) => bd1 == bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Inequality(BinaryTestCase testCase)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            testCase.AssertComparison((d1, d2) => d1 != d2, (bd1, bd2) => bd1 != bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void GreaterThan(BinaryTestCase testCase)
        {
            testCase.AssertComparison((d1, d2) => d1 > d2, (bd1, bd2) => bd1 > bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void GreaterThanOrEqual(BinaryTestCase testCase)
        {
            testCase.AssertComparison((d1, d2) => d1 >= d2, (bd1, bd2) => bd1 >= bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void LessThan(BinaryTestCase testCase)
        {
            testCase.AssertComparison((d1, d2) => d1 < d2, (bd1, bd2) => bd1 < bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void LessThanOrEqual(BinaryTestCase testCase)
        {
            testCase.AssertComparison((d1, d2) => d1 <= d2, (bd1, bd2) => bd1 <= bd2);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void CompareTo(BinaryTestCase testCase)
        {
            testCase.AssertEqual((d1, d2) => d1.CompareTo(d2), (bd1, bd2) => bd1.CompareTo(bd2));
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Log(BinaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Log, (bd1, bd2) => FastBigDouble.Log(bd1, bd2));
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Pow(BinaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Pow, FastBigDouble.Pow);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Abs(UnaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Abs, FastBigDouble.Abs);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Ceiling(UnaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Ceiling, FastBigDouble.Ceiling);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Cosh(UnaryTestCase testCase)
        {
            // TODO: Check if indeed bad precision or bug
            testCase.AssertEqual(Math.Cosh, FastBigDouble.Cosh, 1E-13);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Exp(UnaryTestCase testCase)
        {
            // TODO: Check if indeed bad precision or bug
            testCase.AssertEqual(Math.Exp, FastBigDouble.Exp, 1E-13);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Floor(UnaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Floor, FastBigDouble.Floor);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Log10(UnaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Log10, d => FastBigDouble.Log10(d));
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Max(BinaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Max, FastBigDouble.Max);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalBinaryTestCases))]
        [TestCaseSource(nameof(GeneralBinaryTestCases))]
        public void Min(BinaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Min, FastBigDouble.Min);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Round(UnaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Round, FastBigDouble.Round);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Sign(UnaryTestCase testCase)
        {
            if (double.IsNaN(testCase.Values.Double))
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                var doubleException = Assert.Catch(() => Math.Sign(testCase.Values.Double));
                var bigDoubleException = Assert.Catch(() => FastBigDouble.Sign(testCase.Values.BigDouble));
                Assert.That(doubleException.GetType(), Is.EqualTo(bigDoubleException.GetType()));
                return;
            }
            testCase.AssertEqual(d => Math.Sign(d), d => FastBigDouble.Sign(d));
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Sinh(UnaryTestCase testCase)
        {
            // TODO: Check if indeed bad precision or bug
            testCase.AssertEqual(Math.Sinh, FastBigDouble.Sinh, 1E-13);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Tanh(UnaryTestCase testCase)
        {
            // TODO: Check if indeed bad precision or bug
            testCase.AssertEqual(Math.Tanh, FastBigDouble.Tanh, 1E-13);
        }

        [Test]
        [TestCaseSource(nameof(FundamentalUnaryTestCases))]
        [TestCaseSource(nameof(GeneralUnaryTestCases))]
        public void Truncate(UnaryTestCase testCase)
        {
            testCase.AssertEqual(Math.Truncate, FastBigDouble.Truncate);
        }

        private static IEnumerable<TestCaseData> GeneralUnaryTestCases()
        {
            return GeneralTestCaseCombinator.UnaryTestCases;
        }

        private static IEnumerable<TestCaseData> FundamentalUnaryTestCases()
        {
            return FundamentalTestCaseCombinator.UnaryTestCases;
        }

        private static IEnumerable<TestCaseData> GeneralBinaryTestCases()
        {
            return GeneralTestCaseCombinator.BinaryTestCases;
        }

        private static IEnumerable<TestCaseData> FundamentalBinaryTestCases()
        {
            return FundamentalTestCaseCombinator.BinaryTestCases;
        }

        private static readonly TestCaseCombinator GeneralTestCaseCombinator = new TestCaseCombinator()
            .Value("0", 0)
            .Value("Integer", 345)
            .Value("Negative integer", -745)
            .Value("Big integer", 123456789)
            .Value("Big negative integer", -987654321)
            .Value("Small integer", 4)
            .Value("Small negative integer", -5)
            .Value("Big value", 3.7e63)
            .Value("Big negative value", -7.3e36)
            .Value("Really big value", 7.23e222)
            .Value("Really big negative value", -2.23e201)
            .Value("Small value", 5.323e-47)
            .Value("Small negative value", -8.252e-21)
            .Value("Really small value", 1.98e-241)
            .Value("Really small negative value", -6.79e-215);

        private static readonly TestCaseCombinator FundamentalTestCaseCombinator = new TestCaseCombinator()
            .Value("0", 0)
            .Value("1", 1)
            .Value("-1", -1)
            .Value("1,1", 1.1)
            .Value("-1,1", -1.1)
            .Value("0,9", 0.9)
            .Value("-0,9", -0.9)
            .Value("∞", double.PositiveInfinity)
            .Value("-∞", double.NegativeInfinity)
            .Value("NaN", double.NaN);

        private class TestCaseCombinator
        {
            private readonly List<TestCaseValue> values = new List<TestCaseValue>();

            public TestCaseCombinator Value(string name, double value)
            {
                values.Add(new TestCaseValue(name, value, FastBigDouble.Tolerance));
                return this;
            }

            public IEnumerable<TestCaseData> UnaryTestCases
            {
                get
                {
                    return values
                        .Select(v => new TestCaseData(new UnaryTestCase(v.Value, v.Precision)).SetName(v.Name));
                }
            }

            public IEnumerable<TestCaseData> BinaryTestCases
            {
                get
                {
                    var current = 0;
                    while (current < values.Count)
                    {
                        for (var i = current; i < values.Count; i++)
                        {
                            foreach (var testCaseData in Permutate(values[current], values[i]))
                            {
                                yield return testCaseData;
                            }
                        }

                        current++;
                    }
                }
            }

            private static IEnumerable<TestCaseData> Permutate(TestCaseValue first, TestCaseValue second)
            {
                yield return TestCaseData(first, second);
                if (first != second)
                {
                    yield return TestCaseData(second, first);
                }
            }

            private static TestCaseData TestCaseData(TestCaseValue first, TestCaseValue second)
            {
                var testCase = new BinaryTestCase(first.Value, second.Value, Math.Max(first.Precision, second.Precision));
                return new TestCaseData(testCase).SetName($"{first.Name}; {second.Name}");
            }

            private class TestCaseValue
            {
                public string Name { get; }
                public double Value { get; }
                public double Precision { get; }

                public TestCaseValue(string name, double value, double precision)
                {
                    Name = name;
                    Value = value;
                    Precision = precision;
                }
            }
        }

        public static void AssertEqual(FastBigDouble fastBigDouble, double @double, double precision)
        {
            if (IsOutsideDoubleRange(fastBigDouble))
            {
                Assert.Ignore("Result is not in range of possible Double values");
            }

            if (FastBigDouble.IsNaN(fastBigDouble) && double.IsNaN(@double))
            {
                return;
            }
            Assert.That(fastBigDouble.Equals(@double, precision),
                $"Double implementation: {@double}, BigDouble implementation {fastBigDouble}");
        }

        private static bool IsOutsideDoubleRange(FastBigDouble fastBigDouble)
        {
            if (FastBigDouble.IsNaN(fastBigDouble) || FastBigDouble.IsInfinity(fastBigDouble))
            {
                return false;
            }

            return fastBigDouble.Exponent > Math.Log10(double.MaxValue)
                   || fastBigDouble.Exponent < Math.Log10(double.Epsilon);
        }

        public class UnaryTestCase
        {
            private readonly double @double;
            private readonly FastBigDouble fastBigDouble;
            private readonly double precision;

            public UnaryTestCase(double @double, double precision = FastBigDouble.Tolerance)
            {
                this.@double = @double;
                fastBigDouble = @double;
                this.precision = precision;
            }

            public (double Double, FastBigDouble BigDouble) Values => (@double, fastBigDouble);

            public void AssertEqual(Func<double, double> doubleOperation,
                Func<FastBigDouble, FastBigDouble> bigDoubleOperation)
            {
                AssertEqual(doubleOperation, bigDoubleOperation, precision);
            }

            public void AssertEqual(Func<double, double> doubleOperation,
                Func<FastBigDouble, FastBigDouble> bigDoubleOperation, double operationPrecision)
            {
                var doubleResult = doubleOperation(@double);
                var bigDoubleResult = bigDoubleOperation(fastBigDouble);
                DoubleCompatibilityTests.AssertEqual(bigDoubleResult, doubleResult, operationPrecision);
            }
        }

        public class BinaryTestCase
        {
            private readonly (double first, double second) doubles;
            private readonly (FastBigDouble first, FastBigDouble second) bigDoubles;
            private readonly double precision;

            public BinaryTestCase(double first, double second, double precision = FastBigDouble.Tolerance)
            {
                doubles = (first, second);
                bigDoubles = (first, second);
                this.precision = precision;
            }

            public void AssertEqual(Func<double, double, double> doubleOperation,
                Func<FastBigDouble, FastBigDouble, FastBigDouble> bigDoubleOperation)
            {
                var doubleResult = doubleOperation(doubles.first, doubles.second);
                var bigDoubleResult = bigDoubleOperation(bigDoubles.first, bigDoubles.second);
                DoubleCompatibilityTests.AssertEqual(bigDoubleResult, doubleResult, precision);
            }

            public void AssertComparison(Func<double, double, bool> doubleOperation,
                Func<FastBigDouble, FastBigDouble, bool> bigDoubleOperation)
            {
                var doubleResult = doubleOperation(doubles.first, doubles.second);
                var bigDoubleResult = bigDoubleOperation(bigDoubles.first, bigDoubles.second);
                Assert.That(doubleResult, Is.EqualTo(bigDoubleResult),
                    $"Double implementation: {doubleResult}, BigDouble implementation: {bigDoubleResult}");
            }
        }
    }
}
