using SafeGuard.Enum;
using SafeGuard.Enums;
using SafeGuard.Exceptions;
using SafeGuard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SafeGuard.Model
{
    public class EncryptModel : IEncryptModel
    {
        public EncryptionType encryptionType { get; set; }
        public string encryptionKey { get; set; }
        public bool mustBeEncrypted { get; set; }
        public string inputText { get; set; }

        // Used for testing purposes
        public EncryptModel() { }

        public EncryptModel(EncryptionType encTyp, string encKey, bool toEncrypt, string input)
        {
            encryptionType = encTyp;
            encryptionKey = encKey;
            mustBeEncrypted = toEncrypt;
            inputText = input;
        }

        public string Encrypt()
        {
            switch (encryptionType)
            {
                case EncryptionType.Cesar:
                    return CesarFct(inputText, encryptionKey, mustBeEncrypted);

                case EncryptionType.ToAscii:
                    return mustBeEncrypted ? AsciiEnc(inputText) : AsciiDec(inputText);

                case EncryptionType.Vignere:
                    return VignereFct(inputText, encryptionKey, mustBeEncrypted);

                default:
                    throw new ModelException("Encryption Type not recognised.", ErrorLevelEnum.Error);
            }
            throw new ModelException("A really weird error occured!", ErrorLevelEnum.Error);
        }

        #region Cesar
        /// <summary>
        /// Cesar code is obtained by moving letters of the alphabet by an offset
        /// Exemple : Ofset is 3, A become D, b => e... x => z, y => a 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <param name="toEncrypt"></param>
        /// <returns>Encrypted or decrypted Cesar code</returns>
        private string CesarFct(string input, string key, bool toEncrypt)
        {
            var result = "";
            int keyAsInt = 0;
            int.TryParse(key, out keyAsInt);

            if (toEncrypt == false)
                keyAsInt = -keyAsInt;

            foreach (var character in input)
            {
                char charToAdd = character;
                if (char.IsLetter(character))
                {
                    if (char.IsLower(character))
                    {
                        if (character + keyAsInt < 97) // a
                            charToAdd = (char)(character + keyAsInt + 26);
                        else if (character + keyAsInt > 122) // z
                            charToAdd = (char)(character + keyAsInt - 26);
                        else
                            charToAdd = (char)(character + keyAsInt);
                    }
                    else if (char.IsUpper(character))
                    {
                        if (character + keyAsInt < 65) // A
                            charToAdd = (char)(character + keyAsInt + 26);
                        else if (character + keyAsInt > 90) // Z
                            charToAdd = (char)(character + keyAsInt - 26);
                        else
                            charToAdd = (char)(character + keyAsInt);
                    }
                }
                result += charToAdd;
            }
            return result;
        }
        #endregion

        #region ToAscii
        /// <summary>
        /// Home made ascii encryption. Not really strong nonetheless.
        /// Simply changes each char of a string in ASCII, of from ASCII to readable string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Encoded or decoded Ascii</returns>
        private string AsciiEnc(string input)
        {
            var result = "";
            byte[] asciiValues = Encoding.ASCII.GetBytes(input);

            foreach (var ascii in asciiValues)
            {
                result += ascii.ToString() + '-';
            }

            return result.TrimEnd('-');
        }

        private string AsciiDec(string input)
        {
            var result = "";
            var asciiAsInt = 0;

            foreach (var asciiChar in input.Split('-'))
            {
                int.TryParse(asciiChar, out asciiAsInt);
                result += Convert.ToChar(asciiAsInt);
            }

            return result;
        }
        #endregion

        #region Vignere
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string VignereFct(string input, string key, bool mustBeEncrypted)
        {
            string result = "";
            var keyIndex = 0;
            var keyLength = key.Length;

            foreach (char t in input)
            {
                // value is between 'a' and 'z' 
                if (97 <= t && t <= 122)
                {
                    var tmp = mustBeEncrypted ? (t - 97 + key[keyIndex] - 97)
                                              : (t - 97 - (key[keyIndex] - 97));
                    if (tmp < 0) tmp += 26;
                    result += Convert.ToChar(97 + (tmp % 26));
                    keyIndex++;
                    if (keyIndex == keyLength)
                        keyIndex = 0;
                }
                else
                    result += t;
            }

            return result;
        }
        #endregion
    }
}
