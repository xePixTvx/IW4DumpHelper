using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW4DumpHelperWinForms.DEV
{
    class DevCombinedStringInfo
    {
        public string Reference { private set; get; }
        public string Lang_String_english { private set; get; }
        public string Lang_String_french { private set; get; }
        public string Lang_String_german { private set; get; }
        public string Lang_String_italian { private set; get; }
        public string Lang_String_polish { private set; get; }
        public string Lang_String_russian { private set; get; }
        public string Lang_String_spanish { private set; get; }

        public DevCombinedStringInfo()
        {
            Reference = null;
            Lang_String_english = null;
            Lang_String_french = null;
            Lang_String_german = null;
            Lang_String_italian = null;
            Lang_String_polish = null;
            Lang_String_russian = null;
            Lang_String_spanish = null;
        }

        public void SetReference(string reference)
        {
            Reference = reference;
        }

        public void SetLangString(LANGUAGES lang, string str)
        {
            switch(lang)
            {
                case LANGUAGES.english:
                    Lang_String_english = str;
                break;

                case LANGUAGES.french:
                    Lang_String_french = str;
                break;

                case LANGUAGES.german:
                    Lang_String_german = str;
                break;

                case LANGUAGES.italian:
                    Lang_String_italian = str;
                break;

                case LANGUAGES.polish:
                    Lang_String_polish = str;
                break;

                case LANGUAGES.russian:
                    Lang_String_russian = str;
                break;

                case LANGUAGES.spanish:
                    Lang_String_spanish = str;
                break;
            }
        }
    }
}
