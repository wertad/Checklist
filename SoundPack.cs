using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklist
{
    public class SoundPack
    {
        public string name { get; set; }
        public string[] A { get; set; }
        public string[] Q { get; set; }
    }
    public class Root
    {
        public List<SoundPack> soundpacks { get; set; }
    }
}
