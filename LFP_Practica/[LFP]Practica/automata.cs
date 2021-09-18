using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Practica
{    
    class Automata  
    {        
        List<Lista> tabla = new List<Lista>();
        List<ListaError> Etabla = new List<ListaError>();
        List<Grafica> grafica = new List<Grafica>();
         int idtkn;
         int nutknen = 0;
         int idtkns = 8; // numero de tokens definidos (antiguo numero 12)
         int fila = 0;
         int columna = 0;
         string token = "";
        int numnodo=0;

        public void Lexico(String cadena)
        {
            int estado = 0;
            String concatenar = "";
            for (int i = 0; i < cadena.Length; i++)
            {
                switch (estado)
                {
                    case 0:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 0; concatenar += cadena[i]; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i])) // letras
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i])) // numeros
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)44).Equals(cadena[i]) | ((char)58).Equals(cadena[i]) | ((char)59).Equals(cadena[i]) | ((char)123).Equals(cadena[i]) | ((char)125).Equals(cadena[i])) // signo ',' | ':' | ';' | '{' | '}' 
                        {
                            estado = 3; concatenar += cadena[i]; columna++;                            
                        }
                        else if (((char)34).Equals(cadena[i])) // comillas
                        {
                            estado = 4; concatenar += cadena[i]; columna++;
                        }
                        else //Estado error
                        {
                            string tokenerror = ""; tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            Etabla.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;
                    case 1:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 1; concatenar += cadena[i]; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i])) // letras
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }
                        else // Estado de aceptación
                        {
                            Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                            Lista temp1 = new Lista();                            
                            temp1.numero = "" + nutknen;
                            temp1.fila = "" + fila;
                            temp1.columna = "" + columna;
                            temp1.idtkn = "1";
                            temp1.tkn = "Palabra Reservada";
                            temp1.lexema = concatenar;                            
                            tabla.Add(temp1);  nutknen++; concatenar = "";
                        }
                        break;
                    case 2:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 2; concatenar += cadena[i]; fila++; columna++;
                        }
                        else if (char.IsNumber(cadena[i])) // numeros
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else // Estado de aceptación
                        {
                            Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                            Lista temp1 = new Lista();
                            Grafica ft = new Grafica();
                            temp1.numero = "" + nutknen;
                            temp1.fila = "" + fila;
                            temp1.columna = "" + columna;
                            temp1.idtkn = "7";
                            temp1.tkn = "Numero";
                            temp1.lexema = concatenar;
                            ft.codigo = concatenar;
                            ft.gtkn = "Numero";
                            tabla.Add(temp1); grafica.Add(ft); nutknen++; concatenar = "";                            
                        }
                        break;
                    case 3:
                        Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                        Lista item = new Lista();                        
                        item.numero = "" + nutknen;
                        item.fila = "" + fila;
                        item.columna = "" + columna;
                        item.idtkn = "" + idtkn;
                        item.tkn = token;
                        item.lexema = concatenar;                                                
                        tabla.Add(item); nutknen++; concatenar = "";
                        break;
                    case 4:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 4; concatenar += cadena[i]; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i])) // letras
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        else // Estado error
                        {
                            string tokenerror = ""; tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            Etabla.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;
                    case 5:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 5; concatenar += cadena[i]; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i])) // letras
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)34).Equals(cadena[i])) // comillas
                        {
                            estado = 6; concatenar += cadena[i]; columna++;
                        }
                        else // Estado de error
                        {
                            string tokenerror = ""; tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            Etabla.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;
                    case 6:
                        Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                        Lista item2 = new Lista();
                        Grafica valor = new Grafica();
                        item2.numero = "" + nutknen;
                        item2.fila = "" + fila;
                        item2.columna = "" + columna;
                        item2.idtkn = "" + idtkn;
                        item2.tkn = token;
                        item2.lexema = concatenar;
                        valor.nombre = concatenar;
                        valor.gtkn = "cadena";
                        tabla.Add(item2); grafica.Add(valor); nutknen++; concatenar = "";
                        break;
                }
            }
            MessageBox.Show("Su analisis se a hecho con exito.", "Información");
        }

        public void Analizartkn(String tkn)
        {
            switch (tkn)
            {
                //case "organigrama":
                //    token = "Palabra reservada ORGANIGRAMA"; idtkn = 1;
                //    break;
                //case "trabajador":
                //    token = "Palabra reservada TRABAJADOR"; idtkn = 2;
                //    break;
                //case "codigo":
                //    token = "Palabra reservada CODIGO"; idtkn = 3;
                //    break;
                //case "nombre":
                //    token = "Palabra reservada NOMBRE"; idtkn = 4;
                //    break;
                //case "superiores":
                //    token = "palabra reservada SUPERIORES"; idtkn = 5;
                //    break;
                case ",":
                    token = "Signo COMA"; idtkn = 2;
                    break;
                case ":":
                    token = "signo DOS PUNTOS"; idtkn = 3;
                    break;
                case "{":
                    token = "signo CORCHETES APERTURA"; idtkn = 4;
                    break;
                case "}":
                    token = "signo CORCHETES CERRADURA"; idtkn = 5;
                    break;
                case ";":
                    token = "signo PUNTO Y COMA"; idtkn = 6;
                    break;
                default:
                    token = "cadena"; idtkns++; idtkn = idtkns;
                    break;
            }
        }

        public void Mostrar()
        {
            reportes item = new reportes();
            item.ReporteToken(tabla);
            item.ReporteError(Etabla);
            Process.Start(@"C:\Users\libni\Desktop\ReporteToken.html");
            Process.Start(@"C:\Users\libni\Desktop\ReporteErrores.html");
        }

        public void Cambio()
        {            
            foreach (var item in tabla)
            {
                if (item.tkn == "Palabra Reservada")
                {
                    Console.WriteLine("color azul " + item.lexema);                    
                    //richTextBox1.ForeColor = Color.Blue;
                }
                else if (item.tkn == "Numero")
                {
                    Console.WriteLine("color amarillo " + item.lexema);
                    //richTextBox1.ForeColor = Color.Yellow;
                }
                else if (item.tkn == "Cadena")
                {
                    Console.WriteLine("color verde " + item.lexema);
                    //richTextBox1.ForeColor = Color.Green;
                }
                else if (item.lexema.Equals(":"))
                {
                    Console.WriteLine("color morado " + item.lexema);
                    //richTextBox1.ForeColor = Color.Purple;
                }
                else if (item.lexema.Equals(";"))
                {
                    Console.WriteLine("color rojo " + item.lexema);
                    //richTextBox1.ForeColor = Color.Red;
                }
                else if (item.lexema.Equals("{") && item.lexema.Equals("}"))
                {
                    Console.WriteLine("color rosado " + item.lexema);
                    //richTextBox1.ForeColor = Color.Pink;
                }
                else if (item.lexema.Equals(","))
                {
                    Console.WriteLine("color celeste " + item.lexema);
                    //richTextBox1.ForeColor = Color.SkyBlue;
                }
            }
        }

        string a;
        string b;
        string resultado;


        Boolean insertar = false;
        Boolean insertar2 = false;
        String puntero = "";
        String punteroi = "";

        Boolean sinsertar = false;
        public void Graficotxt()
        {
            StreamWriter Archivo = new StreamWriter("C:\\Users\\libni\\Desktop\\" + "Comandos" + ".txt");
            Archivo.WriteLine("digraph grafica{"); // lenguaje de graphviz
            Archivo.WriteLine("rankdir=TB;");
            Archivo.WriteLine("node [shape = record, style=filled, fillcolor=seashell2];");
            //foreach (var dato in grafica)

            foreach (var dato in tabla)
            {
                String temp = dato.lexema.Trim();

                if (temp.Equals("superiores"))
                {
                    sinsertar = true;
                }
                if (sinsertar)
                {
                    if (dato.tkn.Equals("Numero"))
                    {
                        puntero += punteroi +"->nodo" + dato.lexema.Trim()+";";

                    }
                }
                if (temp.Equals("codigo") || temp.Equals("nombre"))
                {
                        insertar = true;
                    //para quitar superiores
                    sinsertar = false;
                }
                if (insertar)
                {
                    if (dato.tkn.Equals("Numero"))
                    {
                        a = dato.lexema;
                        insertar = false;
                        //puntero
                        punteroi = "nodo" + dato.lexema.Trim();
                    }
                    if (dato.tkn.Equals("cadena"))
                    {
                        b = "|" +dato.lexema;
                        b = b.Replace('\"', ' ');
                        b = b.Trim();
                        insertar = false;
                        insertar2 = true;
                    }                
                }
                if (insertar2)
                {

                    string resultado = a + b;
                    Archivo.WriteLine("nodo" + a + "[ label = \"codigo: " + resultado + "\"]");                   
                    insertar2 = false;
                }
            }
            Archivo.WriteLine(puntero);
            Archivo.WriteLine("}");
            Archivo.Close();
        }
    }
}