﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Port : Device, IActions
    {
        public Port(string name, LogicDevice owner) : base(name)
        {
            Owner = owner;
        } 


        public Wire Wire { get; internal set; }
        public LogicDevice Owner { get; } 

        //this method can be deleted cause the wire constructor

        //public void Connect(Port port)
        //{
        //    Wire = new Wire(this, port); 
        //}
        public void Disconnect()
        {
            if(Wire != null)
            {
                Port connected = Wire.ConnectedPort(Name);
                Wire = null;
                connected.Disconnect();
            }
        }

        public void Receive(Port receivePort, int time)
        {
            throw new NotImplementedException();
        }

        public void Send(string info,int time)
        {
            Wire.Value = int.Parse(info);
            Port portR = Wire.ConnectedPort(Name);
            if(portR.Owner is Host)
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
