using SafeGuard.Enum;
using SafeGuard.Enums;
using SafeGuard.Exceptions;
using SafeGuard.Interfaces;
using SafeGuard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SafeGuard.ViewModel
{
    public class EncryptViewModel : IEncryptViewModel
    {
        public EncryptionType encryptionType { get; set; }
        public string encryptionKey { get; set; }
        public bool mustBeEncrypted { get; set; }
        public string inputText { get; set; }
        public IEncryptModel encryptModel { get; set; }

        // Used for testing purposes
        public EncryptViewModel() { }

        public EncryptViewModel(EncryptionType encTyp, string encKey, bool toEncrypt, string input)
        {
            encryptionType = encTyp;
            encryptionKey = encKey;
            mustBeEncrypted = toEncrypt;
            inputText = input;

            try
            {
                inputChecker();
                encryptModel = new EncryptModel(encTyp, encKey, toEncrypt, input);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Tests are done in a given order, from more "obvious" to more specific
        public bool inputChecker()
        {
            // Test if input is given
            if (string.IsNullOrEmpty(inputText))
                throw new ViewModelException("Please insert a text as input.", ErrorLevelEnum.Warning);

            // Test if key given to Cesar Encryption is wrong
            if (encryptionType == EncryptionType.Cesar)
            {
                int res = 0;
                if (!int.TryParse(encryptionKey, out res))
                    throw new ViewModelException("Cannot use Cesar encryption without an interger numeric key!!!", ErrorLevelEnum.Error);
                if (-26 > res || res > 26)
                    throw new ViewModelException("In a Cesar encryption, key must be between -25 and 25.", ErrorLevelEnum.Warning);
            }

            // Test if key is given to Vignere Encryption
            if (encryptionType == EncryptionType.Vignere)
            {
                if (string.IsNullOrEmpty(encryptionKey))
                    throw new ViewModelException("Cannot use Vignere encryption without a key!!!", ErrorLevelEnum.Error);
                if (encryptionKey.Length < 2)
                    throw new ViewModelException("Cannot use Vignere encryption with less than 3 character key.", ErrorLevelEnum.Warning);
                if (!encryptionKey.All(char.IsLower))
                    throw new ViewModelException("Vignere encryption key can only contain lowercase letter", ErrorLevelEnum.Error);
            }

            // Test if input ascii text is correct for decryption
            if (encryptionType == EncryptionType.ToAscii && !mustBeEncrypted)
            {
                var match = Regex.Match(inputText, "^(([-]?)([0-9]{1,3})([-]?))*$");
                if (!match.Success)
                    throw new ViewModelException("Ascii input text is incorrect", ErrorLevelEnum.Error);
            }

            // Test input size
            if (inputText.Length > 4096)
                throw new ViewModelException("Text to encrypt/Decrypt is super big...", ErrorLevelEnum.Warning);

            // Input tests are done, we can now send date to the Model
            return true;
        }

        public string EncryptInput()
        {
            return encryptModel.Encrypt();
        }
    }
}
