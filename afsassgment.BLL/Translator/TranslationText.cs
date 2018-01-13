using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afsassgment.BLL.Translator
{
    public class TranslationInput
    {
        public string Value { get; private set; }
        public TranslatorType Translator { get; private set; }

        public TranslationInput(string value, TranslatorType translator)
        {
            this.Value = value;
            this.Translator = translator;
        }
    }
}
