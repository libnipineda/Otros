package Juego;

import Juego.Pokemon.Ataque;
import java.util.*;

/**
 *
 * @author libni
 */
public class Batalla {
    enum Pokemones{ //BULBASAUR,CHARMANDER,SQUIRTLE,PIKACHU}
        
        BULBASAUR(1),CHARMANDER(2),SQUIRTLE(3),PIKACHU(4);
        
        private Pokemones(int id){
            this.id = id;
        }
        
        public int getId(){
            return id;
        }
        
        private int id;
    }                        
    
   public void Empezar(){
       System.out.println("Elige un pokémon");
       Pokemones[] var = Pokemones.values();
       
       for(int i=0; i < var.length; i++){
           Pokemones p = var[i];
           System.out.println(i+"1"+")"+p);
       }
       
       Scanner scanner = new Scanner(System.in);
       int opcion = scanner.nextInt();
       
       Pokemon pokemon = generarPokemon(opcion);
       
       System.out.println(pokemon.getNombre());
       
       mostrarDatos(pokemon);
       
       Random random = new Random();
       int numeroAlazar = 1 + random.nextInt(4);
       Pokemon pokemonSalvaje = generarPokemon(numeroAlazar);
       
       System.out.println("Un "+ pokemonSalvaje.getNombre() + " salvaje ha aparecido! \n");
       
       do{
           String var1 = pokemon.getNombre() + "HP: " + pokemon.getHp() + " | " + pokemonSalvaje.getNombre() + "HP: " + pokemonSalvaje.getHp();
           System.out.println(var1);
           
           var1 = "Elige un ataque:";
           Ataque[] var2 = pokemon.getListaAtaque();
           int aux = var2.length;
           
           int ataqueSeleccionado;
           for(ataqueSeleccionado =0; ataqueSeleccionado < aux; ataqueSeleccionado++){
               Ataque a = var2[ataqueSeleccionado];
               System.out.println(ataqueSeleccionado+": "+ a.getNombre());
           }
           
           ataqueSeleccionado = scanner.nextInt();
           if(procesarAtaque(pokemon, pokemonSalvaje, ataqueSeleccionado)){
               break;
           }
           
           int ataqueAleatorio = 1 + random.nextInt(pokemonSalvaje.getListaAtaque().length);
           if(procesarAtaque(pokemonSalvaje, pokemon, ataqueAleatorio)){
               break;
           }
           
           System.out.println("los dos pokémones siguen en pie!");
           System.out.println(".. continuamos");
       }while(pokemon.getHp() > 0 && pokemonSalvaje.getHp() > 0);
   }
   
   public  boolean procesarAtaque(Pokemon pokemonAtacante, Pokemon pokemonDefensor, int ataqueSeleccionado){
       Ataque ataque = pokemonAtacante.obtenerAtaque(ataqueSeleccionado);
       System.out.println(pokemonAtacante.getNombre()+" ha usado "+ataque.getNombre());
       
       int valorDaño = calcularDanio(pokemonAtacante.getAtaque(), pokemonDefensor.getDefensa(), ataque);
       System.out.println(pokemonDefensor.getNombre()+" ha recibido "+ valorDaño + " puntos de daño!");
       pokemonDefensor.setHp(pokemonDefensor.getHp() - valorDaño);
       
       if(pokemonDefensor.getHp() <= 0){
           System.out.println(pokemonDefensor.getNombre()+" se agoto!");
           System.out.println(pokemonAtacante.getNombre()+" ganó la batalla!");
           return true;
       } else{
           return false;
       }
   }
   
   public int calcularDanio(int valorAtaque, int valorDefensa, Ataque ataque){
       return (int)((0.048D * (double)(valorAtaque / valorDefensa) * (double)ataque.getPoder() + (double)2) * 1.5D);
   }
   
   public void mostrarDatos(Pokemon pokemon){      
      String var1 = "Has elegido a " + pokemon.getNombre() + " \nHP:" + pokemon.getHp() + "\nAtaque:" + pokemon.getAtaque() + "\nDefensa:" + pokemon.getDefensa() + '\n';
      System.out.println(var1);
   }
   
   public static final Pokemon generarPokemon(int opcion){
       Pokemon pk;       
       Ataque at;              
       switch(opcion){
           case 1:
              
               break;
           case 2:
              
               break;
           case 3:
               
               break;
           case 4:
               
               break;
           default:
               
               break;
       }       
     return null;
   }   
}