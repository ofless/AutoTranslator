using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTranslatorAPI;

namespace AutoTranslator.Models
{
    public abstract class  Translator
    {
        public abstract Task<Translation> FetchTranslationAsync();
    }

    public abstract class LanguageCountry
    {
        protected GTranslatorAPI.Translation Translation;
        protected string ClipboardText;

        protected LanguageCountry(string text)
        {
            ClipboardText = text;
        }

        public abstract Task<Translation> FetchTranslationAsync();

        public override string ToString()
        {
            return Translation.TranslatedText;
        }


    }

    public class ContextTranslate : LanguageCountry
    {
        Languages from;
        Languages to;
        public ContextTranslate(string text) : base(text)
        {
            if (text.Any(c => c > 127))
            {
                from = Languages.ru;
                to = Languages.en;
            }
            else
            {
                from = Languages.en;
                to = Languages.ru;
            }

        }

        public override async Task<Translation> FetchTranslationAsync()
        {
            Translation = await new GTranslatorAPIClient().TranslateAsync(from, to, ClipboardText);
            return Translation;
        }

    }

    public class TranslationHandler : Translator
    {
        string Context;

        public TranslationHandler(string text)
        {
            Context = text;
        }
        public override Task<Translation> FetchTranslationAsync()
        {
           return new ContextTranslate(Context).FetchTranslationAsync();
        }
    }



}
