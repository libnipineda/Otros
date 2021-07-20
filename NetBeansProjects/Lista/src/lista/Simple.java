package lista;

/**
 *
 * @author libni
 */
public class Simple {
    Nodo inicio;
    int tamaño;
    
    public boolean adicionar(int numero, String lexema, int fila, int columna, int idtkn, String tkn){
      if(inicio == null)
      {
          inicio = new Nodo(null, numero,lexema,fila,columna,idtkn,tkn);
          tamaño++;
          return true;
      }
      else{
          Nodo temp = inicio;
          while(temp.tieneSiguiente()){
              temp = temp.getSiguiente();
          }
          temp.setSiguiente( new Nodo(null, numero,lexema,fila,columna,idtkn,tkn));
          tamaño++;
          return true;
      }
    }
    
    public void imprimir(){
        if(inicio == null)
        {
            System.out.println("No se registro ningun dato.");
        }        
        else
        {
            System.out.println("Datos insertados correctamente.");
        }
    }
}
