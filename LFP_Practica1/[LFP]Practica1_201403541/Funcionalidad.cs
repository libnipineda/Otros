using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Practica1_201403541
{
    class Funcionalidad
    {
        public string nombre, informacion, link;
        public int año, mes, dia;

        Boolean inom = false, sinom = false, iaño = false, sinaño = false, imes = false, sinmes = false, idias = false, sindias = false,
            sindes = false, ides= false, sinurl = false, iurl = false;

        public List<Nombre> Planificacion = new List<Nombre>();
        public List<Descripcion> Informacion = new List<Descripcion>();
        
        public List<Nombre> ObtenerDatos(List<Listas.Lista> listas)
        {
            try
            {
                foreach (var item in listas)
                {
                    // obtener nombre de la planificación
                    if (item.lexema.Equals("Planificador"))
                    {
                        sinom = true;
                    }
                    if (sinom)
                    {
                        if (item.lexema.Equals(":"))
                        {
                            inom = true;
                            sinom = false;
                        }
                    }
                    if (inom)
                    {
                        if (item.tkn.Equals("Cadena"))
                        {
                            nombre = item.lexema;
                            inom = false;
                        }
                    }
                    
                    //Obtener año
                    if (item.lexema.Equals("Año"))
                    {
                        sinaño = true;
                    }
                    if (sinaño)
                    {
                        if (item.lexema.Equals(":"))
                        {
                            sinaño = false;
                            iaño = true;
                        }
                    }
                    if (iaño)
                    {
                        if (item.tkn.Equals("Numero."))
                        {
                            año = Convert.ToInt16(item.lexema);
                            iaño = false;
                        }
                    }
                    
                    //Obtener mes
                    if (item.lexema.Equals("Mes"))
                    {
                        sinmes = true;
                    }
                    if (sinmes)
                    {
                        if (item.lexema.Equals(":"))
                        {
                            imes = true;
                            sinmes = false;
                        }
                    }
                    if (imes)
                    {
                        if (item.tkn.Equals("Numero."))
                        {
                            mes = Convert.ToInt16(item.lexema);
                            imes = false;
                        }
                    }
                    
                    //Obtener dia
                    if (item.lexema.Equals("Dia"))
                    {
                        sindias = true;
                    }
                    if (sindias)
                    {
                        if (item.lexema.Equals(":"))
                        {
                            sindias = false;
                            idias = true;
                        }
                    }
                    if (idias)
                    {
                        if (item.tkn.Equals("Numero."))
                        {
                            dia = Convert.ToInt16(item.lexema);
                            sindias = false;
                        }
                    }
                    
                    //Obtener descripcion
                    if (item.lexema.Equals("Descripción"))
                    {
                        sindes = true;
                    }
                    if (sindes)
                    {
                        if (item.lexema.Equals(":"))
                        {
                            sindes = false;
                            ides = true;
                        }
                    }
                    if (ides)
                    {
                        if (item.tkn.Equals("Cadena"))
                        {
                            informacion = item.lexema;
                            ides = false;
                        }
                    }

                    //Obtener URL
                    if (item.lexema.Equals("Imagen"))
                    {
                        sinurl = true;
                    }
                    if (sinurl)
                    {
                        if (item.lexema.Equals(":"))
                        {
                            sinurl = false;
                            iurl = true;
                        }
                    }
                    if (iurl)
                    {
                        if (item.tkn.Equals("Cadena"))
                        {
                            link = item.lexema;
                            iurl = false;
                            //AgregarDatos();
                        }                        
                    }                    
                }                
                AgregarDatos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error lexico, no se puede agregar al TreeView.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Planificacion;
         }

        public List<Descripcion> VerDatos(List<Listas.Lista> listas)
        {
            foreach (var item in listas)
            {
                //Obtener descripcion
                if (item.lexema.Equals("Descripción"))
                {
                    sindes = true;
                }
                if (sindes)
                {
                    if (item.lexema.Equals(":"))
                    {
                        sindes = false;
                        ides = true;
                    }
                }
                if (ides)
                {
                    if (item.tkn.Equals("Cadena"))
                    {
                        informacion = item.lexema;
                        ides = false;
                    }
                }
            }            
            return Informacion;
        }

        public void AgregarDatos()
        {

            Nombre Obtener = new Nombre(nombre, año, mes, dia);
            Planificacion.Add(Obtener);

            Descripcion Listar = new Descripcion(informacion, link);
            Obtener.ListaDocumentos1.Add(Listar);

            Console.WriteLine("Datos lista planificacion: " + nombre + " " + año + " " + mes + " " + dia);
            Console.WriteLine("Datos lista descripcion: " + informacion + " " + link);            
        }

    }
}