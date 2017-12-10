using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LStart
{
    [Serializable]
    public class Shortcut
    {
        public String name { get; set; }

        public String path { get; set; }
        public String parameter { get; set; }
        public bool isAdmin { get; set; }
        public int startTimes { get; set; }
        public Shortcut(String _name, String _path, String _parameter="", bool _isAdmin = false,int _startTimes=0)
        {
            name = _name;
            path = _path;
            parameter = _parameter;
            isAdmin = _isAdmin;
            startTimes = _startTimes;
        }
    }
}
