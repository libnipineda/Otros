using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2_201403541
{
    class Funcionalidad : Lexico
    {
        string ruta = @"C:\Users\libni\OneDrive\Escritorio\";

        List<Lista> ListaC = new List<Lista>();
        List<Traducir> traducir = new List<Traducir>();

        StreamWriter archivo;       

        public List<Lista> ObtenerInfo(List<Lista> info)
        {
            // ----------------------------------------- Lexemas a eliminar -----------------------------------------
            info.RemoveAll(x => x.Lexema.Contains("class"));
            info.RemoveAll(x => x.Lexema.Contains("{"));
            info.RemoveAll(x => x.Lexema.Contains("}"));
            info.RemoveAll(x => x.Lexema.Contains(";"));
            info.RemoveAll(x => x.Lexema.Contains("static"));
            info.RemoveAll(x => x.Lexema.Contains("void"));
            info.RemoveAll(x => x.Lexema.Contains("Main"));
            info.RemoveAll(x => x.Lexema.Contains("string"));
            info.RemoveAll(x => x.Lexema.Contains("String"));
            info.RemoveAll(x => x.Lexema.Contains("args"));
            info.RemoveAll(x => x.Lexema.Contains("int"));
            info.RemoveAll(x => x.Lexema.Contains("float"));
            info.RemoveAll(x => x.Lexema.Contains("char"));
            info.RemoveAll(x => x.Lexema.Contains("bool"));
            info.RemoveAll(x => x.Lexema.Contains("Console"));
            info.RemoveAll(x => x.Lexema.Contains("WriteLine"));
            info.RemoveAll(x => x.Lexema.Contains("Ultimo"));

            // ----------------------------------------- Crear Archivo Txt -----------------------------------------
            archivo = new StreamWriter(ruta + "Comandos" + ".txt");

            archivo.WriteLine("# codign: utf-8");
            archivo.WriteLine("# Your code here:");
                        
            // -----------------------------------------  Eliminar elementos y Recorrer lista -----------------------------------------

            var list = info.ToList();
            list.RemoveRange(0, 5);            

            foreach (var item in list)
            {
                // obtencion para imprimir por consola
                if (item.Lexema.Equals("."))
                {
                    string a = item.Lexema;
                    a = a.Replace(".", "print");
                    AgregarListaC(a);
                }
                if (item.Lexema.Equals("("))
                {
                    string a = item.Lexema;
                    AgregarListaC(a);
                }
                if (item.Tkn.Equals("Cadena"))
                {
                    string a = item.Lexema;
                    AgregarListaC(a);
                }
                if (item.Lexema.Equals(")"))
                {
                    string a = item.Lexema;
                    AgregarListaC(a);
                }
                Console.WriteLine(item.Lexema);
                archivo.WriteLine(item.Lexema);
            }            
            
            archivo.Close();
            return ListaC;
        }

        public void AgregarListaC(string dato)
        {
            Traducir  temp = new Traducir(dato);
            temp.valor = dato;
            traducir.Add(temp);
            RecorrerL();
        }        

        public void RecorrerL()
        {
            foreach (Traducir item in traducir)
            {
                Console.WriteLine("Valor prueba");
                //Console.WriteLine(item.valor);
            }
        }

    }
}