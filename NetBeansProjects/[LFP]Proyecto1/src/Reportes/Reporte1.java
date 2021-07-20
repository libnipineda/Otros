/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Reportes;

import java.awt.*;
import java.io.*;
import javax.swing.JOptionPane;
/**
 *
 * @author libni
 */
public class Reporte1 {
    
    public void ReporteTkn(String datos)
    {       
        try
        {
         FileWriter archivo = new FileWriter("C:/Users/libni/Desktop/ReporteToken.html");
         PrintWriter write = new PrintWriter(archivo);       
         write.println("<html>");
         write.println("<head>");
         write.println("<title> LFP PROYECTO NO. 1  TABLA DE TOKEN´S</title>");
         write.println("</head>");
         write.println("<body>");
         write.println("<h1> Listado de Tokens</h1>");
         write.println("<table border>");
         write.println("<tr>");
         write.println("<td><strong>No</strong></td>");
         write.println("<td><strong>Lexema</strong></td>");
         write.println("<td><strong>ID_Token</strong></td>");
         write.println("<td><strong>Token</strong></td>");
         write.println("<td><strong>Fila</strong></td>");
         write.println("<td><strong>Columna</strong></td>"); 
         write.println("</tr>");
         write.println(datos);
         write.println( "</table>");
         write.println("</body>");
         write.println( "</html>");        
        archivo.close();        
        }
        catch(Exception e)
        {
            e.printStackTrace();
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
         e.printStackTrace();
     }
     catch(IllegalArgumentException e)
     {
         JOptionPane.showMessageDialog(null, "Archivo no encontrado", "Error", JOptionPane.ERROR_MESSAGE);
         e.printStackTrace();
     }
    }        
    
    public void ReporteError(String archivo){           
        try
        {
         FileWriter file = new FileWriter("C:/Users/libni/Desktop/ReporteError.html");
         PrintWriter write = new PrintWriter(file);
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
        write.println("<td><strong>Columna</strong></td>");
        write.println("<td><strong>Fila</strong></td>");
        write.println("<td><strong>Descripcion</strong></td>");
        write.println("</tr>");
        write.println(archivo);
        write.println("</table>");
        write.println("</body>");
        write.println("</html>");
        file.close();        
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
         e.printStackTrace();
     }
     catch(IllegalArgumentException e)
     {
         JOptionPane.showMessageDialog(null, "Archivo no encontrado", "Error", JOptionPane.ERROR_MESSAGE);
         e.printStackTrace();
     }
    }
    
}
