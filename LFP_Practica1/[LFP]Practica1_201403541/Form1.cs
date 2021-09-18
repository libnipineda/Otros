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

namespace _LFP_Practica1_201403541
{
    public partial class Form1 : Form
    {
        int a = 2; // Genera las pestañas        
        string direcciones = @"C:\Users\libni\OneDrive\Escritorio";

        public Form1()
        {
            InitializeComponent();
            treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage pagina = new TabPage(); // Crea la pestaña
            RichTextBox rich = new RichTextBox(); // Crea la superficie donde se ingresan los datos
            rich.Width = 452;
            rich.Height = 524;
            rich.Name = "Pestaña " + a.ToString(); //Carga el nombre del archivo en la pestaña
            rich.Location = new Point(-4, 0);
            pagina.Name = "Pestaña " + a.ToString();
            pagina.Text = "Pestaña " + a.ToString();
            pagina.Controls.Add(rich);
            this.tabControl1.TabPages.Add(pagina); // agrega la pestaña
            this.tabControl1.SelectedTab = pagina; // agrega la superficie donde se ingresan los datos
            a++; //Contador para generar pestañas

            List<Listas.Lista> ListaA = new List<Listas.Lista>();
            List<Listas.Elista> ListaB = new List<Listas.Elista>();

            ListaA.Clear();
            ListaB.Clear();
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            RichTextBox archivos = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            abrir.Filter = "Documento | *.ly";
            abrir.Title = "Abrir Documento";
            abrir.FileName = "Sin titulo";
            var dato = abrir.ShowDialog();
            if (dato == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                archivos.Text = leer.ReadToEnd();
                leer.Close();
                tabControl1.SelectedTab.Text = abrir.SafeFileName;
            }
        }

        private void guardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox archivo = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (MessageBox.Show("Desea Guardar los cambios", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Documento|*.ly";
                guardar.Title = "Guardar Archivo";
                guardar.FileName = "Sin Titulo";
                var dato = guardar.ShowDialog();
                if (dato == DialogResult.OK)
                {
                    StreamWriter escribir = new StreamWriter(guardar.FileName);
                    foreach (Object line in archivo.Lines)
                    {
                        escribir.WriteLine(line);
                    }
                    escribir.Close();
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicación", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void manualAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process aux = new System.Diagnostics.Process();
                aux.StartInfo.FileName = "E:\\Lenguajes\\Segundo_semestre\\[LFP]Practica1_201403541\\Manual de Usuario.pdf";
                aux.Start(); aux.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al encontrar manual de usuario","Información", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }                
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "LFP PRACTICA No.1\n Uzzi Libni Aarón Pineda Solórzano\n 201403541",
               "Acerca de...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];

            Pintar();
            // Datos que recibe el analizador lexico
            Scanner valor = new Scanner();
            //RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            valor.Lexico(texto.Text);
            // Metodos que imprimen reportes en HTML.
            valor.Reporte1();
            valor.Reporte2();
            //Metodo para insertar datos al treeView
            VisualizarTree(valor.Planificacion);            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Scanner valor = new Scanner();
            try
            {
                Datos(valor.Informacion);
                //label1.Text = "Prueba " + direcciones;
            }
            catch
            {
                MessageBox.Show("Encontramos un error, intente de nuevo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        public void Datos(object valor)
        {
            List<Descripcion> ideas = (List<Descripcion>)valor;

            foreach (Descripcion item in ideas)
            {
                label1.Text = item.Info;
            }
        }

        // Codigo para pintar las palbras        
        string valor; int indice;        

        public void Pintar()
        {            
            string comparar = richTextBox1.Text;
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];

            valor = "Planificador";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "Año";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);


            valor = "Mes";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "Dia";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "Descripción";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "Imagen";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);


            valor = "0";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "1";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "2";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "3";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "4";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "5";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "6";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "7";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "8";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "9";
            indice = richTextBox1.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);            
        }
       
        public void pintaReservadas(int pintar, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            indice = pintar + valor.Length - 1;
            try
            {
                texto.Select(pintar, valor.Length);
                texto.SelectionColor = Color.Blue;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pintar + valor.Length);
                pintar = comparar.IndexOf(valor) + pintar + valor.Length;

                if (pintar != indice)
                {
                    pintaReservadas(pintar, comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaReservadas");                
            }
        }

        public void pintaNumeros(int pindice, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            try
            {
                indice = pindice + valor.Length - 1;

                texto.Select(pindice, valor.Length);
                texto.SelectionColor = Color.Purple;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pindice + valor.Length);
                pindice = comparar.IndexOf(valor) + pindice + valor.Length;

                if (pindice != indice)
                {
                    pintaNumeros(pindice,comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaNumeros");                
            }
        }

        public void pintaCadena(int pindice, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            try
            {
                indice = pindice + valor.Length - 1;

                texto.Select(pindice, valor.Length);
                texto.SelectionColor = Color.Orange;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pindice + valor.Length);
                pindice = comparar.IndexOf(valor) + pindice + valor.Length;

                if (pindice != indice)
                {
                    pintaCadena(pindice, comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaCadena");
            }
        }

        // Funcionalidad del treeView     

        public void VisualizarTree(object plan)
        {
            List<Nombre> plan2 = (List <Nombre>) plan;
            TreeNode nombre = new TreeNode();
            TreeNode year = new TreeNode();
            TreeNode month = new TreeNode();
            TreeNode day = new TreeNode();

            foreach (Nombre tem in plan2)
            {
                //try
                //{
                treeView1.BeginUpdate();
                nombre.Text = tem.Nombres;
                year.Text = Convert.ToString(tem.Año);
                month.Text = Convert.ToString(tem.Mes);
                day.Text = Convert.ToString(tem.Dia);

                month.Nodes.Add(day);
                year.Nodes.Add(month);
                nombre.Nodes.Add(year);

                treeView1.Nodes.Add(nombre);
                treeView1.ExpandAll();
                treeView1.EndUpdate();
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("La lista se encuentra vacia, o encontramos un error, intente de nuevo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

        }

    }    
}