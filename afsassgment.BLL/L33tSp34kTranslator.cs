using afsassgment.BLL.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afsassgment.BLL
{
    public class L33tSp34kTranslator : ITranslator
    {
        public L33tSp34kTranslator() : this(1, false)
        {

        }

        public L33tSp34kTranslator(bool shouldPickRandomCodeForCurrentlyTranslatedCharacter) : this(1, shouldPickRandomCodeForCurrentlyTranslatedCharacter)
        {

        }

        public L33tSp34kTranslator(double translationThreshold) : this(translationThreshold, false)
        {

        }

        public L33tSp34kTranslator(double translationThreshold, bool shouldPickRandomCodeForCurrentlyTranslatedCharacter)
        {
            this.TranslationThreshold = translationThreshold;
            this.ShouldPickRandomCodeForCurrentlyTranslatedCharacter = shouldPickRandomCodeForCurrentlyTranslatedCharacter;
        }

        private double TranslationThreshold = 1;
        private Random RandomNumberGenerator = new Random();
        private bool ShouldPickRandomCodeForCurrentlyTranslatedCharacter = false;

        public TranslationResult Translate(TranslationInput textToTranslate)
        {
            string translatedText = TranslateText(textToTranslate.Value);

            TranslationResult result = new TranslationResult(textToTranslate.Value, translatedText);
            return result;
        }

        private Dictionary<char, List<string>> CodingTable = new Dictionary<char, List<string>>()
        {
            { 'A', new List<string>() { "4", @"/\", "@", @"/\", "^", "aye", "∂" } },
            { 'B', new List<string>() { "8", "13", "|3", "ß", "P>", "|:", "!3", "(3", "/3", ")3", "|-]" } },
            { 'C', new List<string>() { "[", "¢", "<", "(", "©" } },
            { 'D', new List<string>() { ")", "(|", "|)", "|o", "[)", "I>", "|>", "?", "T)", "I7", "cl" } },
            { 'E', new List<string>() { "3", @"&", "£", "€", "{", "[-", "|=-" } },
            { 'F', new List<string>() { "|\"", "|=", "ƒ", "|#", "ph", "/=", "v" } },
            { 'G', new List<string>() { "6", "&", "(_+", "9", "C-", "gee", "(γ,", "[,", "{,", "<-", "(." } },
            { 'H', new List<string>() { "#", "/-/", "[-]", " ]-[", ")-(", "(-)", ":-:", "|~|", "|-|", "]~[", "}{", "?", "}-{" } },
            { 'I', new List<string>() { "1", "!", "i", "|", "eye", "3y3", "][", "]" } },
            { 'J', new List<string>() { "_|", "_/", "¿", "</", "(/", "</", "_[" } },
            { 'K', new List<string>() { "X", "|<", "|{", "]{", "|X" } },
            { 'L', new List<string>() { "1", "£", "7", " 1_", "|", "|_", "el", "[_," } },
            { 'M', new List<string>() { "|v|", "[V]", "(Y)", "{V}", "em", "AA", @"|\/|", @"/\/\", "(u)", "(V)", @"(\/)", @"/|\", "^^", "/|/|", @"//\", @"|\|\" } },
            { 'N', new List<string>() { "^/", @"|\|", @"/\/", @"[\]", @"<\>", @"{\}", @"[]\", "//", "[]", "/V", "₪", "^" } },
            { 'O', new List<string>() { "0", "[]", "()", "oh", "P" } },
            { 'P', new List<string>() { "|*", "|o", "|º", "?", "|^(o)", "|>", "9", "[]D", "|̊", "|7" } },
            { 'Q', new List<string>() { "(_,)", "()_", "0_", "<|", "0," } },
            { 'R', new List<string>() { "|`", "|~", "|?", "/2", "|^", "lz", "|9", "2", "®", "[z", "Я", ".-", "|2", "ſ" } },
            { 'S', new List<string>() { "5", "$", "z", "§", "ehs", "es" } },
            { 'T', new List<string>() { "7", "+", "-|-", "1", "']['", "†" } },
            { 'U', new List<string>() { "(_)", "|_|", "v", "L|", "µ" } },
            { 'V', new List<string>() { @"\/", "|/", @"\|" } },
            { 'W', new List<string>() { @"\/\/", "vv", @"\N", "'//", @"\\'", @"\^/", "dubya", "(n)", @"\V/", @"\X/", @"\|/", @"\_|_/", @"\_:_/", "Ш", "uu" } },
            { 'X', new List<string>() { "><", "Ж", "}{", "ecks", "×", "χ", ")(", "][" } },
            { 'Y', new List<string>() { "j", "`/", "Ч", @"\|/", "7" } },
            { 'Z', new List<string>() { "2", "7_", "-/_", "%", ">_", "s" } },
        };

        private string TranslateText(string text)
        {
            string stringToAppend = string.Empty;
            StringBuilder resultBuilder = new StringBuilder();

            foreach (char character in text)
            {
                stringToAppend = this.PickCodeForCharacter(char.ToUpperInvariant(character));

                resultBuilder.Append(stringToAppend);
            }
            return resultBuilder.ToString();
        }

        private string PickCodeForCharacter(char character)
        {
            if (!this.CodingTable.Keys.Contains(character))
            {
                return character.ToString();
            }

            List<string> codes = this.CodingTable[character];
            int codeIndex = 0;

            if (this.CodeCurrentCharacter())
            {
                if (this.ShouldPickRandomCodeForCurrentlyTranslatedCharacter)
                {
                    codeIndex = this.RandomNumberGenerator.Next(codes.Count);
                }

                return codes.ElementAt(codeIndex);
            }

            return character.ToString();
        }

        private bool CodeCurrentCharacter() => RandomNumberGenerator.NextDouble() < this.TranslationThreshold;
    }
}
