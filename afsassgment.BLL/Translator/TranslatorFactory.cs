using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afsassgment.BLL.Translator
{
    public static class TranslatorFactory
    {
        public static ITranslator CreateTranslator(TranslationInput textToTranslate)
        {
            return CreateTranslator(textToTranslate.Translator);
        }

        public static ITranslator CreateTranslator(TranslatorType translatorType)
        {
            switch (translatorType)
            {
                case TranslatorType.L33tSp34k:
                    return new L33tSp34kTranslator();
            }

            return null;
        }
    }
}
