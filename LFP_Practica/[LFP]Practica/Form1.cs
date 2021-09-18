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

namespace _LFP_Practica
{
    public partial class Form1 : Form
    {        
        Automata valor = new Automata();
        List<Lista> datos = new List<Lista>();

        public Form1()
        {
            InitializeComponent();            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Documento|*.omg";
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
            guardar.Filter = "Documento|*.omg";
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
                guardar.Filter = "Documento|*.omg";
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
            valor.Lexico(richTextBox1.Text);
            MessageBox.Show("Espere...", "Información");
            valor.Mostrar();
            valor.Cambio();
            valor.Graficotxt();
            try
            {
                var command2 = String.Format("dot -Tpng C:\\Users\\libni\\Desktop\\Comandos.txt -o C:\\Users\\libni\\Desktop\\Comandos.png");
                var proStarInfo = new System.Diagnostics.ProcessStartInfo("cmd","/C"+command2);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = proStarInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro tipo "+ex);
            }
        }        

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LFP PRACTICA\n Uzzi Libni Aarón Pineda Solórzano\n carné:201403541 \n Sección: A-",
                "Acerca de...");
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.Process aux = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "E:\\Lenguajes\\segundo semestre 2018\\laboratorio\\Practica\\[LFP]Practica1_201403541\\Manual Técnico.pdf";
            aux.StartInfo.FileName = "E:\\Lenguajes\\segundo semestre 2018\\laboratorio\\Practica\\[LFP]Practica1_201403541\\Manual de Usuario.pdf";
            proc.Start(); proc.Close();
            aux.Start(); aux.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicación", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {            

        }        

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                for (int i = 0; i < richTextBox1.TextLength; i++)
                {
                    if (richTextBox1.Equals("organigrama"))
                    {
                        richTextBox1.ForeColor = Color.Blue;
                    }
                    else
                    {
                        richTextBox1.ForeColor = Color.Green;
                    }
                }
            }
        }
    }
}
