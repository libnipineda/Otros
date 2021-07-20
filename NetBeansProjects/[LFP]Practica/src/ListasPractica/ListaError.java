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
public class ListaError {
    
        public int Enumero = 0;
        public String Elexema = "";
        public int Ecolumna = 0;
        public String Etkn = "";
        public int Eidtkn = 0;              

    @Override
    public String toString() {
        return "ListaError{" + "Enumero= " + Enumero + ", Elexema= " + Elexema + ", Ecolumna= " + Ecolumna + ", Etkn= " + Etkn + ", Eidtkn= " + Eidtkn + "}";
    }
    
    public ListaError(int Enumero, String Elexema, int Ecolumna, String Etkn, int Eidtkn) {
            this.Enumero = Enumero;
            this.Elexema = Elexema;
            this.Ecolumna = Ecolumna;
            this.Etkn = Etkn;
            this.Eidtkn = Eidtkn;
        }               
        
    public int getEnumero() {
        return Enumero;
    }

    public String getElexema() {
        return Elexema;
    }

    public int getEcolumna() {
        return Ecolumna;
    }

    public String getEtkn() {
        return Etkn;
    }

    public int getEidtkn() {
        return Eidtkn;
    }       
   
}