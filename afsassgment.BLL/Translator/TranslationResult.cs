using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afsassgment.BLL.Translator
{
    public class TranslationResult
    {
        public string Original { get; private set; }
        public string Translated { get; private set; }

        public TranslationResult(string original, string value)
        {
            this.Original = original;
            this.Translated = value;
        }
    }
}
