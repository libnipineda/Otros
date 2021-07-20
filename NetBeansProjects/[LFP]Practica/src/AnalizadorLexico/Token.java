/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AnalizadorLexico;

import java.util.*;
import ListasPractica.ListaTkn;
import ListasPractica.ListaError;
import Reporte.HTML;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
import org.omg.CORBA.Environment;

/**
 *
 * @author libni
 */
public class Token {
List<ListaError> ELista = new ArrayList<ListaError>();
List<ListaTkn> Lista = new ArrayList<ListaTkn>();
     int idtkn;
     int nutknen = 0;
     int idtkns = 12; // numero de tokens definidos
     int fila = 0;
     int columna = 0;
     String token = "";
     private String retorno,retorno1;
     
public void Scanner(String entrada)
{
    int estado = 0;
    String concatenar="";
    String Econcatenar = "";
    // uso de codigo ascii
     char tab,salto,espacio,dosp,coma,llaveA,llaveC,ptocoma,comillas;
     tab= (char)9; salto =(char)10; espacio=(char)32;
     dosp = (char)58; ptocoma =(char)59; coma =(char)44; llaveA = (char)123; llaveC = (char)125; comillas = (char)34;
    
    for(int i=0; i < entrada.length(); i++)
     {
         switch(estado)
        {
           case 0:
               //tab salto espacio
                if(entrada.charAt(i)==(tab) || entrada.charAt(i)==(salto) || entrada.charAt(i)==(espacio))
                {
                  estado = 0; concatenar += entrada.charAt(i); fila++; columna++;
                }
                else if(Character.isLetter(entrada.charAt(i)))
                {
                    estado = 1; concatenar += entrada.charAt(i); columna++;
                }
                else if(Character.isDigit(entrada.charAt(i)))
                {
                    estado = 2; concatenar += entrada.charAt(i); columna++;
                }
                else if(entrada.charAt(i)==(dosp) || entrada.charAt(i)==(coma) || entrada.charAt(i)==(llaveA) || entrada.charAt(i)==(llaveC) || entrada.charAt(i)==(ptocoma)) // Signos ':'|| ',' || '{' || '}' || ';'
                 {                     
                     estado = 3; concatenar += entrada.charAt(i); columna++;
                 }
                else if(entrada.charAt(i)==(comillas))
                 {
                     estado = 4; concatenar += entrada.charAt(i); columna++;
                 }
                else
                {
                    Econcatenar += entrada.charAt(i);
//                    temp.Enumero= ""+nutknen;
//                    temp.Elexema= Econcatenar;
//                    temp.Ecolumna= "" + columna;
//                    temp.Etkn= "Valor desconocido.";
//                    temp.Eidtkn = "" + idtkn;
//                    Etabla.add(temp);
                     agregarError(nutknen,Econcatenar,columna,"Valor desconocido",idtkn);
                    nutknen++; concatenar=""; Econcatenar="";
                }
               break;
           case 1:
               if(entrada.charAt(i)==(tab) || entrada.charAt(i)==(salto) || entrada.charAt(i)==(espacio))
                {
                  estado = 1; concatenar += entrada.charAt(i); fila++; columna++;
                }
               else if(Character.isLetter(entrada.charAt(i)))
                {
                    estado = 1; concatenar += entrada.charAt(i); columna++;
                }
               else
               {
                AnalizarTkn(concatenar); 
                i--; 
                estado = estado -1; 
                estado=0;
//                aux.setNumero("" +nutknen);
//                aux.setFila(""+fila);                
//                aux.setColumna( ""+columna);
//                aux.setIdtkn(""+idtkn);
//                aux.setTkn(token);
//                aux.setLexema(concatenar);
//                System.out.println("Estado 1");
//                System.out.println("numero: " +nutknen+" fila: " +fila+" columna: " + columna+" idtkn: " + idtkn+" token: " + tkn+" Lexema: " + concatenar);
//                tabla.add(aux);
                agregarTkn(nutknen,concatenar,fila,columna,idtkn,token);
                nutknen++; concatenar = "";
               }
               break;
           case 2:
               if(entrada.charAt(i)==(tab) || entrada.charAt(i)==(salto) || entrada.charAt(i)==(espacio))
                {
                  estado = 2; concatenar += entrada.charAt(i); fila++; columna++;
                }
               else if(Character.isDigit(entrada.charAt(i)))
                 {
                     concatenar += entrada.charAt(i);
                     estado = 2;
                 }
               else               
               {
                AnalizarTkn(concatenar); 
                i--; 
                estado = estado -1; 
                estado=0;                  
//                aux.setNumero("" +nutknen);
//                aux.setFila(""+fila);                
//                aux.setColumna( ""+columna);
//                aux.setIdtkn(""+idtkn);
//                aux.setTkn(token);
//                aux.setLexema(concatenar);
////              System.out.println("Estado 2");
//                System.out.println("numero: " +nutknen+" fila: " +fila+" columna: " + columna+" idtkn: " + idtkn+" token: " + tkn+" Lexema: " + concatenar);
//                tabla.add(aux);        
                agregarTkn(nutknen,concatenar,fila,columna,12,"Numero");                
                nutknen++; concatenar = "";   
               }
               break;
           case 3:
                AnalizarTkn(concatenar);
                i--; 
                estado = estado -1; 
                estado=0;                  
//                aux.setNumero("" +nutknen);
//                aux.setFila(""+fila);                
//                aux.setColumna( ""+columna);
//                aux.setIdtkn(""+idtkn);
//                aux.setTkn(token);
//                aux.setLexema(concatenar);
////                System.out.println("Estado 3");
//                System.out.println("numero: " +nutknen+" fila: " +fila+" columna: " + columna+" idtkn: " + idtkn+" token: " + tkn+" Lexema: " + concatenar);
//                tabla.add(aux);        
                agregarTkn(nutknen,concatenar,fila,columna,idtkn,token);               
                nutknen++; concatenar = "";
               break;
           case 4:
               if(entrada.charAt(i)==(tab) || entrada.charAt(i)==(salto) || entrada.charAt(i)==(espacio))
                {
                  estado = 4; concatenar += entrada.charAt(i); fila++; columna++;
                }
               else
               {
                 estado = 5; concatenar += entrada.charAt(i); columna++;
               }
               break;    
           case 5:
               if(entrada.charAt(i)==(tab) || entrada.charAt(i)==(salto) || entrada.charAt(i)==(espacio))
                {
                  estado = 5; concatenar += entrada.charAt(i); fila++; columna++;
                }
               else if(entrada.charAt(i)==(comillas))
                 {
                  estado = 6;   concatenar += entrada.charAt(i); columna++;                  
                 }
                 else                     
                 {
                  estado = 5;    concatenar += entrada.charAt(i); columna++;                  
                 }
               break;
           case 6:
               AnalizarTkn(concatenar); 
               i--; 
               estado = estado -1; 
               estado=0;                  
//                aux.setNumero("" +nutknen);
//                aux.setFila(""+fila);                
//                aux.setColumna( ""+columna);
//                aux.setIdtkn(""+idtkn);
//                aux.setTkn(token);
//                aux.setLexema(concatenar);
////                System.out.println("Estado 6");
//                System.out.println("numero: " +nutknen+" fila: " +fila+" columna: " + columna+" idtkn: " + idtkn+" token: " + tkn+" Lexema: " + concatenar);
//                tabla.add(aux);                      
                agregarTkn(nutknen,concatenar,fila,columna,idtkn,token);               
                nutknen++; concatenar = "";
               break;
        }         
     }
    JOptionPane.showMessageDialog(null,"Su analisis se a hecho con exito.");    
}

public void AnalizarTkn(String tkn)
{
    tkn.trim();
    switch(tkn)
    {
        case "pensum":
             token="Palabra Reservada."; idtkn =1;
             break;
         case ":":
             token="Signo dos puntos."; idtkn =2;
                 break;
         case "{":
             token="Signo Llave Apertura"; idtkn =3;
                 break;
         case "curso":
             token ="Palabra Reservada."; idtkn =4;
                 break;
         case "codigo":
             token ="Palabra Reservada."; idtkn =5;
                 break;
         case ";":
             token = "Signo dos puntos y coma."; idtkn=6;
                 break;
         case "nombre":
             token="Palabra Reservada."; idtkn=7;
                 break;
         case "creditos":
             token="Palabra Reservada."; idtkn=8;
                 break;
         case "prerrequisitos": 
             token="Palabra Reservada."; idtkn=9;
                 break;
         case "}":
             token="Signo Llave de Cierre."; idtkn=10;
                 break;
         case ",":
             token="Signo de coma."; idtkn=11;
                 break;         
         default:
             token = "cadena"; idtkns++; idtkn = idtkns;
             break;
    }
}        

public void agregarTkn(int numero, String lexema, int fila, int columna, int idtkn, String tkn)
{
    ListaTkn nuevo = new ListaTkn(numero,lexema,fila,columna,idtkn,tkn);
    Lista.add(nuevo);
    //String prueba = Lista.toString();
    //System.out.println(prueba);
}

public void agregarError(int Enumero, String Elexema, int Ecolumna, String Etkn, int Eidtkn)
{
    ListaError aux = new ListaError(Enumero,Elexema,Ecolumna,Etkn,Eidtkn);
    ELista.add(aux);    
}

public void generarListaA()
{   
    for(int i=0; i < Lista.size(); i++)
    {
        System.out.println("valores en la lista: "+ Lista.toString());
    } 
}

public void generarListaB()
{
    for(int i=0; i < ELista.size(); i++)
    {
        System.out.println("valores en la lista de errores: "+ ELista.toString());
    } 
}

 public void ReporteTkn()
 {     
     HTML reporte = new HTML();
     reporte.ReporteToken(Lista);
     //generarListaA();
 }

 public void ReporteE()
 {     
     HTML reporte = new HTML();
     reporte.ReporteError(ELista);
 }
 
//----------------------------------------------------------------- Funcionalidad ---------------------------------------------------------------------------
 String a,b,c,resultado,puntero ="",punteroi="";
 Boolean insertar = false, insertar2 = false, sinsertar=false;
 
 public void Graficotxt()
 {
    try
           {
               File txt = new File("C:/Users/libni/Desktop/CodigoDot.txt");
               if(!txt.exists())
               {
                   txt.createNewFile();
               }
               FileWriter fw = new FileWriter(txt);
               BufferedWriter bw = new BufferedWriter(fw);
               bw.write("digraph grafica{");
               bw.write("rankdir=TB;");
               bw.write("node [shape = record];");               
               for(ListaTkn dato: Lista)
               {
                   String temp = dato.lexema;
                   
                   if(temp.equals("prerrequisitos"))
                   {
                       sinsertar = true;
                   }
                   if(sinsertar)
                   {
                       if(dato.tkn.equals("Numero"))
                       {
                           puntero += punteroi + "-> nodo" + dato.lexema + ";";
                       }
                   }
                   if(temp.equals("codigo") || temp.equals("nombre") || temp.equals("creditos"))
                   {
                       insertar = true;
                       sinsertar = false;
                   }                   
                   if(insertar)
                   {
                       if(dato.tkn.equals("Numero"))
                       {
                          a = dato.lexema;
                          insertar = false;                       
                          punteroi = "nodo" + dato.lexema;
                       }
                       if(dato.tkn.equals("cadena"))
                       {
                           b = "|" +dato.lexema;
                           b = b.replace('\"',' ');                                                      
                           b = b.trim();
                           insertar = false;
                           insertar2 = true;
                       }        
                       if(dato.tkn.equals("Numero"))
                       {
                           c = dato.lexema;
                           insertar = false;
                           punteroi = "nodo" + dato.lexema;
                       }
                   }
                   if(insertar2)
                   {
                       String resultado = a+b+c;
                       //bw.write("nodo" + a + "[ label = \"codigo: " + resultado + "\"]");
                       bw.write("nodo"+a+"[label ={"+b+"|{"+c+"}}|"+resultado+"|]");
                       insertar2 = false;
                   }
               }    
               bw.write(puntero);
               bw.write("}");               
               bw.close();
               JOptionPane.showMessageDialog(null,"Archivo creado");
           }catch(Exception e)
           {               
               e.printStackTrace();
               JOptionPane.showMessageDialog(null,"No se pudo crear el archivo");
           }    
 }
   
}