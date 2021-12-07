using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW4DumpHelperWinForms.DEV
{
    class DevStringInfo
    {
        public LANGUAGES Language { private set; get; }
        public string Reference { private set; get; }
        public string Lang_String { private set; get; }

        public DevStringInfo(LANGUAGES lang, string reference, string lang_string)
        {
            Language = lang;
            Reference = reference;
            Lang_String = lang_string;
        }
    }
}
