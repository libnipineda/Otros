using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Practica1_201403541
{
    class Descripcion
    {
        private string info;
        private string url;


        public Descripcion(string info, string url)
        {
            this.Info = info;
            this.Url = url;
        }        

        public string Info { get => info; set => info = value; }
        public string Url { get => url; set => url = value; }
    }
}