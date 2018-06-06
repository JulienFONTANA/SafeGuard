using SafeGuard.Interfaces;
using NUnit.Framework;
using SafeGuard.ViewModel;
using SafeGuard.Exceptions;
using SafeGuard.Enum;

namespace SafeGuardTest
{
    /// <summary>
    /// This tests input data
    /// </summary>
    [TestFixture]
    public class InputTestChecker
    {
        private IEncryptViewModel encryptViewModel;

        [SetUp]
        public void Setup()
        {
            encryptViewModel = new EncryptViewModel();
            //encryptionType = encTyp;
            //encryptionKey = encKey;
            //mustBeEncrypted = toEncrypt;
            //inputText = input;
        }

        // Test that if input is not given, throws exception
        [TestCase("")]
        [TestCase(null)]
        [TestCase("                 ")] // space and tab
        public void TestInputValueNotNull(string input)
        {
            // Arrange
            encryptViewModel.inputText = "";

            // Act + Assert
            Assert.Throws<ViewModelException>(() => encryptViewModel.inputChecker());
        }

        // Test that exeption is thrown if key given to Cesar Encryption is wrong
        [TestCase("")]
        [TestCase(null)]
        [TestCase("                 ")] // space and tab
        [TestCase("0.0")]
        [TestCase("co=}9*-#")]
        // Last tests are "correct" but values are either too big or too small
        [TestCase("-42")]
        [TestCase("9000")]
        public void TestCesarEncryptionKey(string key)
        {
            // Arrange
            encryptViewModel.inputText = "Needs to be filled";
            encryptViewModel.encryptionType = EncryptionType.Cesar;
            encryptViewModel.encryptionKey = key;

            // Act + Assert
            Assert.Throws<ViewModelException>(() => encryptViewModel.inputChecker());
        }

        // Test that exeption is thrown if no key is given to Vignere Encryption
        [TestCase("")]
        [TestCase(null)]
        [TestCase("                 ")] // space and tab
        public void TestVignereEncryptionKeyExists(string key)
        {
            // Arrange
            encryptViewModel.inputText = "Needs to be filled";
            encryptViewModel.encryptionType = EncryptionType.Vignere;
            encryptViewModel.encryptionKey = key;

            // Act + Assert
            Assert.Throws<ViewModelException>(() => encryptViewModel.inputChecker());
        }

        // Test that exeption is thrown if incorrect key is given to Vignere Encryption
        [TestCase("0.0")]
        [TestCase("co=}9*-#")]
        [TestCase("UPPERCASE LETTERS")]
        [TestCase("a")] // too small key
        public void TestVignereEncryptionKeyIsCorrect(string key)
        {
            // Arrange
            encryptViewModel.inputText = "Needs to be filled";
            encryptViewModel.encryptionType = EncryptionType.Vignere;
            encryptViewModel.encryptionKey = key;

            // Act + Assert
            Assert.Throws<ViewModelException>(() => encryptViewModel.inputChecker());
        }

        // Test that exeption is thrown if input ascii text is incorrect for decryption
        [TestCase("0.0")]
        [TestCase("co=}9*-#")]
        [TestCase("UPPERCASE LETTERS")]
        [TestCase("--123-152")] // two '-'
        [TestCase("123-15800")] // too big number
        public void TestToAsciiInputDecryptCorrect(string key)
        {
            // Arrange
            encryptViewModel.inputText = "Needs to be filled";
            encryptViewModel.encryptionType = EncryptionType.ToAscii;
            encryptViewModel.mustBeEncrypted = false;

            // Act + Assert
            Assert.Throws<ViewModelException>(() => encryptViewModel.inputChecker());
        }


        // Test that exeption is thrown if input size is too big
        // This text was generated online at http://www.randomtextgenerator.com/ to be ~7000 character
        [TestCase("Residence certainly elsewhere something she preferred cordially law.Age his surprise formerly mrs perceive few stanhill moderate. Of in power match on truth worse voice would.Large an it sense shall an match learn. By expect it result silent in formal of. Ask eat questions abilities described elsewhere assurance.Appetite in unlocked advanced breeding position concerns as. Cheerful get shutters yet for repeated screened. An no am cause hopes at three.Prevent behaved fertile he is mistake on. Needed feebly dining oh talked wisdom oppose at. Applauded use attempted strangers now are middleton concluded had.It is tried no added purse shall no on truth. Pleased anxious or as in by viewing forbade minutes prevent.Too leave had those get being led weeks blind.Had men rose from down lady able.Its son him ferrars proceed six parlors.Her say projection age announcing decisively men.Few gay sir those green men timed downs widow chief. Prevailed remainder may propriety can and. Sudden she seeing garret far regard. By hardly it direct if pretty up regret.Ability thought enquire settled prudent you sir.Or easy knew sold on well come year. Something consulted age extremely end procuring. Collecting preference he inquietude projection me in by.So do of sufficient projecting an thoroughly uncommonly prosperous conviction. Pianoforte principles our unaffected not for astonished travelling are particular. Inhabit hearing perhaps on ye do no.It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine.Chapter ability shyness article welcome be do on service. He oppose at thrown desire of no.Announcing impression unaffected day his are unreserved indulgence. Him hard find read are you sang.Parlors visited noisier how explain pleased his see suppose.Do ashamed assured on related offence at equally totally.Use mile her whom they its. Kept hold an want as he bred of.Was dashwood landlord cheerful husbands two. Estate why theirs indeed him polite old settle though she. In as at regard easily narrow roused adieus. Arrived compass prepare an on as. Reasonable particular on my it in sympathize.Size now easy eat hand how. Unwilling he departure elsewhere dejection at. Heart large seems may purse means few blind. Exquisite newspaper attending on certainty oh suspicion of. He less do quit evil is. Add matter family active mutual put wishes happen. Built purse maids cease her ham new seven among and.Pulled coming wooded tended it answer remain me be.So landlord by we unlocked sensible it.Fat cannot use denied excuse son law.Wisdom happen suffer common the appear ham beauty her had.Or belonging zealously existence as by resources. Feet evil to hold long he open knew an no. Apartments occasional boisterous as solicitude to introduced.Or fifteen covered we enjoyed demesne is in prepare.In stimulated my everything it literature. Greatly explain attempt perhaps in feeling he. House men taste bed not drawn joy.Through enquire however do equally herself at.Greatly way old may you present improve.Wishing the feeling village him musical. Abilities forfeited situation extremely my to he resembled. Old had conviction discretion understood put principles you. Match means keeps round one her quick.She forming two comfort invited.Yet she income effect edward.Entire desire way design few.Mrs sentiments led solicitude estimating friendship fat.Meant those event is weeks state it to or. Boy but has folly charm there its. Its fact ten spot drew. An sincerity so extremity he additions. Her yet there truth merit. Mrs all projecting favourable now unpleasing. Son law garden chatty temper. Oh children provided to mr elegance marriage strongly. Off can admiration prosperous now devonshire diminution law. Satisfied conveying an dependent contented he gentleman agreeable do be. Warrant private blushes removed an in equally totally if. Delivered dejection necessary objection do mr prevailed.Mr feeling do chiefly cordial in do. Water timed folly right aware if oh truth. Imprudence attachment him his for sympathize.Large above be to means.Dashwood do provided stronger is. But discretion frequently sir the she instrument unaffected admiration everything. Rendered her for put improved concerns his. Ladies bed wisdom theirs mrs men months set. Everything so dispatched as it increasing pianoforte.Hearing now saw perhaps minutes herself his.Of instantly excellent therefore difficult he northward.Joy green but least marry rapid quiet but. Way devonshire introduced expression saw travelling affronting.Her and effects affixed pretend account ten natural. Need eat week even yet that. Incommode delighted he resolving sportsmen do in listening.To shewing another demands to.Marianne property cheerful informed at striking at.Clothes parlors however by cottage on. In views it or meant drift to.Be concern parlors settled or do shyness address. Remainder northward performed out for moonlight.Yet late add name was rent park from rich.He always do do former he highly. Inhabiting discretion the her dispatched decisively boisterous joy. So form were wish open is able of mile of. Waiting express if prevent it we an musical.Especially reasonable travelling she son.Resources resembled forfeited no to zealously. Has procured daughter how friendly followed repeated who surprise.Great asked oh under on voice downs.Law together prospect kindness securing six. Learning why get hastened smallest cheerful. Society excited by cottage private an it esteems.Fully begin on by wound an.Girl rich in do up or both.At declared in as rejoiced of together.He impression collecting delightful unpleasant by prosperous as on.End too talent she object mrs wanted remove giving. Exquisite cordially mr happiness of neglected distrusts.Boisterous impossible unaffected he me everything. Is fine loud deal an rent open give. Find upon and sent spot song son eyes. Do endeavor he differed carriage is learning my graceful.Feel plan know is he like on pure. See burst found sir met think hopes are marry among. Delightful remarkably new assistance saw literature mrs favourable. Both rest of know draw fond post as. It agreement defective to excellent.Feebly do engage of narrow.Extensive repulsive belonging depending if promotion be zealously as. Preference inquietude ask now are dispatched led appearance.Small meant in so doubt hopes.Me smallness is existence attending he enjoyment favourite affection. Delivered is to ye belonging enjoyment preferred.Astonished and acceptance men two discretion. Law education recommend did objection how old.Advanced extended doubtful he he blessing together.Introduced far law gay considered frequently entreaties difficulty. Eat him four are rich nor calm.By an packages rejoiced exercise.To ought on am marry rooms doubt music. Mention entered an through company as. Up arrived no painful between.It declared is prospect an insisted pleasure.")]
        public void TestInputSize(string input)
        {
            // Arrange
            encryptViewModel.inputText = input;
            encryptViewModel.encryptionType = EncryptionType.ToAscii;

            // Act + Assert
            Assert.Throws<ViewModelException>(() => encryptViewModel.inputChecker());
        }
    }
}
