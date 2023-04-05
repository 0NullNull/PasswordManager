using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    [Serializable]
    public class SaveF
    {
        public BindingList<Account> accList = new BindingList<Account>();
        public BindingList<string> PlatList = new BindingList<string>();
    }
}
