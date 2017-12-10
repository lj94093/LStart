using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LStart
{
    [Serializable]
    public class UserGroup
    {
        public String name { get; set; }
        public ObservableCollection<Shortcut> shortcuts { get; set; }

        public UserGroup()
        {
            name = "新分组";
            shortcuts = new ObservableCollection<Shortcut>();
        }
        public UserGroup(String _name)
        {
            name = _name;
            shortcuts = new ObservableCollection<Shortcut>();
        }
        
    }
}
