using System;
using System.Runtime.Serialization;

namespace SuperServiceJob {
    [Serializable]
    public class PimSyncException : Exception {
        public PimSyncException() {
        }

        public PimSyncException(string message) : base(message) {
        }

        public PimSyncException(string message, Exception innerException) : base(message, innerException) {
        }

        protected PimSyncException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}