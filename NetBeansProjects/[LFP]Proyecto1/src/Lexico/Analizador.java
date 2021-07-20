package Lexico;

import Funciones.Proceso;
import Listas.ELista;
import Listas.NodoTkn;
import Listas.ListaTkn;
import javax.swing.JOptionPane;

public class Analizador {
    public static ListaTkn lista = new ListaTkn();
    NodoTkn nodo = new NodoTkn();
    ELista listaE = new ELista();
    int idtkn;
    int nutknen = 0;
    int idtkns = 19; // numero de tokens definidos
    int fila = 0;
    int columna = 0;
    String token = "";
    int estado = 0;
    String concatenar ="", Etoken="";
    
   public void Scanner(String cadena){
        // variables de codigo ascii
        char tabular,espacio,salto,etiquetaA,etiquetaC,igual,barra,comillas,iniciot,enter;
        enter = (char)13;iniciot = (char)2;tabular = (char)9; espacio = (char)32; salto = (char)10; etiquetaA = (char)60; etiquetaC = (char)62; igual = (char)61; barra = (char)47; comillas = (char)34;
       
        for(int i=0; i < cadena.length();i++){
            switch(estado){
                case 0:
                    if( cadena.charAt(i) == tabular || cadena.charAt(i) == espacio || cadena.charAt(i) == salto || cadena.charAt(i) == iniciot || cadena.charAt(i) == enter) // 
                    {
                        estado =0; fila++; columna++;
                    }
                    else if(Character.isLetter(cadena.charAt(i))){
                        estado = 1; concatenar += cadena.charAt(i); columna++;
                    }
                    else if(Character.isDigit(cadena.charAt(i))){
                        estado = 2; concatenar += cadena.charAt(i); columna++;
                    }
                    else if(cadena.charAt(i) == etiquetaA || cadena.charAt(i) == etiquetaC || cadena.charAt(i) == igual || cadena.charAt(i) == barra){
                        estado = 3; columna++; concatenar += cadena.charAt(i);
                    }
                    else if(cadena.charAt(i) == comillas){
                        estado = 4; columna++; concatenar += cadena.charAt(i);
                    }
                    else
                    {                        
                        System.out.println("Error encontrado en la fila " + fila);
                        Etoken += cadena.charAt(i);
                        listaE.registrar(nutknen, Etoken, fila, columna, "Valor Desconocido.", idtkn);
                        Etoken =""; concatenar = "";
                    }
                    break;
                case 1:
                    if(Character.isLetter(cadena.charAt(i))){
                        estado = 5; columna++; concatenar += cadena.charAt(i);
                    }
                    else if(Character.isDigit(cadena.charAt(i))){
                        estado = 5; columna++; concatenar += cadena.charAt(i);
                    }
                    break;
                case 2:
                    if(Character.isDigit(cadena.charAt(i))){
                        estado = 2; columna++; concatenar += cadena.charAt(i);
                    }
                    else{
                       Patron(concatenar); i--; estado = estado-1; estado =0;
                       int a = 19;
//                       System.out.println("Estado 2");
//                       System.out.println("numero: " + nutknen+" lexema: "+concatenar+" columna: "+columna+" fila: " +fila+" Token: Numero"+" idtkn: "+a);                       
                       lista.adicionar(nutknen, concatenar, fila, columna, a, "Numero");
                       nodo.setLexema(concatenar);
                       nutknen++; concatenar="";
                    }
                    break;
                case 3:
                    Patron(concatenar); i--; estado = estado-1; estado =0;
//                    System.out.println("Estado 3");
//                    System.out.println("numero: " + nutknen+" lexema: "+concatenar+" columna: "+columna+" fila: " +fila+" Token: "+token+" idtkn: "+idtkn);
                    lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                    nodo.setLexema(concatenar);
                    nutknen++; concatenar="";
                    break;
                case 4:
                    if(cadena.charAt(i) == comillas){
                        estado = 7; columna++; concatenar += cadena.charAt(i);
                    }
                    else{
                        estado = 6; columna++; concatenar += cadena.charAt(i);
                    }
                    break;
                case 5:
                    if(Character.isLetter(cadena.charAt(i))){
                        estado = 5; columna++; concatenar += cadena.charAt(i);
                    }
                    else if(Character.isDigit(cadena.charAt(i))){
                        estado = 5; columna++; concatenar += cadena.charAt(i);
                    }
                    else{
                       Patron(concatenar); i--; estado = estado-1; estado =0;
//                       System.out.println("Estado 5");
//                       System.out.println("numero: " + nutknen+" lexema: "+concatenar+" columna: "+columna+" fila: " +fila+" Token: "+token+" idtkn: "+idtkn);
                       lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                       nodo.setLexema(concatenar);
                       nutknen++; concatenar="";
                    }
                    break;
                case 6:
                    if(cadena.charAt(i) == comillas){
                        estado = 7; columna++; concatenar += cadena.charAt(i);
                    }
                    else{
                        estado = 6; columna++; concatenar += cadena.charAt(i);
                    }
                    break;
                case 7:
                  Patron(concatenar); i--; estado = estado-1; estado =0;
//                  System.out.println("Estado 7");
//                  System.out.println("numero: " + nutknen+" lexema: "+concatenar+" columna: "+columna+" fila: " +fila+" Token: "+token+" idtkn: "+idtkn);
                  lista.adicionar(nutknen, concatenar, fila, columna, idtkn, token);
                  nodo.setLexema(concatenar);
                  nutknen++; concatenar="";
                    break;
            }
        }
        JOptionPane.showMessageDialog(null, "Analisis Completado");
    }

    public void Patron(String tkn){
        tkn.trim();
        switch(tkn){
            case "<":
                token = "Signo <."; idtkn = 1;
                break;
            case ">":
                token = "Signo >."; idtkn = 2;
                break;
            case "/":
                token = "Signo /."; idtkn = 3;
            case "=":
                token = "Signo igual."; idtkn = 4;
                break;
            case "Nivel":
                token = "Palabra Reservada."; idtkn = 5;
                break;
            case "codigo":
                token = "Identificador ."; idtkn = 6;
                break;
            case "nombre":
                token = "Palabra Reservada."; idtkn = 7;
                break;
            case "Edificio":
                token = "Palabra Reservada."; idtkn = 8;
                break;
            case "DimensionX":
                token = "Palabra Reservada."; idtkn =9;
                break;
            case "DimensionY":
                token = "Palabra Reservada."; idtkn = 10;
                break;
            case "Bloque":
                token = "Palabra Reservada."; idtkn = 11;
                break;
            case "PosicionX":
                token = "Palabra Reservada."; idtkn = 12;
                break;
            case "PosicionY":
                token = "Palabra Reservada."; idtkn = 13;
                break;
            case "Escalera":
                token = "Palabra Reservada."; idtkn = 14;
                break;
            case "Personaje":
                token = "Palabra Reservada."; idtkn = 15;
                break;
            case "imagen":
                token = "Palabra Reservada."; idtkn = 16;
                break;
            case "Enemigo":
                token = "Palabra Reservada."; idtkn = 17;
                break;
            case "Movimiento":
                token = "Palabra Reservada."; idtkn = 18;
                break;                
            default:
                token = "Cadena"; idtkns++; idtkn = idtkns;
                break;
        }            
    } 
    
    public void verError(){        
        Thread hilo = new Proceso("Proceso 1");
        Thread hilo2 = new Proceso("Proceso 2");
        
        hilo.start();
        hilo2.start();        
    }
    
}