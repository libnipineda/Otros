 package Lexico;

import Listas.*;
import java.util.ArrayList;
import javax.swing.JOptionPane;

/**
 *
 * @author libni
 */
public class Analizador {
    ListaTkn lista = new ListaTkn();    
    ELista listaE = new ELista();
    ArrayList<Token> listaA = new ArrayList<Token>();
    int idtkn;
    int nutknen = 0;
    int idtkns = 22; // numero de tokens definidos
    int fila = 0;
    int columna = 0;
    String token = "";
    int estado = 0;
    String concatenar ="", Etoken="";
    
    public void Scanner(String cadena){        
        // variables de codigo ascii
       char enter,iniciot,tabular,espacio,salto;
       
       // valores de codigo ascii
       enter = (char)13;iniciot = (char)2;tabular = (char)9; espacio = (char)32; salto = (char)10;
       
       // recorrer el texto
       for(int i=0; i < cadena.length(); i++){
        switch(estado){
            case 0:
                if(cadena.charAt(i)==enter || cadena.charAt(i)==iniciot || cadena.charAt(i)==tabular || cadena.charAt(i)==espacio || cadena.charAt(i)==salto){
                    estado = 0; fila++; columna++;
                }
                else if(Character.isLetter(cadena.charAt(i)))
                {
                    estado = 1; concatenar += cadena.charAt(i); columna++;
                }
                else if(Character.isDigit(cadena.charAt(i)))
                {
                    estado = 2; concatenar += cadena.charAt(i); columna++;
                }
                else if(cadena.charAt(i)==(char)91 || cadena.charAt(i)==(char)93 || cadena.charAt(i)==(char)58 || cadena.charAt(i)==(char)123 || cadena.charAt(i)==(char)125 || cadena.charAt(i)==(char)44 || cadena.charAt(i)==(char)59 || cadena.charAt(i)==(char)40 || cadena.charAt(i)==(char)41 || cadena.charAt(i)==(char)43 || cadena.charAt(i)==(char)45 || cadena.charAt(i)==(char)42 || cadena.charAt(i)==(char)47)
                {
                    estado = 3; concatenar += cadena.charAt(i); columna++;
                }
                else if(cadena.charAt(i)==(char)34){
                    estado = 4; concatenar += cadena.charAt(i); columna++;
                }
                else if(cadena.charAt(i)==(char)45){
                    estado = 7; concatenar += cadena.charAt(i); columna++;
                }
                else{
                   Etoken += concatenar;
                   listaE.registrar(nutknen, Etoken, fila, columna, "Valor Desconocido.", idtkn);
                   Etoken = ""; concatenar = ""; 
                }
                break;
            case 1:
                if( cadena.charAt(i) == tabular || cadena.charAt(i) == espacio || cadena.charAt(i) == salto || cadena.charAt(i) == iniciot || cadena.charAt(i) == enter) // 
                    {
                        estado = 1; fila++; columna++;
                    }
                else if(Character.isLetter(cadena.charAt(i))){
                    estado = 1; columna++; concatenar += cadena.charAt(i);
                }
                else if(Character.isDigit(cadena.charAt(i))){
                    estado = 1; columna++; concatenar += cadena.charAt(i);
                }
                else if(cadena.charAt(i) == (char)95){ // simbolo de _
                    estado = 1; columna++; concatenar += cadena.charAt(i);
                }
                else
                {
                    AnalizarTkn(concatenar);  i--; estado = estado-1; estado =0;
                    lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                    Agregar(nutknen, concatenar, fila, columna, idtkn, token);
                    nutknen++; concatenar="";
                }
                break;
            case 2:
                if(Character.isDigit(cadena.charAt(i))){
                    estado = 2; concatenar += cadena.charAt(i); columna++;
                }
                else{
                     i--; estado = estado-1; estado =0;
                    int a = 1;
                    lista.adicionar(nutknen, concatenar, fila, columna, a, "Numero");
                    Agregar(nutknen, concatenar, fila, columna, idtkn, token);
                    nutknen++; concatenar= "";
                }                    
                break;
            case 3:
                AnalizarTkn(concatenar);  i--; estado = estado-1; estado =0;
                lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                Agregar(nutknen, concatenar, fila, columna, idtkn, token);
                nutknen++; concatenar= "";
                break;
            case 4:
                if(cadena.charAt(i)==(char)34){
                    estado = 6; concatenar += cadena.charAt(i); columna++;
                }
                else{
                    estado = 5; concatenar += cadena.charAt(i); columna++;
                }
                break;
            case 5:
                if(cadena.charAt(i)==(char)34){
                    estado = 6; concatenar += cadena.charAt(i); columna++;
                }
                else{
                    estado = 5; concatenar += cadena.charAt(i); columna++;
                }
                break;
            case 6:
                AnalizarTkn(concatenar);  i--; estado = estado-1; estado =0;
                lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                Agregar(nutknen, concatenar, fila, columna, idtkn, token);
                nutknen++; concatenar= "";
                break;
            case 7:
               if(cadena.charAt(i)==(char)62){
                   estado = 8; concatenar += cadena.charAt(i); columna++;
               }
                break;
            case 8:
                AnalizarTkn(concatenar);  i--; estado = estado-1; estado =0;
                lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                Agregar(nutknen, concatenar, fila, columna, idtkn, token);
                nutknen++; concatenar= "";
                break;
        }    
       }
       JOptionPane.showMessageDialog(null,"Analisis completo.");
    }
    
    public void AnalizarTkn(String tkn){
        tkn.trim();        
        switch(tkn){
        case "[":
          token = "Signo ["; idtkn = 2;
          break;
        case "]":
          token = "Signo ]"; idtkn = 3;
           break;
        case ":":
          token = "Signo :"; idtkn = 4;
            break;
        case "{":
          token = "Signo {"; idtkn = 5;
          break;
        case "}":
          token = "Signo }"; idtkn = 6;
            break;
        case ",":
          token = "Signo ,"; idtkn = 7;
           break;
        case ";":
          token = "Signo ;"; idtkn = 8;
          break;
        case "(":
          token = "Signo ("; idtkn = 9;
          break;
        case ")":
          token = "Signo )"; idtkn = 10;
            break;
        case "Principal":
          token = "Palabra reservada"; idtkn = 11;
            break;
        case "Nombre":
          token = "Palabra reservada"; idtkn = 12;
            break;
        case "Tipo":
          token = "Palabra reservada"; idtkn = 13;
            break;
        case "Vida":
          token = "Palabra reservada"; idtkn = 14;
            break;
        case "Imagen":
          token = "Palabra reservada"; idtkn = 15;
            break;
        case "Sonido":
          token = "Palabra reservada"; idtkn = 16;
            break;
        case "Ataque":
          token = "Palabra reservada"; idtkn = 17;
            break;
        case "Rivales":
          token = "Palabra reservada"; idtkn = 18;
            break;
        case "Variables":
          token = "Palabra reservada"; idtkn = 19;
            break;
        case "-":
           token = "Signo de asignación"; idtkn = 20;
            break;
        case "Variable":
           token = "Palabra reservada"; idtkn = 21;
            break;
        case "Personaje":
           token = "Palabra reservada"; idtkn = 22;
             break;
        default:
         token = "Cadena"; idtkns++; idtkn = idtkns;
          break;
        }
    }
    
    public void Agregar(int numero, String lexema, int fila, int columna, int idtkn, String tkn){        
        listaA.add(new Token(numero,lexema,fila,columna,idtkn,tkn));        
    }       
}