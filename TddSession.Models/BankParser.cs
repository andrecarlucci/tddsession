using System.Collections.Generic;
using System.Linq;

namespace SuperServiceJob {
    public class BankParser : IBankParser {
        public List<Bank> Parse(string text) {
            return text.Split("\r\n").Skip(1).Select(l => {
                var pars = l.Split("|");
                return new Bank(pars[1], int.Parse(pars[2])) {
                    Name = pars[0]
                };
            }).ToList();
        }
    }
}