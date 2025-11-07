using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafo_formsNDNP
{
    public partial class Form1 : Form
    {
        Grafo grafo = new Grafo(false, false);
        // Diccionario para guardar la posición de cada nodo (por su letra)
        private Dictionary<char, Point> posiciones = new Dictionary<char, Point>();
        private const int radioNodo = 25;

        // Variables para arrastrar nodos
        private bool arrastrando = false;
        private char nodoSeleccionado;
        public Form1()
        {
            
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;

        }
        private void LlenarComboBox()
        {
            comboBox_V1add.Items.Clear(); // Limpiamos el ComboBox antes de agregar nuevos nodos
            comboBox_V2add.Items.Clear();
            // Agregamos los nodos al ComboBox
            foreach (var nodo in grafo.GetNodos())
            {
                comboBox_V1add.Items.Add(nodo.Data);
                comboBox_V2add.Items.Add(nodo.Data);
            }
        }
        private int ObtenerPeso(int i, int j)
        {
            // Accedemos a la matriz privada del grafo usando reflexión
            // porque la clase actual no tiene un getter público del peso
            var matrizField = typeof(Grafo).GetField("matriz", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            int[,] matriz = (int[,])matrizField.GetValue(grafo);
            return matriz[i, j];
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var nodos = grafo.GetNodos();
            int n = nodos.Count;
            // === DIBUJAR ARISTAS ===

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int peso = 0;
                    if (grafo.CheckArista(i, j))
                    {
                        Point p1 = posiciones[nodos[i].Data];
                        Point p2 = posiciones[nodos[j].Data];
                        double dx = p2.X - p1.X;
                        double dy = p2.Y - p1.Y;
                        double dist = Math.Sqrt(dx * dx + dy * dy);
                        if (dist > 0)
                        {
                            // Normalizar dirección
                            double ux = dx / dist;
                            double uy = dy / dist;

                            // Reajustar inicio y fin de la línea (evitar que entre en los círculos)
                            PointF start = new PointF(
                                (float)(p1.X + ux * radioNodo),
                                (float)(p1.Y + uy * radioNodo));
                            PointF end = new PointF(
                                (float)(p2.X - ux * radioNodo),
                                (float)(p2.Y - uy * radioNodo));

                            peso = ObtenerPeso(i, j);

                            // Linea o flecha
                            using (Pen pen = new Pen(Color.Black, 2))
                            {
                                if (grafo.IsDirigido())
                                {
                                    pen.CustomEndCap = new AdjustableArrowCap(10, 10);
                                }
                                g.DrawLine(pen, start, end);
                            }
                            // === Mostrar peso ===

                            int midX = (p1.X + p2.X) / 2;
                            int midY = (p1.Y + p2.Y) / 2;
                            //g.FillEllipse(Brushes.White, midX - 12, midY - 12, 24, 24);
                            //g.DrawEllipse(Pens.Black, midX - 12, midY - 12, 24, 24);
                            g.DrawString(peso.ToString(), this.Font, Brushes.DarkRed, midX + 10, midY + 10);

                        }
                    }

                    // === DIBUJAR NODOS ===
                    foreach (var nodo in nodos)
                    {
                        Point pos = posiciones[nodo.Data];
                        Rectangle rect = new Rectangle(pos.X - radioNodo, pos.Y - radioNodo, radioNodo * 2, radioNodo * 2);
                        g.FillEllipse(Brushes.LightBlue, rect);
                        g.DrawEllipse(Pens.Black, rect);

                        // Dibuja la letra en el centro
                        var formato = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        g.DrawString(nodo.Data.ToString(), this.Font, Brushes.Black, pos, formato);
                    }
                }
            }
        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var kvp in posiciones)
            {
                var pos = kvp.Value;
                double dist = Math.Sqrt(Math.Pow(e.X - pos.X, 2) + Math.Pow(e.Y - pos.Y, 2));
                if (dist <= radioNodo)
                {
                    arrastrando = true;
                    nodoSeleccionado = kvp.Key;
                    break;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando)
            {
                posiciones[nodoSeleccionado] = new Point(e.X, e.Y);
                pictureBox1.Invalidate(); // Redibujar en tiempo real
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_VerticeAdd.Text))
            {
                MessageBox.Show("Para crear un vertice se necesita un identificador",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            char id = textBox_VerticeAdd.Text[0];
            grafo.AddNodo(new Nodo(id));
            textBox_matriz.Text = grafo.Print();
            LlenarComboBox();
            // Asignar posición inicial aleatoria dentro del PictureBox
            Random rnd = new Random();
            int x = rnd.Next(radioNodo + 10, pictureBox1.Width - radioNodo - 10);
            int y = rnd.Next(radioNodo + 10, pictureBox1.Height - radioNodo - 10);
            posiciones[id] = new Point(x, y);

            pictureBox1.Invalidate(); // Redibuja el grafo

        }

        private void comboBox_V1del_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_V2del_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox_V1add.Text) || String.IsNullOrEmpty(comboBox_V2add.Text))
            {
                MessageBox.Show("Falta seleccionar un vertice",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            char id1 = comboBox_V1add.Text[0]; 
            char id2 = comboBox_V2add.Text[0];
            grafo.EliminarArista(id1, id2);
            textBox_matriz.Text = grafo.Print();
            pictureBox1.Invalidate();
            
        }

        private void comboBox_V2add_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_V1add_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_crearArista_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox_V1add.Text) || String.IsNullOrEmpty(comboBox_V2add.Text))
            {
                MessageBox.Show("Falta seleccionar un vertice",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            char id1 = comboBox_V1add.Text[0];
            char id2 = comboBox_V2add.Text[0];
            grafo.AddArista(id1,id2);
            textBox_matriz.Text = grafo.Print();
            pictureBox1.Invalidate();
        }

        private void textBox_VerticeAdd_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_VerticeDel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_eliminarVertice_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_VerticeDel.Text))
            {
                MessageBox.Show("Para eliminar un vertice se necesita su identificador",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            
            char id = textBox_VerticeDel.Text[0];
            int s = grafo.ObtenerIndice(id);
            if (s == -1)
            {
                MessageBox.Show($"El vertice '{ id }' no existe",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            grafo.RemoveNodo(id);
            textBox_matriz.Text = grafo.Print(); 
            LlenarComboBox();
            pictureBox1.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_BFS_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_BFS.Text))
            {
                MessageBox.Show("se necesita un vertice para iniciar la busqueda BFS",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            char id = textBox_BFS.Text[0];
            MessageBox.Show(grafo.BFS(id), "Resultado",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_DFS_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_DFS.Text))
            {
                MessageBox.Show("se necesita un vertice para iniciar la busqueda DFS",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            char id = textBox_DFS.Text[0];
            MessageBox.Show(grafo.DFS(id), "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
