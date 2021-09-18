﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2_201403541
{
    class Lexico
    {
        List<Lista> ListaA = new List<Lista>();        
        List<Elista> ListaB = new List<Elista>();

        public int numerrorlex;

        int idtkn, nutknen = 0, fila = 1, columna = 1;
        string token = "";
        String concatenar = "", Etoken = "";

        public void Scanner(string cadena)
        {
            int estado = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                switch (estado)
                {
                    case 0:
                        if (((char)09).Equals(cadena[i]) || ((char)32).Equals(cadena[i]))// tecla tab, espacio
                        {
                            estado = 0;
                        } 
                        else if (((char)10).Equals(cadena[i]))// salto de linea
                        {
                            estado = 0; fila++; columna++;
                        } 
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)40).Equals(cadena[i]) || ((char)41).Equals(cadena[i]) || ((char)91).Equals(cadena[i]) || ((char)93).Equals(cadena[i]) || ((char)123).Equals(cadena[i]) || ((char)125).Equals(cadena[i])) // signo "(" ")" "[" "]" "{" "}"
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)46).Equals(cadena[i]) || ((char)59).Equals(cadena[i]) || ((char)44).Equals(cadena[i]) || ((char)42).Equals(cadena[i]) || ((char)60).Equals(cadena[i]) || ((char)62).Equals(cadena[i]) || ((char)33).Equals(cadena[i])  || ((char)58).Equals(cadena[i])) // signo "." ";" "," "*" "<" ">" "!"  ":"
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)43).Equals(cadena[i]) || ((char)45).Equals(cadena[i]) || ((char)61).Equals(cadena[i])) // signo "+" "-" "=" 
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)34).Equals(cadena[i])) // signo "
                        {
                            estado = 4; concatenar += cadena[i]; columna++;
                        } 
                        else if (((char)39).Equals(cadena[i]))  // signo '
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)47).Equals(cadena[i])) // signo /
                        {
                            estado = 6; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            Etoken += cadena[i];
                            Elista temp = new Elista();
                            temp.Enum = nutknen;
                            temp.Efila = fila;
                            temp.Ecolumna = columna;
                            temp.Elex = "" + Etoken;
                            temp.Etkn = "Valor Desconocido.";
                            ListaB.Add(temp); nutknen++; concatenar = ""; Etoken = "";
                        }
                        break;

                    case 1:
                        if (((char)46).Equals(cadena[i]))
                        {
                            estado = 7; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }                        
                        else
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, 2, "Numero.", fila, columna);
                            nutknen++; concatenar = "";
                        }
                        break;

                    case 2:
                        AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                        AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                        nutknen++; concatenar = "";
                        break;

                    case 3:
                        if (char.IsLetter(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)95).Equals(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                            nutknen++; concatenar = "";
                        }
                        break;

                    case 4:
                        if (((char)34).Equals(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 5:
                        if (((char)39).Equals(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 9; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 6:
                        if (((char)47).Equals(cadena[i]))
                        {
                            estado = 10; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                            nutknen++; concatenar = "";
                        }
                        break;

                    case 7:
                        if (char.IsNumber(cadena[i]))
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 8:
                        if (((char)34).Equals(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 8; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 9:
                        if (((char)39).Equals(cadena[i]))
                        {
                            estado = 12; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 9; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 10:
                        if (((char)42).Equals(cadena[i]))
                        {
                            estado = 13; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 14; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 11:
                        if (char.IsNumber(cadena[i]))
                        {
                            estado = 11; concatenar += cadena[i]; columna++;
                        }                        
                        else
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, 48, "Decimal.", fila, columna);
                            nutknen++; concatenar = "";
                        }
                        break;

                    case 12:
                        AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                        AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                        nutknen++; concatenar = "";
                        break;

                    case 13:
                        if (((char)10).Equals(cadena[i]))
                        {
                            estado = 14; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 13; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 14:
                        if (((char)42).Equals(cadena[i]))
                        {
                            estado = 15; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)10).Equals(cadena[i]))
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                            nutknen++; concatenar = "";
                        }                        
                        else
                        {
                            estado = 14; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 15:
                        if (((char)47).Equals(cadena[i]))
                        {
                            estado = 16; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 16:
                        if (((char)47).Equals(cadena[i]))
                        {
                            estado = 17; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 17:
                        AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                        AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                        nutknen++; concatenar = "";
                        break;
                }
            }
            MessageBox.Show("Analisis Concluido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AnalizarTkn(string tkn)
        {
            tkn.Trim();
            switch (tkn)
            {
                case "class":
                    token = "Palabra Reservada."; idtkn = 1;
                    break;

                case "static":
                    token = "Palabra Reservada."; idtkn = 3;
                    break;

                case "void":
                    token = "Palabra Reservada."; idtkn = 4;
                    break;

                case "Main":
                    token = "Palabra Reservada."; idtkn = 5;
                    break;

                case "(":
                    token = "Signo de parentesis abierto."; idtkn = 6;
                    break;               

                case "args":
                    token = "Palabra Reservada."; idtkn = 7;
                    break;

                case ")":
                    token = "Signo de parentesis que cierra."; idtkn = 8;
                    break;

                case "{":
                    token = "Signo de llave que abre."; idtkn = 9;
                    break;

                case "}":
                    token = "Signo llave que cierra"; idtkn = 10;
                    break;

                case "int":
                    token = "Palabra Reservada, se utiliza para declara numeros enteros."; idtkn = 11;
                    break;

                case "float":
                    token = "Palabra Reservada, se utiliza para declara numeros con decimal."; idtkn = 12;
                    break;

                case "bool":
                    token = "Palabra Reservada, se utiliza en variables boolenas."; idtkn = 13;
                    break;

                case "char":
                    token = "Palabra Reservada, se utiliza en variables tipo caracter."; idtkn = 14;
                    break;

                case "string":
                    token = "Palabra Reservada, se utiliza en  variables tipo cadena."; idtkn = 15;
                    break;

                case "String":
                    token = "Palabra Reservada, se utiliza en  variables tipo cadena."; idtkn = 15;
                    break;

                case ",":
                    token = "Signo de coma."; idtkn = 16;
                    break;

                case ".":
                    token = "Signo de punto."; idtkn = 17;
                    break;

                case ";":
                    token = "Signo de punto y coma."; idtkn = 18;
                    break;

                case "/":
                    token = "Signo de division."; idtkn = 19;
                    break;

                case "=":
                    token = "Signo igual."; idtkn = 20;
                    break;

                case "==":
                    token = "Signo de operador."; idtkn = 21;
                    break;

                case ">":
                    token = "Signo de operador."; idtkn = 22;
                    break;

                case "<":
                    token = "Signo de operador."; idtkn = 23;
                    break;

                case "!=":
                    token = "Signo de operador."; idtkn = 24;
                    break;

                case "+":
                    token = "Signo de operador."; idtkn = 25;
                    break;

                case "-":
                    token = "Signo de operador."; idtkn = 26;
                    break;

                case "*":
                    token = "Signo de operador."; idtkn = 27;
                    break;

                case "Console":
                    token = "Palabra Reservada."; idtkn = 28;
                    break;

                case "WriteLine":
                    token = "Palabra Reservada."; idtkn = 29;
                    break;

                case "[":
                    token = "Signos de corchetes que abre."; idtkn = 30;
                    break;

                case "]":
                    token = "Signo corchete que cierra."; idtkn = 31;
                    break;

                case "new":
                    token = "Palabra Reservada."; idtkn = 32;
                    break;

                case "if":
                    token = "Ciclo if."; idtkn = 33;
                    break;

                case "else":
                    token = "Ciclo if."; idtkn = 34;
                    break;

                case "switch":
                    token = "Sentencia Switch."; idtkn = 35;
                    break;

                case "case":
                    token = "Sentencia Switch."; idtkn = 36;
                    break;

                case "break":
                    token = "Sentencia Switch."; idtkn = 37;
                    break;

                case "default":
                    token = "Sentecia Switch."; idtkn = 38;
                    break;

                case ":":
                    token = "Signo dos puntos."; idtkn = 39;
                    break;

                case "for":
                    token = "Ciclo for."; idtkn = 40;
                    break;

                case "<=":
                    token = "Operador."; idtkn = 41;
                    break;

                case ">=":
                    token = "Operador."; idtkn = 42;
                    break;

                case "while":
                    token = "Ciclo while."; idtkn = 43;
                    break;

                case "true":
                    token = "Palabra Reservada."; idtkn = 44;
                    break;

                case "false":
                    token = "Palabra Reservada."; idtkn = 45;
                    break;

                case "graficarVector":
                    token = "Palabra Reservada."; idtkn = 47;
                    break;

                default:
                    token = "Cadena"; idtkn = 46;
                    break;
            }
        }

        public void AgregarListaA(int num, string lexema, int idtkn, string tkn, int fila, int columna)
        {
            Lista aux = new Lista(num, lexema, idtkn, tkn, fila, columna);
            aux.Numero = num;
            aux.Lexema = lexema.Trim();
            aux.Idtkn = idtkn;
            aux.Tkn = tkn;
            aux.Fila = fila;
            aux.Columna = columna;
            ListaA.Add(aux);
        }

        public void Reporte1()
        {
            try
            {
                MessageBox.Show("Espere en un momento se abrira el reporte de token´s", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reporte item = new Reporte();
                item.ReporteTkn(ListaA);
                Process.Start(@"C:\Users\libni\OneDrive\Escritorio\ReporteToken.html");                
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el reporte de Token´s", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reporte2()
        {
            if (ListaB.Count != 0)
            {
                numerrorlex = 1; 
                Reporte html = new Reporte();
                html.ReporteE(ListaB);
                Process.Start(@"C:\Users\libni\OneDrive\Escritorio\ReporteError.html");
                Ejecutar();
            }
            else
            {
                numerrorlex = 0;
                MessageBox.Show("No se encontro errores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Reporte3()
        {

        }

        public void Ejecutar()
        {
            Sintactico sin = new Sintactico();
            int temp = sin.numerror;
            if (numerrorlex == 0 && temp == 0)
            {
                MessageBox.Show("Espere mientras se realiza la traduccion.", "Informacion");
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.ObtenerInfo(ListaA);
            }
            else
            {
                MessageBox.Show("Hay errores sintacticos, no se puede realizar la traduccion.", "Advertencia");
            }
        }

        public List<Lista> getToken()
        {
            return this.ListaA;
        }
    }
}