using SuperServiceJob;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1 {
    public class BankParserTests {

        private string _text;
        private BankParser _parser;

        public BankParserTests() {
            _text = @"name|currency|balance
itau|BRL|100
bb|BRL|1000";
            _parser = new BankParser();
        }

        [Fact]
        public void Should_read_bank_name() {
            var banks = _parser.Parse(_text);
            Assert.Equal("itau", banks[0].Name);
            Assert.Equal("bb", banks[1].Name);
        }
    }
}
