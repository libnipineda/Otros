/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Reporte;

import ListasPractica.ListaTkn;
import ListasPractica.ListaError;
import java.awt.Desktop;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
/**
 *
 * @author libni
 */
public class HTML {    
    String Datos = "";
    String ListaB = "";
    ListaTkn Tkn;
    
    public void ReporteToken(List<ListaTkn> arreglo)
    {  
        if(arreglo.size() != 0)
        {
             try
        {            
         FileWriter archivo = new FileWriter("C:/Users/libni/Desktop/ReporteToken.html");
         PrintWriter write = new PrintWriter(archivo);
         write.println("<html>");
         write.println("<head>");
         write.println("<title> LFP PRACTICA NO. 1  TABLA DE TOKEN´S</title>");
         write.println("</head>");
         write.println("<body>");
         write.println("<h1> Listado de Tokens</h1>");
         write.println("<table border>");
         write.println("<tr>");
         write.println("<td><strong>No</strong></td>");
         write.println("<td><strong>Lexema</strong></td>");
         write.println("<td><strong>ID_Token</strong></td>");
         write.println("<td><strong>Token</strong></td>");         
         write.println("</tr>");
         write.println(Datos);
         write.println( "</table>");
         write.println("</body>");
         write.println( "</html>");
        archivo.close();
        Abrir();
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        }
        else
        { 
            JOptionPane.showMessageDialog(null, "Upss no hay datos en la lista");            
        }       
    }
    
    public void Abrir()
    {        
     try
     {
         File f = new File("C:/Users/libni/Desktop/ReporteToken.html");
         Desktop.getDesktop().open(f);
     }
     catch(IOException e)
     {
         e.printStackTrace();;
     }
     catch(IllegalArgumentException e)
     {
         JOptionPane.showMessageDialog(null, "Archivo no encontrado", "Error", JOptionPane.ERROR_MESSAGE);
         e.printStackTrace();
     }
    }
    
    public void ReporteError(List<ListaError> datos)
    {
        if(datos.size() != 0)
        {
            for(int i=0; i < datos.size(); i++)
            {
                ListaB = ListaB +"<tr>"
                    + "<td><strong>" + datos.get(i).Enumero + "</strong></td>"
                    + "<td><strong>" + datos.get(i).Elexema + "</strong></td>"                    
                    + "<td><strong>" + datos.get(i).Ecolumna + "</strong></td>"
                    + "<td><strong>" + datos.get(i).Etkn + "</strong></td>"
                    +"</tr>";
            }
        }
        try
        {
         FileWriter archivo = new FileWriter("C:/Users/libni/Desktop/ReporteError.html");
         PrintWriter write = new PrintWriter(archivo);
        write.println("<html>");
        write.println("<head>");
        write.println("<title> LFP PRACTICA NO. 1  TABLA DE ERRORES</title>");
        write.println("</head>");
        write.println("<body>");
        write.println("<h1> Listado de Errores</h1>");
        write.println("<table border>");
        write.println("<tr>");
        write.println("<td><strong>No</strong></td>");
        write.println("<td><strong>Caracter</strong></td>");
        write.println("<td><strong>Fila</strong></td>");
        write.println("<td><strong>Columna</strong></td>");
        write.println("<td><strong>Descripcion</strong></td>");
        write.println("</tr>");
        write.println(ListaB);
        write.println("</table>");
        write.println("</body>");
        write.println("</html>");
        archivo.close();
        EAbrir();
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
    public void EAbrir()
    {        
     try
     {
         File f = new File("C:/Users/libni/Desktop/ReporteError.html");
         Desktop.getDesktop().open(f);
     }
     catch(IOException e)
     {
         e.printStackTrace();;
     }
     catch(IllegalArgumentException e)
     {
         JOptionPane.showMessageDialog(null, "Archivo no encontrado", "Error", JOptionPane.ERROR_MESSAGE);
         e.printStackTrace();
     }
    }
}
/*
for(int i=0; i < arreglo.size(); i++)
            {                   
                Datos = Datos + "<tr>" 
                    + "<td><strong>" + arreglo.get(i).getNumero()  + "</strong></td>"
                    + "<td><strong>" + arreglo.get(i).getLexema() + "</strong></td>"
                    + "<td><strong>" + arreglo.get(i).getIdtkn() + "</strong></td>"
                    + "<td><strong>" + arreglo.get(i).getTkn() + "</strong></td>"
                    + "<td><strong>" + arreglo.get(i).getFila() + "</strong></td>"
                    + "<td><strong>" + arreglo.get(i).getColumna() + "</strong></td>"                    
                    + "</tr>" + "\n";
                System.out.println("numero: " +arreglo.get(i).getNumero()+",lexema: " +arreglo.get(i).getLexema() );
            }  
*/