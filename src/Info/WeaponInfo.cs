using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW4DumpHelperWinForms.Info
{
    class WeaponInfo
    {
        public MapInfo MAP { private set; get; }
        public string ID { private set; get; }
        public string LOCALIZEDSTRING { private set; get; }
        public string WEAPONCLASS { private set; get; }

        public WeaponInfo(MapInfo map, string id, string locstring, string wepclass)
        {
            MAP = map;
            ID = id;
            LOCALIZEDSTRING = locstring;
            WEAPONCLASS = wepclass;
        }
    }
}
