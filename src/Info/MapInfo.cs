using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW4DumpHelperWinForms.Info
{
    class MapInfo
    {
        public string TYPE { private set; get; }
        public string ID { private set; get; }


        public MapInfo(string map_type, string map_id)
        {
            TYPE = map_type;
            ID = map_id;
        }

    }
}
