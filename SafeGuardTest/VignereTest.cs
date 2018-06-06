using SafeGuard.Model;
using SafeGuard.Interfaces;
using SafeGuard.Enum;
using NUnit.Framework;

namespace SafeGuardTest
{
    /// <summary>
    /// This tests Vignere Encryption
    /// </summary>
    [TestFixture]
    public class VignereTest
    {
        private IEncryptModel encryptModel;

        [SetUp]
        public void Setup()
        {
            encryptModel = new EncryptModel();
            encryptModel.encryptionType = EncryptionType.Vignere;
        }

        [TestCase("Hardest code so far !", "code",      "Hcfgiuh fsfs vs hou !")]
        [TestCase("Hardest code so far !", "tddisnice", "Htugmkg kqhx vr nse !")]
        public void TestVignereEncryption(string input, string key, string expectedOutput)
        {
            // Arrange
            encryptModel.mustBeEncrypted = true;
            encryptModel.inputText = input;
            encryptModel.encryptionKey = key;

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }

        [TestCase("Hcfgiuh fsfs vs hou !", "code",      "Hardest code so far !")]
        [TestCase("Htugmkg kqhx vr nse !", "tddisnice", "Hardest code so far !")]
        public void TestVignereDecryption(string input, string key, string expectedOutput)
        {
            // Arrange
            encryptModel.mustBeEncrypted = false;
            encryptModel.inputText = input;
            encryptModel.encryptionKey = key;

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }
    }
}
