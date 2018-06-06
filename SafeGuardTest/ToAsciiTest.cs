using SafeGuard.Model;
using SafeGuard.Interfaces;
using SafeGuard.Enum;
using NUnit.Framework;

namespace SafeGuardTest
{
    /// <summary>
    /// This tests ToAscii Encryption
    /// </summary>
    [TestFixture]
    public class ToAsciiTest
    {
        private IEncryptModel encryptModel;

        [SetUp]
        public void Setup()
        {
            encryptModel = new EncryptModel();
            encryptModel.encryptionType = EncryptionType.ToAscii;
        }

        [TestCase("Az=", "65-122-61")]
        [TestCase("0 ~", "48-32-126")]
        [TestCase("Y?S", "89-63-83")]           
        public void TestAsciiEncryption(string input, string expectedOutput)
        {
            // Arrange
            encryptModel.mustBeEncrypted = true;
            encryptModel.inputText = input;

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }

        [TestCase("65-122-61", "Az=")]
        [TestCase("48-32-126", "0 ~")]
        [TestCase("89-63-83", "Y?S")]
        public void TestAsciiDecryption(string input, string expectedOutput)
        {
            // Arrange
            encryptModel.mustBeEncrypted = false;
            encryptModel.inputText = input;

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }
    }
}
