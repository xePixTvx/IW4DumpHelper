using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW4DumpHelperWinForms.DEV
{
    class DevWeaponInfo
    {
        public string MapName { private set; get; }
        public string Id { private set; get; }
        public string RawfilePath { private set; get; }
        public string LocString { private set; get; }
        public string WeaponClass { private set; get; }


        public DevWeaponInfo(string mapId, string wepId, string filePath, string locString, string wepClass)
        {
            MapName = mapId;
            Id = wepId;
            RawfilePath = filePath;
            LocString = locString;
            WeaponClass = wepClass;
        }
    }
}
