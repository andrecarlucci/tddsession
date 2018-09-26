using SuperServiceJob;
using Xunit;

namespace XUnitTestProject1 {
    public class BankTests {
        [Fact]
        public void Should_create_bank_with_currency() {
            var bank = new Bank("BRL");
            Assert.Equal("BRL", bank.BaseCurrency);
        }

        [Fact]
        public void Should_add_same_currency_to_bank() {
            var bank = new Bank("BRL");
            bank.Add(Money.Real(20));
            Assert.Equal(Money.Real(20), bank.Balance);
        }

        [Fact]
        public void Should_add_same_currency_2times_to_bank() {
            var bank = new Bank("BRL");
            bank.Add(Money.Real(20));
            bank.Add(Money.Real(20));
            Assert.Equal(Money.Real(40), bank.Balance);
        }

        [Fact]
        public void Should_add_other_currency_to_bank() {
            var bank = new Bank("BRL");
            bank.SetRate("USD", 4);
            bank.Add(Money.Real(20));
            bank.Add(Money.Dolar(10));
            Assert.Equal(Money.Real(60), bank.Balance);
        }

        [Fact]
        public void Should_throw_when_rate_not_found() {
            var bank = new Bank("BRL");
            Assert.Throws<RateNotFoundException>(() => {
                bank.Add(Money.Dolar(10));
            });
        }

        [Fact]
        public void Should_start_bank_with_zero() {
            var bank = new Bank("BRL");
            Assert.Equal(Money.Real(0), bank.Balance);
        }

        [Fact]
        public void Should_save_balance() {
            var bank = new Bank("BRL");
            bank.Add(Money.Real(10));
        }

    }
}
