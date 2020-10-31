using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcp
{
    class DataObj
    {
        public int nAddrCode { get; set; }
        public int nCmdCode { get; set; }
        public int nRegisterAddr { get; set; }
        public int nRegisterCount { get; set; }
        public int nDataPos { get; set; }

        public byte slaveAddress { get; set; }
        public ushort startAddress { get; set; }
        public ushort numberOfPoints { get; set; }
    }
}
