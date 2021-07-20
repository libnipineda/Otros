/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AnalizadorLexico;

import java.util.List;
import javax.swing.JOptionPane;
import ListasPractica.ListaTkn;
import ListasPractica.ListaError;
import java.util.ArrayList;
import Reporte.HTML; 
import java.awt.Desktop;
import java.io.*;
import java.util.Iterator;
import java.util.Spliterator;
import java.util.function.Predicate;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Stream;

/**
 *
 * @author libni
 */
//public class Automata {
// ArrayList<ListaTkn> tabla = new ArrayList<ListaTkn>();
// ArrayList<ListaError> Etabla = new ArrayList<ListaError>();
// int idtkn; int nutknen = 0; int idtkns=12; int fila =0; int columna=0;
// String token;
// String tokene =""; 
// int numnodo=0;
// ListaError temp = new ListaError();
// ListaTkn aux = new ListaTkn();
// 
// public void Lexico(String cadena)
// {        
//     String concatenar="";
//     int estado = 0;           
//     
//     // uso de codigo ascii
//     char tab,salto,espacio,dosp,coma,llaveA,llaveC,ptocoma,comillas;
//     tab= (char)9; salto =(char)10; espacio=(char)32;
//     dosp = (char)58; ptocoma =(char)59; coma =(char)44; llaveA = (char)123; llaveC = (char)125; comillas = (char)34;
//     
//     for(int i=0; i < cadena.length(); i++)
//     {
//        //JOptionPane.showMessageDialog(null,cadena.charAt(i));
//         switch(estado)
//        {
//           case 0:
//
//               //tab salto espacio
//                if(cadena.charAt(i)==(tab) || cadena.charAt(i)==(salto) || cadena.charAt(i)==(espacio))
//                {
//                  estado = 0; concatenar += cadena.charAt(i); fila++; columna++;
//                }
//                else if(Character.isLetter(cadena.charAt(i)))
//                {
//                    estado = 1; concatenar += cadena.charAt(i); columna++;
//                }
//                else if(Character.isDigit(cadena.charAt(i)))
//                {
//                    estado = 2; concatenar += cadena.charAt(i); columna++;
//                }
//                else if(cadena.charAt(i)==(dosp) || cadena.charAt(i)==(coma) || cadena.charAt(i)==(llaveA) || cadena.charAt(i)==(llaveC) || cadena.charAt(i)==(ptocoma)) // Signos ':'|| ',' || '{' || '}' || ';'
//                 {                     
//                     estado = 3; concatenar += cadena.charAt(i); columna++;
//                 }
//                else if(cadena.charAt(i)==(comillas))
//                 {
//                     estado = 4; concatenar += cadena.charAt(i); columna++;
//                 }
//                else
//                {
//                    tokene += cadena.charAt(i);                    
//                    temp.Enumero= ""+nutknen;
//                    temp.Elexema= tokene;
//                    temp.Ecolumna= "" + columna;
//                    temp.Etkn= "Valor desconocido.";
//                    temp.Eidtkn = "" + idtkn;
//                    Etabla.add(temp);
//                    //addEToken(errornum,errorlex,errorcol,errortkn,numidtkn);
//                    nutknen++; concatenar=""; tokene="";
//                }
//               break;
//           case 1:
//               if(cadena.charAt(i)==(tab) || cadena.charAt(i)==(salto) || cadena.charAt(i)==(espacio))
//                {
//                  estado = 1; concatenar += cadena.charAt(i); fila++; columna++;
//                }
//               else if(Character.isLetter(cadena.charAt(i)))
//                {
//                    estado = 1; concatenar += cadena.charAt(i); columna++;
//                }
//               else
//               {
////                  JOptionPane.showMessageDialog(null,concatenar);
//                   AnalizarTkn(concatenar); i--; estado = estado -1; estado=0;                       
//                      aux.numero = "" +nutknen;
//                      aux.lexema = "" +concatenar;
//                      aux.fila = ""+fila;
//                      aux.columna= ""+columna;
//                      aux.idtkn = ""+idtkn;
//                      aux.tkn = ""+token;
//                      tabla.add(aux);
//                      //addToken(num,lex,f,col,numtkn,tkn);
//                      nutknen++; concatenar = "";
//               }
//               break;
//           case 2:
//               if(cadena.charAt(i)==(tab) || cadena.charAt(i)==(salto) || cadena.charAt(i)==(espacio))
//                {
//                  estado = 2; concatenar += cadena.charAt(i); fila++; columna++;
//                }
//               else if(Character.isDigit(cadena.charAt(i)))
//                 {
//                     concatenar += cadena.charAt(i);
//                     estado = 2;
//                 }
//                 else
//                 {
//                   //JOptionPane.showMessageDialog(null,concatenar);
//                     AnalizarTkn(concatenar); i--; estado = estado -1; estado=0;                      
//                      aux.numero = "" +nutknen;
//                      aux.lexema = "" +concatenar;
//                      aux.fila = ""+fila;
//                      aux.columna= ""+columna;
//                      aux.idtkn = "12";
//                      aux.tkn = "Numero";
//                      tabla.add(aux);
//                      //addToken(num,lex,f,col,numtkn,tkn);
//                      nutknen++; concatenar = "";
//                 }
//               break;
//           case 3:
//                   //JOptionPane.showMessageDialog(null,concatenar);
//                    AnalizarTkn(concatenar); i--; estado = estado -1; estado=0;              
//                    aux.numero = "" +nutknen;
//                      aux.lexema = "" +concatenar;
//                      aux.fila = ""+fila;
//                      aux.columna= ""+columna;
//                      aux.idtkn = ""+idtkn;
//                      aux.tkn = ""+token;
//                      tabla.add(aux);                  
//                    //addToken(num,lex,f,col,numtkn,tkn);
//                    nutknen++; concatenar = "";
//               break;
//           case 4:
//               estado = 5; concatenar += cadena.charAt(i); columna++;
//               break;
//           case 5:
//               if(cadena.charAt(i)==(tab) || cadena.charAt(i)==(salto) || cadena.charAt(i)==(espacio))
//                {
//                  estado = 5; concatenar += cadena.charAt(i); fila++; columna++;
//                }
//               else if(cadena.charAt(i)==(comillas))
//                 {
//                  estado = 6;   concatenar += cadena.charAt(i); columna++;                  
//                 }
//                 else                     
//                 {
//                  estado = 5;    concatenar += cadena.charAt(i); columna++;                  
//                 }
//               break;
//           case 6:
//               //JOptionPane.showMessageDialog(null,concatenar);
//               AnalizarTkn(concatenar); i--; estado = estado -1; estado=0;                  
//                aux.numero = "" +nutknen;
//                      aux.lexema = "" +concatenar;
//                      aux.fila = ""+fila;
//                      aux.columna= ""+columna;
//                      aux.idtkn = ""+idtkn;
//                      aux.tkn = ""+token;
//                      tabla.add(aux);             
//                //addToken(num,lex,f,col,numtkn,tkn);
//                nutknen++; concatenar = "";
//               break;
//        }
//     }     
//     JOptionPane.showMessageDialog(null,"Su analisis se a hecho con exito.");
//     VerLista();
// }
// 
// public void AnalizarTkn(String tkn)
// {
//     tkn.trim();
//     switch(tkn)
//     {
//         case "pensum":
//             token="Palabra Reservada."; idtkn =1;
//             break;
//         case ":":
//             token="Signo dos puntos."; idtkn =2;
//                 break;
//         case "{":
//             token="Signo Llave Apertura"; idtkn =3;
//                 break;
//         case "curso":
//             token ="Palabra Reservada."; idtkn =4;
//                 break;
//         case "codigo":
//             token ="Palabra Reservada."; idtkn =5;
//                 break;
//         case ";":
//             token = "Signo dos puntos y coma."; idtkn=6;
//                 break;
//         case "nombre":
//             token="Palabra Reservada."; idtkn=7;
//                 break;
//         case "creditos":
//             token="Palabra Reservada."; idtkn=8;
//                 break;
//         case "prerrequisitos":
//             token="Palabra Reservada."; idtkn=9;
//                 break;
//         case "}":
//             token="Signo Llave de Cierre."; idtkn=10;
//                 break;
//         case ",":
//             token="Signo de coma."; idtkn=11;
//                 break;         
//         default:
//             token = "cadena"; idtkns++; idtkn = idtkns;
//             break;
//     }
// }
// 
// public void VerLista()
// {
//     for(ListaTkn item: tabla)
//     {
//         System.out.println("valor del idtkn: "+item.idtkn.toString());
//         System.out.println("valor del lexema: "+item.lexema.toString());
//         System.out.println("valor del tkn: "+item.tkn.toString());
//     }
// }
// 
// public void Imprimir() 
// {
//     HTML reporte = new HTML();
//     reporte.ReporteToken(tabla);
////     ProcessBuilder p = new ProcessBuilder("C:/Users/libni/Desktop/ReporteError.html");
////     try {
////         p.start();
////     } catch (IOException ex) {
////         Logger.getLogger(Automata.class.getName()).log(Level.SEVERE, null, ex);
////     }
// }
// 
// public void Imprimir1()
// {
//     HTML reporte = new HTML();
//     reporte.ReporteError(Etabla);
////     ProcessBuilder p = new ProcessBuilder("C:/Users/libni/Desktop/ReporteError.html");
////     try {
////         p.start();
////     } catch (IOException ex) {
////         Logger.getLogger(Automata.class.getName()).log(Level.SEVERE, null, ex);
////     }
// }
// 
// //----------------------------------------------------------------- Funcionalidad ---------------------------------------------------------------------------
// String a,b,resultado,puntero ="",punteroi="";
// Boolean insertar = false, insertar2 = false, sinsertar=false;
// 
// public void Graficotxt()
// {
//    try
//           {
//               File txt = new File("C:/Users/libni/Desktop/CodidoDot.txt");
//               if(!txt.exists())
//               {
//                   txt.createNewFile();
//               }
//               FileWriter fw = new FileWriter(txt);
//               BufferedWriter bw = new BufferedWriter(fw);
//               bw.write("digraph grafica{");
//               bw.write("rankdir=TB;");
//               bw.write("node [shape = record];");
//               
//               for(ListaTkn dato: tabla)
//               {
//                   String temp = dato.lexema;
//                   
//                   if(temp.equals("codigo"))
//                   {
//                       sinsertar = true;
//                   }
//                   if(sinsertar)
//                   {
//                       if(dato.tkn.equals("Numero"))
//                       {
//                           puntero += punteroi + "-> nodo" + dato.lexema + ";";
//                       }
//                   }
//                   if(temp.equals("nombre") || temp.equals("creditos") || temp.equals("prerrequisitos"))
//                   {
//                       insertar = true;
//                       sinsertar = false;
//                   }
//                   if(insertar)
//                   {
//                       
//                   }
//               }    
//               
//               
//               
//               
//               
//               
//               bw.close();
//               JOptionPane.showMessageDialog(null,"Archivo creado");
//           }catch(Exception e)
//           {               
//               e.printStackTrace();
//               JOptionPane.showMessageDialog(null,"No se pudo crear el archivo");
//           }    
// }
//
//}