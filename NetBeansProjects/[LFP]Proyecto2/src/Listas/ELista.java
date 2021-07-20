package Listas;

import Reportes.Reporte;
import javax.swing.JOptionPane;

/**
 *
 * @author libni
 */
public class ELista {
    NodoE star;
    int count;
    
    Reporte rp = new Reporte();
    String reporte="";
    
     public boolean registrar(int number, String elex, int ecol, int efila, String etkn, int eid){
        if(star == null){
            star = new NodoE(null,number,elex,ecol,efila,etkn,eid);
            count++;
            Errorimprimir();
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
        }
        else
        {            
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
