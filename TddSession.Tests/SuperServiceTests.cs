using Moq;
using SuperServiceJob;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1 {
    public class SuperServiceTests {
        private SuperService _service;
        private Mock<IBankParser> _parserMock;
        private Mock<IPimSync> _pimSyncMock;
        private Mock<IAuditService> _mockAuditService;

        public SuperServiceTests() {
            _parserMock = new Mock<IBankParser>();
            _pimSyncMock = new Mock<IPimSync>();
            _mockAuditService = new Mock<IAuditService>();
            _service = new SuperService(_parserMock.Object,
                                        _pimSyncMock.Object,
                                        _mockAuditService.Object);
        }

        [Fact]
        public void Should_return_parsing_error() {
            _parserMock.Setup(p => p.Parse(It.IsAny<string>()))
                       .Throws(new ParsingException());

            Assert.Equal(Result.ParsingError, _service.Run("asdf"));
        }

        [Fact]
        public void Should_return_sync_error() {
            var banks = new List<Bank> {
                           new Bank("BRL", 100) {
                               Name = "itau"
                           }
                       };
            _parserMock.Setup(p => p.Parse(It.IsAny<string>()))
                       .Returns(banks);

            _pimSyncMock.Setup(p => p.Sync(banks))
                        .Throws(new PimSyncException());
            
            Assert.Equal(Result.SyncError, _service.Run("asdf"));
        }

        [Fact]
        public void Should_audit() {
            var banks = new List<Bank> {
                           new Bank("BRL", 100) {
                               Name = "itau"
                           }
                       };
            _parserMock.Setup(p => p.Parse(It.IsAny<string>()))
                       .Returns(banks);
            
            Assert.Equal(Result.Success, _service.Run("asdf"));

            _mockAuditService.Verify(p => p.Audit(17));
        }

    }
}
