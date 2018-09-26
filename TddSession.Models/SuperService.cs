namespace SuperServiceJob {
    public class SuperService {
        private readonly IBankParser _bankParser;
        private readonly IPimSync _pimSync;
        private readonly IAuditService _auditService;

        public SuperService(IBankParser bankParser, IPimSync pimSync, IAuditService auditService) {
            _bankParser = bankParser;
            _pimSync = pimSync;
            _auditService = auditService;
        }

        public Result Run(string banksAsText) {
            try {
                var banks = _bankParser.Parse(banksAsText);
                _pimSync.Sync(banks);
                _auditService.Audit(17);
            }
            catch(ParsingException) {
                return Result.ParsingError;
            }
            catch(PimSyncException) {
                return Result.SyncError;
            }
            return Result.Success;
        }
    }
}