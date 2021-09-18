using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto1
{
    public partial class Form2 : Form
    {
        Analisis analisis = new Analisis();
        List<Musica> cancion = new List<Musica>();
        string[] amp3;
        string[] rutasmp3;
        string raiz = "C:\\Users\\libni\\OneDrive\\Escritorio";
        
        public Form2()
        {
            InitializeComponent();            
        }

        public void Cargar(List<Musica> valores)
        {
            cancion = valores;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in cancion)
            {
                ListViewItem agregar = new ListViewItem(item.nombreC);
                agregar.SubItems.Add(item.artista);
                agregar.SubItems.Add(item.album);
                agregar.SubItems.Add(item.año);
                agregar.SubItems.Add(item.duracion);
                agregar.SubItems.Add(item.url);
                listView1.Items.Add(agregar);
            }                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clic en si elimina la canción que seleccione \nClic en no borra toda la lista","Información");
            if (MessageBox.Show("Desea eliminar un elemento", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ListViewItem agregar in listView1.SelectedItems)
                {
                    agregar.Remove();
                }
            }
            else
            {
                listView1.Items.Clear();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reproductor.URL = rutasmp3[listView1.SelectedIndices[0]];
        }

        private TreeNode Arbol(DirectoryInfo InfoDirectorio)
        {
            TreeNode arbolnodo = new TreeNode(InfoDirectorio.Name); // recibe la raiz

            foreach (var item in InfoDirectorio.GetDirectories()) // recorre todas las carpetas que existen
            {
                arbolnodo.Nodes.Add(Arbol(item)); // se llama asi mismo para encontrar carpetas o subcarpetas con sus archivos
            }

            foreach (var item in InfoDirectorio.GetFiles())
            { // recorre todos los archivos
                arbolnodo.Nodes.Add(new TreeNode(item.Name));
            }

            return arbolnodo;
        }

        private void Form2_Load(object sender, EventArgs e)
        {            
            treeView1.Nodes.Clear(); // limpia la vista de los directorios cada vez que inicia la info del directorio.
            DirectoryInfo InfoDirectorio = new DirectoryInfo(raiz); //Paso la ruta que inicia la info del directorio.
            treeView1.Nodes.Add(Arbol(InfoDirectorio));

            //agregar las columnas del listview1
            listView1.View = View.Details;
            listView1.Columns.Add("Nombre", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Artista", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Album", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Año", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Duracion", 65, HorizontalAlignment.Left);
            listView1.Columns.Add("Url", 80, HorizontalAlignment.Left);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciones los archivos \n Una muestra de archivos");
            if (MessageBox.Show("Desea eliminar un elemento", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenFileDialog CajaDeBusquedaDeArchivos = new OpenFileDialog();
                CajaDeBusquedaDeArchivos.Multiselect = true;
                if (CajaDeBusquedaDeArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    amp3 = CajaDeBusquedaDeArchivos.SafeFileNames; // se guardan todos los archivos
                    rutasmp3 = CajaDeBusquedaDeArchivos.FileNames; // se guardan todas las rutas
                    foreach (var ArchivosMP3 in amp3)
                    {
                        listView1.Items.Add(ArchivosMP3); // lstCanciones nombre del listbox
                    }
                    Reproductor.URL = rutasmp3[0]; // Reproductor es el nombre de la libreria de windows media                
                                                   //listView1.SelectedIndex = 0;        
                }
            }
            else
            {
                ListViewItem agregar = new ListViewItem("1");
                agregar.SubItems.Add("2");
                agregar.SubItems.Add("3");
                agregar.SubItems.Add("4");
                agregar.SubItems.Add("5");
                agregar.SubItems.Add("6");
                listView1.Items.Add(agregar);
            }
        }
    }
}
