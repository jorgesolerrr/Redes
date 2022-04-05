﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Hub : LogicDevice, IActions
    {
        public Hub(string name, int numberOfPorts) : base(name, numberOfPorts)
        {
        }

        public int ReceivePort { get; set; }
        public void Send(string bit, int time)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                if(i != ReceivePort)
                {
                    Ports[i].Wire.Value = int.Parse(bit);
                    Port portR = Ports[i].Wire.ConnectedPort(Name);
                    if (portR.Owner is Host)
                    {
                        Host hostR = (Host)portR.Owner;
                        hostR.Receive(portR, time);
                    }
                    else
                    {
                        Hub hubR = (Hub)portR.Owner;
                        hubR.Receive(portR, time);
                    }
                }
            }
        }
        public void Receive(Port receivePort, int time)
        {//falta escribir el txt
            ReceivePort = int.Parse(receivePort.Name[Name.Length - 1].ToString()) - 1;
            string bit = receivePort.Wire.Value.ToString();
            Send(bit, time);
        }

    }
}
