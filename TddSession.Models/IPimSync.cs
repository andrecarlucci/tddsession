using System.Collections.Generic;

namespace SuperServiceJob {
    public interface IPimSync {
        void Sync(List<Bank> banks);
    }

    public interface IAuditService {
        void Audit(int userId);
    }
}