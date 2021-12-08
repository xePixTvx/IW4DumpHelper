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

        public DevCombinedStringInfo(string reference, string english, string french, string german, string italian, string polish, string russian, string spanish)
        {
            Reference = reference;
            Lang_String_english = english;
            Lang_String_french = french;
            Lang_String_german = german;
            Lang_String_italian = italian;
            Lang_String_polish = polish;
            Lang_String_russian = russian;
            Lang_String_spanish = spanish;
        }
    }
}
