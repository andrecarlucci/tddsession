using System;

namespace SuperServiceJob {
    public class RateNotFoundException : Exception {
        public RateNotFoundException(string message) : base(message) {
        }
    }
}