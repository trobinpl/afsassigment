using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afsassgment.BLL.Translator
{
    public interface ITranslator
    {
        TranslationResult Translate(TranslationInput textToTranslate);
    }
}
