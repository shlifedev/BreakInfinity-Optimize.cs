using System.Text;
using NUnit.Framework;

namespace LD.Tests
{
    [TestFixture]
    public class Tests
    {
        public static FastBigDouble TestValueExponent4 = FastBigDouble.Parse("1.23456789e1234");
        public static FastBigDouble TestValueExponent1 = FastBigDouble.Parse("1.234567893e3");

        [Test]
        void Example()
        {
            FastBigDouble a = new FastBigDouble("1.0A");
            FastBigDouble b = new FastBigDouble("1e3");
            FastBigDouble c = new FastBigDouble("1000");

            Assert.IsTrue(a==b && b == c && a==c);
        }
    }
}