/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Listas;

import Reportes.Reporte1;
import java.awt.*;
import java.io.*;
import javax.swing.JOptionPane;

/**
 *
 * @author libni
 */
public class ELista {
    NodoE star;
    int count;
    
    Reporte1 rp = new Reporte1();
    String reporte;
    
    public boolean registrar(int number, String elex, int ecol, int efila, String etkn, int eid){
        if(star == null){
            star = new NodoE(null,number,elex,ecol,efila,etkn,eid);
            count++;
            return true;
        }
        else{
            NodoE aux = star;
            while(aux.Errorsiguiente()){
                aux = aux.getSig();
            }
            aux.setSig(new NodoE(null,number,elex,ecol,efila,etkn,eid));
            count++;
            Errorimprimir();
            return true;
        }
    }
    
    public void Errorimprimir(){
        if(star == null)
        {
            System.out.println("No hay errores");
            JOptionPane.showMessageDialog(null,"No hay errores.");            
        }
        else
        {
            System.out.println("Hay errores");
            JOptionPane.showMessageDialog(null,"Hay errores.");
            NodoE temp = star;
            while(temp.Errorsiguiente()){
                temp = temp.getSig();
            }
            reporte = reporte + "<tr>"
                    +"<td><strong>" + temp.getEnum() + "</td></strong>"
                    +"<td><strong>" + temp.getElex() + "</td></strong>"
                    +"<td><strong>" + temp.getEcol() + "</td></strong>"
                    +"<td><strong>" + temp.getEfila() + "</td></strong>"
                    +"<td><strong>" + temp.getEtoken() + "</td></strong>"
                    +"</tr>";
            rp.ReporteError(reporte);
        }
    }           
}