package Listas;

/**
 *
 * @author libni
 */
public class NodoTkn {
   public int numero;
   public static String lexema;
   public int fila;
   public int columna;
   public static int idtkn;
   public String tkn;
   NodoTkn siguiente;
   
   public NodoTkn(){
        this.siguiente = siguiente;
        this.numero = numero;
        this.lexema = lexema;
        this.fila = fila;
        this.columna = columna;
        this.idtkn = idtkn;
        this.tkn = tkn;
   }
   
    public NodoTkn(NodoTkn siguiente,int numero, String lexema, int fila, int columna, int idtkn, String tkn) {
        this.siguiente = siguiente;
        this.numero = numero;
        this.lexema = lexema;
        this.fila = fila;
        this.columna = columna;
        this.idtkn = idtkn;
        this.tkn = tkn;        
    }
           
    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public static String getLexema() {
        return lexema;
    }

    public void setLexema(String lexema) {
        this.lexema = lexema;
    }

    public int getFila() {
        return fila;
    }

    public void setFila(int fila) {
        this.fila = fila;
    }

    public int getColumna() {
        return columna;
    }

    public void setColumna(int columna) {
        this.columna = columna;
    }

    public static int getIdtkn() {
        return idtkn;
    }

    public void setIdtkn(int idtkn) {
        this.idtkn = idtkn;
    }

    public String getTkn() {
        return tkn;
    }

    public void setTkn(String tkn) {
        this.tkn = tkn;
    }

    public NodoTkn getSiguiente() {
        return siguiente;
    }

    public void setSiguiente(NodoTkn siguiente) {
        this.siguiente = siguiente;
    }   
    
    public boolean tieneSiguiente(){
     return siguiente!=null;       
    }
    
    public String toString(){
        return "[lexema: "+ this.getLexema()+"]";
    }
}
