using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto1
{
    class Analisis
    {
        List<Lista> Datos = new List<Lista>();
        List<ListaError> Edatos = new List<ListaError>();
        List<Musica> musica = new List<Musica>();
        int idtkn;
        int nutknen = 0;
        int idtkns = 16;
        int fila = 0;
        int columna = 0;
        string token = "";
        string concatenar = "";
        string tokenerror = "";
        Boolean insert = false; // insertar
        Boolean ninsert = false; // no insertar

        public List<Musica> lista_musica()
        {
            return musica;
        }

        public void Lexico(String cadena)
        {
            int estado = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                
                switch (estado)
                {
                    case 0:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 0; fila++; columna++;
                        }
                        else if (((char)47).Equals(cadena[i]) | ((char)34).Equals(cadena[i]) | ((char)61).Equals(cadena[i]) | ((char)60).Equals(cadena[i]) | ((char)62).Equals(cadena[i])) // caracter  '\' '"' '=' '<' '>'
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 1:
                        Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                        Lista temp1 = new Lista();
                        temp1.numero = "" + nutknen;
                        temp1.fila = "" + fila;
                        temp1.columna = "" + columna;
                        temp1.idtkn = "" + idtkn;
                        temp1.tkn = "Signos";
                        temp1.lexema = concatenar;
                        //Console.WriteLine("dato: " + concatenar);
                        Datos.Add(temp1); nutknen++; concatenar = "";
                        break;

                    case 2:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 2; fila++; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)58).Equals(cadena[i])) // caracter :
                        {
                            estado = 4; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            i--; estado = estado - 1; estado = 0;
                            Lista temp = new Lista();
                            temp.numero = "" + nutknen;
                            temp.fila = "" + fila;
                            temp.columna = "" + columna;
                            temp.idtkn = "2";
                            temp.tkn = "Numero";
                            temp.lexema = concatenar;
                            //Console.WriteLine("dato: " + concatenar);
                            Datos.Add(temp); nutknen++; concatenar = "";
                        }
                        break;

                    case 3:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) /*| ((char)32).Equals(cadena[i])*/) // tecla tab, salto de linea , espacio
                        {
                            estado = 3; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)95).Equals(cadena[i])) // caracter '_'
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if(((char)58).Equals(cadena[i])) // caracter ':'
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                            Lista temp = new Lista();
                            temp.numero = "" + nutknen;
                            temp.fila = "" + fila;
                            temp.columna = "" + columna;
                            temp.idtkn = "" + idtkn;
                            temp.tkn = token;
                            temp.lexema = concatenar;
                            //Console.WriteLine("dato: " + concatenar);
                            Datos.Add(temp); nutknen++; concatenar = "";
                        }
                        break;

                    case 4:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 4; fila++; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 6; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 5:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 5; fila++; columna++;
                        }
                        else if (((char)92).Equals(cadena[i])) // caracter '\'
                        {
                            estado = 7; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + concatenar);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 6:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 6; fila++; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 6; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            i--; estado = estado - 1; estado = 0;
                            Lista temp = new Lista();
                            Musica aux = new Musica();
                            temp.numero = "" + nutknen;
                            temp.fila = "" + fila;
                            temp.columna = "" + columna;
                            temp.idtkn = "3";
                            temp.tkn = "Tiempo";
                            temp.lexema = concatenar;
                            aux.duracion = concatenar;
                            musica.Add(aux);
                            Datos.Add(temp); nutknen++; concatenar = "";
                        }
                        break;

                    case 7:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 7; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 8:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 8; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)95).Equals(cadena[i])) // caracter '_'
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)92).Equals(cadena[i])) // caracter '\'
                        {
                            estado = 9; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)46).Equals(cadena[i])) // caracter '.'
                        {
                            estado = 10; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)45).Equals(cadena[i])) // caracter '-'
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 9:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 9; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 10:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 10; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 11:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 11; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)95).Equals(cadena[i])) // caracter '_'
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)92).Equals(cadena[i])) // caracter '\'
                        {
                            estado = 9; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)46).Equals(cadena[i])) // caracter '.'
                        {
                            estado = 10; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)45).Equals(cadena[i])) // caracter -
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            tokenerror += cadena[i];
                            ListaError aux = new ListaError();
                            aux.Enumero = "" + nutknen;
                            aux.Efila = "" + fila;
                            aux.Ecolumna = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elexema = tokenerror;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutknen++; concatenar = ""; tokenerror = "";
                        }
                        break;

                    case 12:
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 12; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)95).Equals(cadena[i])) // caracter '_'
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                            Lista temp = new Lista();
                            Musica ms = new Musica();
                            temp.numero = "" + nutknen;
                            temp.fila = "" + fila;
                            temp.columna = "" + columna;
                            temp.idtkn = "15";
                            temp.tkn = "Direccion URL";
                            temp.lexema = concatenar;
                            ms.url = concatenar;
                            //Console.WriteLine("dato: " + concatenar);
                            musica.Add(ms);
                            Datos.Add(temp); nutknen++; concatenar = "";
                        }
                        break;
                }
            }
            MessageBox.Show("Su analisis ha concluido", "Información");
        }

        public void Analizartkn(String tkn)
        {
            tkn.Trim();           
            switch (tkn)
            {                
                case "Playlist":
                    token = "Palabra reservada"; idtkn = 4;
                    break;

                case "playlist":
                    token = "Palabra reservada"; idtkn = 4;
                    break;

                case "<":
                    idtkn = 5;
                    break;

                case ">":
                    token = "Etiqueta de apertura"; idtkn = 6;
                    break;

                case "Cancion":
                    token = "Palabra reservada"; idtkn = 7;
                    break;

                case "cancion":
                    token = "Palabra reservada"; idtkn = 7;
                    break;

                case "Repeticion":
                    token = "Palabra reservada"; idtkn = 8;
                    break;

                case "repeticion":
                    token = "Palabra reservada"; idtkn = 8;
                    break;

                case "/":
                    idtkn = 9;
                    break;

                case "url":
                    token = "Palabra reservada"; idtkn = 10;
                    break;

                case "artista":
                    token = "Palabra reservada"; idtkn = 11;
                    break;

                case "álbum":
                    token = "Palabra reservada"; idtkn = 12;
                    break;

                case "album":
                    token = "Palabra reservada"; idtkn = 12;
                    break;

                case "año":
                    token = "Palabra reservada"; idtkn = 13;
                    break;

                case "duración":
                    token = "Palabra reservada"; idtkn = 14;
                    break;

                case "nombre":
                    token = "Palabra reservada"; idtkn = 15;
                    break;

                case "Nombre":
                    token = "Palabra reservada"; idtkn = 15;
                    break;

                case "nveces":
                    token = "Palabra reservada"; idtkn = 16;
                    break;

                default:
                    token = "Cadena"; idtkns++; idtkn = idtkns;
                    break;
            }
        }

        public void TablaTokens()
        {
            if (MessageBox.Show("Espere en un momento se abrira el archivo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                ReportesHTML item = new ReportesHTML();
                item.ReporteToken(Datos);
                Process.Start(@"C:\Users\libni\Desktop\ReporteToken.html");
            }
        }

        public void TablaErrores()
        {
            if (MessageBox.Show("Espere en un momento se abrira el archivo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                ReportesHTML item1 = new ReportesHTML();
                item1.ReporteError(Edatos);
                Process.Start(@"C:\Users\libni\Desktop\ReporteErrores.html");
            }
        }        

        public void pasa()
        {
            foreach (var item in Datos)
            {  // Busca el nombre de la playlist

                if (item.lexema.Equals("nombre"))
                {
                    ninsert = true;
                }
                if (ninsert)
                {
                   if (item.tkn.Equals("Cadena"))
                   {
                        Console.WriteLine("nombre pl: " + item.lexema);
                        Musica aux = new Musica();
                        aux.nombreP = item.lexema;
                        musica.Add(aux);
                        ninsert = false;
                   }
                }

                // Busca el artista

                if (item.idtkn.Equals("11"))
                {
                    ninsert = true;
                }
                  if (ninsert)
                  {
                    if(item.lexema.Equals("="))
                    {
                      if (item.tkn.Equals("Cadena"))
                      {
                        Console.WriteLine("nombre artista: " + item.lexema);
                        ninsert = false;
                      }
                    }                    
                  }

                // Busca el album

                if (item.idtkn.Equals("12"))
                {
                    ninsert = true;
                }
                if (ninsert)
                {
                    if (item.tkn.Equals("Cadena"))
                    {
                        Console.WriteLine("nombre del album: " + item.lexema);
                        ninsert = false;
                    }
                }

                //Busca el año

                if (item.lexema.Equals("año"))
                {
                    ninsert = true;
                }
                 if (ninsert)
                 {
                    if (item.tkn.Equals("Numero"))
                    {
                        Console.WriteLine("numero: " + item.lexema);
                        Musica aux = new Musica();
                        aux.año = item.lexema;
                        musica.Add(aux);
                        ninsert = false;
                    }
                 }

                //Busca nveces

                if (item.idtkn.Equals("8"))
                {
                    ninsert = true;
                }
                  if (ninsert)
                  {
                     if(item.lexema.Equals("="))
                     {
                        if (item.tkn.Equals("Numero"))
                        {
                            Console.WriteLine("nveces: " + item.lexema);
                            Musica aux = new Musica();
                            aux.nveces = item.lexema;
                            musica.Add(aux);
                            ninsert = false;
                        }
                     }                    
                  }  
            }
        }
    }
}