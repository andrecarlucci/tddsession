using System.Collections.Generic;

namespace SuperServiceJob {
    public interface IBankParser {
        List<Bank> Parse(string text);
    }
}