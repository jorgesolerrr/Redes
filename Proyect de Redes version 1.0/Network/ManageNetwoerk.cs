﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHeap;
namespace Proyect_de_Redes_version_1._0
{
    class ManageNetWork
    {
        public ManageNetWork()
        {
            _NetWork = new NetWork();
            Time = 0;
        }

        
        public NetWork _NetWork { get; }
        public int Time { get; private set; }

        public  void Manage()
        {
            _NetWork.PriorityQueue = Parser.ReadFile(new System.IO.StreamReader("foo"));
            bool end = false;
            while (!end)
            {
                while (_NetWork.PriorityQueue.Size > 0 && _NetWork.PriorityQueue.Root.Time == Time)
                {
                    Instruction currentInstruction = _NetWork.PriorityQueue.Pop();
                    if (Time == _NetWork.TimeToClean)
                        _NetWork.CleanNetWork();
                    currentInstruction.Execute(_NetWork);
                }


            }



        }





    }
}