using SafeGuard.Model;
using SafeGuard.Interfaces;
using SafeGuard.Enum;
using NUnit.Framework;

namespace SafeGuardTest
{
    /// <summary>
    /// This tests Cesar Encryption
    /// </summary>
    [TestFixture]
    public class CesarEncryptionTest
    {
        private IEncryptModel encryptModel;

        [SetUp]
        public void Setup()
        {
            encryptModel = new EncryptModel();
            encryptModel.encryptionType = EncryptionType.Cesar;
        }

        // Easy to check test
        [TestCase("ABC", "DEF")]
        [TestCase("GHI", "JKL")]
        // Border test
        [TestCase("XYZA", "ABCD")]
        // Other tests
        [TestCase("Ebiil Tloia!", "Hello World!")]
        [TestCase("Hello World!", "Khoor Zruog!")]
        [TestCase("123123123!%$3(#", "123123123!%$3(#")]
        public void TestCesarEncryption(string input, string expectedOutput)
        {
            // Arrange
            encryptModel.encryptionKey = "3";
            encryptModel.mustBeEncrypted = true;
            encryptModel.inputText = input;

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }

        // Easy to check test
        [TestCase("DEF", "ABC")]
        [TestCase("NOP", "KLM")]
        // Border test
        [TestCase("zabc", "wxyz")]
        // Other tests
        [TestCase("Hello World!", "Ebiil Tloia!")]
        [TestCase("Khoor Zruog!", "Hello World!")]
        [TestCase("123123123!%$3(#", "123123123!%$3(#")]
        public void TestCesarDecryption(string input, string expectedOutput)
        {
            // Arrange
            encryptModel.encryptionKey = "3";
            encryptModel.mustBeEncrypted = false;
            encryptModel.inputText = input;

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }


        // Easy to check test
        [TestCase("0", "I am a test now...")]
        // Other tests
        [TestCase("3", "L dp d whvw qrz...")]
        [TestCase("10", "S kw k docd xyg...")]
        [TestCase("1", "J bn b uftu opx...")]
        [TestCase("-25", "J bn b uftu opx...")]
        public void TestCesarEncryptionKey(string key, string expectedOutput)
        {
            // Arrange
            encryptModel.encryptionKey = key;
            encryptModel.mustBeEncrypted = true;
            encryptModel.inputText = "I am a test now...";

            // Act + Assert
            Assert.IsTrue(encryptModel.Encrypt() == expectedOutput);
        }
    }
}
