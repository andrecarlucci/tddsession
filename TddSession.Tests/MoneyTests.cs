using SuperServiceJob;
using Xunit;

namespace XUnitTestProject1 {
    public class MoneyTests {
        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(20, 3, 60)]
        [InlineData(5, 1, 5)]
        public void Should_multiply(int initial, int times, int expected) {
            var real = new Money("BRL", initial);
            var result = real.Times(times);
            Assert.Equal(expected, result.Amount);
        }
        

        [Fact]
        public void Should_set_currency_on_money() {
            var money = new Money("BRL", 20);
            Assert.Equal("BRL", money.Currency);
        }

        [Fact]
        public void Should_be_equal() {
            var cincoReais = Money.Real(5);
            var cincoReais2 = Money.Real(5);

            Assert.Equal(cincoReais, cincoReais2);
        }

        [Fact]
        public void Should_not_be_equal() {
            var cincoReais = Money.Real(5);
            var cincoDolares = Money.Dolar(5);

            Assert.False(cincoReais.Equals(cincoDolares));
        }
    }
}
