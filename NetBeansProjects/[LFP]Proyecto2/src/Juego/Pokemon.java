package Juego;

import com.sun.istack.internal.NotNull;

/**
 *
 * @author libni
 */
public class Pokemon {
    
   private static String nombre;
   private static int hp;
   private static int ataque;
   private static int defensa;  
   private Ataque[] listaAtaque;   
     
   public Pokemon(String nombre, int hp, int ataque, int defensa,@NotNull Ataque[] listaAtaque){
       this.nombre = nombre;
       this.hp = hp;
       this.ataque = ataque;
       this.defensa = defensa;
       this.listaAtaque = listaAtaque;
   }    
        
    public static void setNombre(String nombre) {
        Pokemon.nombre = nombre;
    }

    public static void setHp(int hp) {
        Pokemon.hp = hp;
    }

    public static void setAtaque(int ataque) {
        Pokemon.ataque = ataque;
    }

    public static void setDefensa(int defensa) {
        Pokemon.defensa = defensa;
    }
   
    public void setListaAtaque(Ataque[] listaAtaque) {
        this.listaAtaque = listaAtaque;
    }
    
    public static String getNombre() {
        return nombre;
    }

    public static int getHp() {
        return hp;
    }

    public static int getAtaque() {
        return ataque;
    }

    public static int getDefensa() {
        return defensa;
    }   
   
    public Ataque[] getListaAtaque() {
        return listaAtaque;
    }
    
   public Ataque obtenerAtaque(int orden){
       return orden < this.listaAtaque.length? this.listaAtaque[orden] : this.listaAtaque[0];
   }
   
   public class Ataque{
       private String nombre;
       private int poder;

       public Ataque(String nombre, int poder){
           this.nombre = nombre;
           this.poder = poder;
       }
       
        public void setNombre(String nombre) {
            this.nombre = nombre;
        }

        public void setPoder(int poder) {
            this.poder = poder;
        }
              
        public String getNombre() {
            return nombre;
        }

        public int getPoder() {
            return poder;
        }
   }
} 