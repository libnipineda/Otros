package lista;

public class Lista {


    public static void main(String[] args) {
        // TODO code application logic here
        Simple lista = new Simple();
        lista.adicionar(1, "Prueba", 1, 1, 1, "Valor A");
        lista.adicionar(2, "Libni", 2, 2, 2, "Valor B");
        lista.adicionar(3, "Pineda", 3, 3, 3, "Valor C");
        lista.adicionar(4, "Solórzano", 4, 4, 4, "Valor D");
        
        lista.imprimir();
    }
    
}
