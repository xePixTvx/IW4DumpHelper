using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Infos
{
    internal class MapInfo
    {
        public string ID { get; private set; }
        public ClientTypes TYPE { get; private set; }
        public bool HAS_ALT_PATH { get; private set; }
        public string ALT_PATH { get; private set; }

        public MapInfo(string map_id, ClientTypes client_type, bool has_alt_path, string alt_path)
        {
            ID = map_id;
            TYPE = client_type;
            HAS_ALT_PATH = has_alt_path;
            ALT_PATH = alt_path;
        }
    }
}
