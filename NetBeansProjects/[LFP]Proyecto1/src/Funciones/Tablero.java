package Funciones;

import Listas.ListaTkn;
import Listas.NodoTkn;
import Ventanas.Formulario;
import java.awt.Graphics;
import java.awt.Image;
import java.io.*;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import Lexico.Analizador.*;

/**
 *
 * @author libni
 */
public class Tablero {
  int Dimx=0, Dimy=0,Posx = 0, Posy = 0, x = 0, y = 0, a = 0, b = 0;
  String imagen1, imagen2;
      
  NodoTkn valor = new NodoTkn();  Formulario form = new Formulario();
  
  public void FunEdificio(){
      boolean num = false,num2 = false,numx = false, numy = false;
      //------------------------------------------- Coordenada X ----------------------------------------------------------
      if(valor.getLexema().equals("DimensionX")){
          num = true;          
      }
      if(num){
          if(valor.getLexema().equals("=")){
              numx=true;
              num=false;
          }
      }
      if(numx){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  Dimx = Integer.parseInt(valor.getLexema());
                  numx = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
       } // fin coordenada x
      //------------------------------------------- Y ----------------------------------------------------------
      if(valor.getLexema().equals("DimensionX")){
          num2 = true;
      }
      if(num2){
          if(valor.getLexema().equals("=")){
              numy = true;
              num = false;
          }
      }
      if(numy){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  Dimy = Integer.parseInt(valor.getLexema());
                  numy = false;
              }
          }
          catch(Exception e){
              DimensionEdificio();
          }
      }
      System.out.println("el valor del eje x es: "+Dimx+" el valor del eje y es: "+Dimy);
      }  
  
  public void DimensionEdificio(){
      if(Dimx > 0 && Dimx <= 15 || Dimy >0 && Dimy <= 15){
          form.Edificio(Dimx, Dimy);
      }
      else
      {
          JOptionPane.showMessageDialog(null,"Los intervalos no permiten crear el edificio, intente cambiar las dimensiones.");
      }
  }
  
  public void FunBloque(){
      boolean num = false,numx = false, num2 = false, numy = false;
      //------------------------------------------- Coordenada X ----------------------------------------------------------
      if(valor.getLexema().equals("Bloque") && valor.getLexema().equals("PosicionX")){
          num = true;
      }
      if(num){
          if(valor.getLexema().equals("=")){
              numx=true;
              num=false;
          }
      }
      if(numx){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  Posx = Integer.parseInt(valor.getLexema());
                  numx = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
       } 
      //------------------------------------------- Coordenada Y ----------------------------------------------------------
      if(valor.getLexema().equals("PosicionY")){
          num2 = true;
      }
      if(num2){
          if(valor.getLexema().equals("=")){
              numy=true;
              num=false;
          }
      }
      if(numy){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  Posy = Integer.parseInt(valor.getLexema());
                  numy = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
      }
  }
  
  public void DimensionBloque(){
      if(Posx >= 0 || Posy >= 0){
       form.Bloque(Posx, Posy);
      }
      else
      {
          JOptionPane.showMessageDialog(null,"Los intervalos no permiten crear el bloque, intente cambiar las dimensiones.");
      }
  }
  
  public void FunEscalera(){
      boolean num = false,numx = false, num2 = false, numy = false;
      //------------------------------------------- Coordenada X ----------------------------------------------------------
      if(valor.getLexema().equals("Escalera") && valor.getLexema().equals("PosicionX")){
          num = true;
      }
      if(num){
          if(valor.getLexema().equals("=")){
              numx=true;
              num=false;
          }
      }
      if(numx){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  x = Integer.parseInt(valor.getLexema());
                  numx = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
       } 
      //------------------------------------------- Coordenada Y ----------------------------------------------------------
      if(valor.getLexema().equals("PosicionY")){
          num2 = true;
      }
      if(num2){
          if(valor.getLexema().equals("=")){
              numy=true;
              num=false;
          }
      }
      if(numy){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  y = Integer.parseInt(valor.getLexema());
                  numy = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
      }
  }
  
  public void DimensionEscalera(){
      if(x >= 0 || y >= 0){
          form.Escalera(x, y);
      }
      else
      {
          JOptionPane.showMessageDialog(null,"Los intervalos no permiten crear la escalera, intente cambiar las dimensiones.");
      }
  }  
  
  public void ObtenerImagenEnemigo(){
      boolean img = false, obtener = false;
      
      if(valor.getLexema().equals("Personaje")){
          img = true;
      }
      if(img){
          if(valor.getLexema().equals("imagen")){
              img = false;
              obtener = true;              
          }
      }
      if(obtener){
          try
          {
           if(valor.getTkn().equals("Cadena")){
               imagen1 = valor.getLexema();
               
            }   
          }
          catch(Exception e){
              JOptionPane.showMessageDialog(null, "No se encontro la ruta de la imagen, para el personaje");
          }
      }
  }
  
  public void ObtenerImagenPersonaje(){
       boolean img = false, obtener = false;
      
      if(valor.getLexema().equals("Enemigo")){
          img = true;
      }
      if(img){
          if(valor.getLexema().equals("imagen")){
              img = false;
              obtener = true;
          }
      }
      if(obtener){
          try
          {
           if(valor.getTkn().equals("Cadena")){
               imagen1 = valor.getLexema();
           }   
          }
          catch(Exception e){
              JOptionPane.showMessageDialog(null, "No se encontro la ruta de la imagen para el enemigo");
          }
      }
  }
  
  public void FunMovimientos(){
      boolean num = false,numx = false, num2 = false, numy = false;
       //------------------------------------------- Coordenada X ----------------------------------------------------------
      if(valor.getLexema().equals("Movimiento") && valor.getLexema().equals("PosicionX")){
          num = true;
      }
      if(num){
          if(valor.getLexema().equals("=")){
              numx=true;
              num=false;
          }
      }
      if(numx){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  a = Integer.parseInt(valor.getLexema());
                  numx = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
       } 
      //------------------------------------------- Coordenada Y ----------------------------------------------------------
      if(valor.getLexema().equals("PosicionY")){
          num2 = true;
      }
      if(num2){
          if(valor.getLexema().equals("=")){
              numy=true;
              num=false;
          }
      }
      if(numy){
          try
          {
              if(valor.getTkn().equals("Numero")){
                  b = Integer.parseInt(valor.getLexema());
                  numy = false;
              }
          }
          catch(Exception e)
          {
              DimensionEdificio();
          }
      }
  }  

  public void DimensionMovimiento(){
      if(a >= 0 || b >=0 ){
          form.Movimiento(a, b);
      }
      else
      {
          JOptionPane.showMessageDialog(null,"Los intervalos no permiten realizar los movimientos.");
      }
  }  
}