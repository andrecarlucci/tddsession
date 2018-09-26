namespace SuperServiceJob {
    public class Money {
        public int Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(string currency, int amount) {
            Currency = currency;
            Amount = amount;
        }

        public Money Times(int value) {
            return new Money(Currency, Amount * value);
        }

        public override bool Equals(object obj) {
            var other = obj as Money;
            return Currency == other.Currency && Amount == other.Amount;
        }

        public static Money Real(int amount) {
            return new Money("BRL", amount);
        }

        public static Money Dolar(int amount) {
            return new Money("USD", amount);
        }
    }
}