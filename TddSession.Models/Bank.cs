using System;
using System.Collections.Generic;

namespace SuperServiceJob {
    public class Bank {
        public string BaseCurrency { get; private set; }
        public Money Balance { get; private set; }
        public string Name { get; set; }

        private Dictionary<string, int> _rate = new Dictionary<string, int>();

        public Bank(string currency, int balance = 0) {
            BaseCurrency = currency;
            Balance = new Money(currency, balance);
        }

        public void Add(Money money) {
            var amount = money.Amount;
            if (money.Currency != BaseCurrency) {
                if (!_rate.ContainsKey(money.Currency)) {
                    throw new RateNotFoundException(money.Currency);
                }
                amount *= _rate[money.Currency];
            }
            Balance = new Money(
                BaseCurrency, 
                Balance.Amount + amount);
        }

        public void SetRate(string currency, int rate) {
            _rate[currency] = rate;
        }
    }
}