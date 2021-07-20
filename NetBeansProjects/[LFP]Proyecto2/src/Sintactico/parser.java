package Sintactico;

import Lexico.Analizador;
import Listas.*;
import java.util.ArrayList;
import javax.swing.JOptionPane;

/**
 *
 * @author libni
 */
public class parser {
 int numpre;
 Token preanalisis;
 ArrayList<Token> lista;
 
 public void Parsear(ArrayList<Token> listaA){
     lista = listaA;
     Token aux = new Token();
     aux.numero = 0;
     aux.fila =0;
     aux.columna =0;
     aux.idtkn = 0;
     aux.tkn = "---";
     aux.lexema = "Ultimo Token";
     lista.add(aux);
     
     
     numpre =0;
     
 }
 
   public void Incio(){
    JOptionPane.showMessageDialog(null, "Inicio de la gramatica.");
    try{
        
    }
    catch(Exception e){
        
    }
   }      
   
}