/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Ventanas;

import java.awt.Graphics;
import javax.swing.ImageIcon;
import javax.swing.JLabel;

/**
 *
 * @author libni
 */
public class imagen extends javax.swing.JLabel{
    int imgx=0,imgy=0;
            
    public imagen(JLabel Label){
      this.imgx = Label.getWidth();
      this.imgy = Label.getHeight();
      this.setSize(imgx,imgy);
  }
  
  @Override
    public void paint(Graphics g){
        ImageIcon imagenEnemigo = new ImageIcon(getClass().getResource("C:/Users/libni/OneDrive/Imágenes/logo-emi.png"));
        g.drawImage(imagenEnemigo.getImage(), 0, 0,imgx,imgy,null);
    }
}