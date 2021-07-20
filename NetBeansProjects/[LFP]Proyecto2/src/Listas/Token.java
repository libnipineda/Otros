package Listas;

/**
 *
 * @author libni
 */
public class Token {
   public int numero;
   public String lexema;
   public int fila;
   public int columna;
   public int idtkn;
   public String tkn;

    public Token(){}  
    public Token(int numero, String lexema, int fila, int columna, int idtkn, String tkn) {
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
                
    public String toString(){
        return "[lexema: "+ this.getLexema()+"]";
    }
}
