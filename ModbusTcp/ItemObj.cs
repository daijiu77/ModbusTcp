using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcp
{
    class ItemObj
    {
        public ItemObj(string txt, object val)
        {
            this.txt = txt;
            this.val = val;
        }

        public string txt { get; set; }
        public object val { get; set; }

        public override string ToString()
        {
            return txt;
        }
    }
}
