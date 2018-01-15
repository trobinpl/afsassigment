using afsassgment.BLL;
using afsassgment.BLL.Translator;
using afsassigment.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace afsassigment.Controllers
{
    [LogRequestActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Translate(string textToTranslate)
        {
            TranslationInput translationInput = new TranslationInput(textToTranslate, TranslatorType.L33tSp34k);
            ITranslator translator = TranslatorFactory.CreateTranslator(translationInput);

            TranslationResult translationResult = translator.Translate(translationInput);

            return Json(translationResult);
        }
    }
}