using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklist
{
    abstract public class ListItem
    {
        public string name { get; set; }
        public string folder { get; set; }
        public List<string> pngFiles { get; set; }

        public ListItem()
        { }
        public ListItem(string folder, List<string> pngFiles)
        {

        }
    }

    public class RDPServer : ListItem
    {
        public string rdpFile { get; set; }
        public bool done { get; set; }
        public bool selected { get; set; }

        public RDPServer(string _rdpname, string _rdpFile, string _folder, List<string> _pngFiles)
        {
            name = _rdpname;
            rdpFile = _rdpFile;
            folder = _folder;
            pngFiles = _pngFiles;
            done = false;
            selected = false;
        }
    }
}
