using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using afsassgment.BLL;
using afsassgment.BLL.Translator;

namespace afsasigment.BLL.Tests
{
    [TestClass]
    public class L33tSp34kTranslatorTest
    {
        [TestMethod]
        public void TranslateTest()
        {
            TranslationInput translateInput = new TranslationInput("Advanced Field Solutions", TranslatorType.L33tSp34k);
            ITranslator translator = TranslatorFactory.CreateTranslator(translateInput);
            
            TranslationResult result = translator.Translate(translateInput);

            Assert.IsTrue(string.Equals(@"4)\/4^/[3) |""131) 501(_)710^/5", result.Translated));
        }

        [TestMethod]
        public void TranslateWithUnsupportedCharactersTest()
        {
            TranslationInput translateInput = new TranslationInput("Chciałbym!", TranslatorType.L33tSp34k);
            ITranslator translator = TranslatorFactory.CreateTranslator(translateInput);

            TranslationResult result = translator.Translate(translateInput);

            Assert.IsTrue(string.Equals(@"[#[14Ł8j|v|!", result.Translated));
        }
    }
}
