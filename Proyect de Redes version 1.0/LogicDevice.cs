﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class LogicDevice : Device
    {
        public LogicDevice(string name, int numberPorts) : base(name)
        {
            Ports = new Port[numberPorts];
            for (int i = 0; i < numberPorts; i++) 
            {
                Ports[i] = new Port(name + "_" + i + 1);
            }  
        }
        public Port[] Ports { get; set; }
    }
}
