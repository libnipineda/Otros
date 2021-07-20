package ListasPractica;

public class NodoTkn {

    int numero;
    String lexema;
    int fila;
    int columna;
    int idtkn;
    String tkn;
    NodoTkn siguiente;

    public NodoTkn() {
        this.numero =0;
        this.lexema = "";
        this.fila = 0;
        this.columna = 0;
        this.idtkn = 0;
        this.tkn = "";
        this.siguiente = null;
    }

    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public String getLexema() {
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

    public int getIdtkn() {
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
}