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
    public partial class Form1 : Form
    {

        Analisis item = new Analisis();        
        Form2 frm = new Form2();
        List<Musica> musica = new List<Musica>();

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Lista|*.plst";
            abrir.Title = "Abrir Archivo";
            abrir.FileName = "Sin Titulo";
            var dato = abrir.ShowDialog();
            if (dato == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                richTextBox1.Text = leer.ReadToEnd();
                leer.Close();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Lista|*.plst";
            guardar.Title = "Guardar Archivo";
            guardar.FileName = "Sin Titulo";
            var dato = guardar.ShowDialog();
            if (dato == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object linea in richTextBox1.Lines)
                {
                    escribir.WriteLine(linea);
                }
                escribir.Close();
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea guardar los cambios", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Lista|*.plst";
                guardar.Title = "Guardar Archivo";
                guardar.FileName = "Sin Titulo";
                var dato = guardar.ShowDialog();
                if (dato == DialogResult.OK)
                {
                    StreamWriter escribir = new StreamWriter(guardar.FileName);
                    foreach (object linea in richTextBox1.Lines)
                    {
                        escribir.WriteLine(linea);
                    }
                    escribir.Close();
                }
            }
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            item.Lexico(richTextBox1.Text);
            //frm.Show();
            frm.Cargar(item.lista_musica());
               frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Yes)
                {
                }
            item.pasa();
        }

        private void tablaDeTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            item.TablaTokens();
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            item.TablaErrores();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "LFP PROYECTO\n Uzzi Libni Aarón Pineda Solórzano\n carné:201403541 \n Sección: A-",
               "Acerca de...");

            System.Diagnostics.Process temp = new System.Diagnostics.Process();
            temp.StartInfo.FileName = "E:\\Lenguajes\\segundo semestre 2018\\laboratorio\\Proyecto1\\[LFP]Proyecto1_201403541\\Manual Técnico.pdf";
            temp.Start();
            temp.Close();

            System.Diagnostics.Process aux = new System.Diagnostics.Process();            
            aux.StartInfo.FileName = "E:\\Lenguajes\\segundo semestre 2018\\laboratorio\\Proyecto1\\[LFP]Proyecto1_201403541\\Manual Técnico.pdf";            
            aux.Start();
            aux.Close();            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicación", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
