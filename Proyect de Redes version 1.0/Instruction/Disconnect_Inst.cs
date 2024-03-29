﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Disconnect_Inst : Instruction
    {
        public Disconnect_Inst(int time, string[] args) : base(time, args, 3)
        {
        }

        public override void Execute(NetWork network)
        {
            GetPort(Args[0], network).Disconnect();
        }
    }
}
