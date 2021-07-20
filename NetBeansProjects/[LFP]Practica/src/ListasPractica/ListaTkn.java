/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ListasPractica;


/**
 *
 * @author libni
 */
public class ListaTkn {
        public int numero = 0;
        public String lexema = "";
        public int fila = 0;
        public int columna = 0;
        public int idtkn = 0;
        public String tkn = "";        
        
    @Override
    public String toString() {
        //return "ListaTkn {" + "numero= " + numero + ",lexema= " + lexema + ",fila= " + fila + ",columna= " + columna + ",idtkn= " + idtkn + ",tkn= " + tkn + "}";
        return "<tr>"+ "<td><strong>" + numero  + "</strong></td>"+ "<td><strong>" + lexema + "</strong></td>"+ "<td><strong>" + idtkn + "</strong></td>"
                + "<td><strong>" + tkn + "</strong></td>"+ "</tr>";
    }

    public String EscribirSimbolos(){
        return "<tr>"+ "<td><strong>" + numero  + "</strong></td>"+ "<td><strong>" + lexema + "</strong></td>"+ "<td><strong>" + idtkn + "</strong></td>"
                + "<td><strong>" + tkn + "</strong></td>"+ "</tr>";
    }
    
    public ListaTkn()
    {
        
    }
    
    public ListaTkn(int numero, String lexema, int fila, int columna, int idtkn, String tkn) {
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

    public String getLexema() {
        return lexema;
    }

    public int getFila() {
        return fila;
    }

    public int getColumna() {
        return columna;
    }

    public int getIdtkn() {
        return idtkn;
    }

    public String getTkn() {
        return tkn;
    }            
    
}