using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_formsNDNP
{
    internal class Grafo
    {
        private List<Nodo> nodos;
        private int[,] matriz;
        private bool dirigido;
        private bool ponderado;
        public Grafo(bool dirigido, bool ponderado)
        {
            nodos = new List<Nodo>();
            matriz = new int[0, 0];
            this.dirigido = dirigido;
            this.ponderado = ponderado;
        }

        public void AddNodo(Nodo nodo)
        {
            bool existe = nodos.Any(n => n.Data == nodo.Data);

            if (existe)
            {
                Console.WriteLine($"Error: ya existe un vértice con el identificador '{nodo.Data}'.");
                return;
            }
            nodos.Add(nodo);
            int nuevoTam = nodos.Count;
            int[,] nuevaMatriz = new int[nuevoTam, nuevoTam];

            // Copiar los valores anteriores
            for (int i = 0; i < nuevoTam - 1; i++)
            {
                for (int j = 0; j < nuevoTam - 1; j++)
                {
                    nuevaMatriz[i, j] = matriz[i, j];
                }
            }

            matriz = nuevaMatriz; // Reemplaza la matriz anterior
        }

        public void AddArista(int src, int dst, int w = 1)
        {
            if (!ponderado) w = 1;
            matriz[src, dst] = w;
            if (!dirigido)
            {
                matriz[dst, src] = w;
            }
        }
        public void AddArista(char src, char dst, int w = 1)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                //Console.WriteLine($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            if (matriz[i, j] != 0)
            {
                //Console.WriteLine("Error: Ya hay un arista asignada");
                return;
            }
            if (!ponderado) w = 1;
            matriz[i, j] = w;
            if (!dirigido)
                matriz[j, i] = w;
            Console.WriteLine("Arista añadida");
        }

        public bool CheckArista(int src, int dst)
        {
            return matriz[src, dst] != 0;
        }

        public string Print()
        {
            //Console.Write("  ");
            string matrizString;
            matrizString = "   ";
            foreach (var node in nodos)
            {
                //  Console.Write(node.Data + " ");
                matrizString += node.Data + " ";
            }
            //Console.WriteLine();
            matrizString += "\r\n";

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                //Console.Write(nodos[i].Data + " ");
                matrizString += nodos[i].Data + " ";
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    //    Console.Write(matriz[i, j] + " ");
                    matrizString += matriz[i, j] + " ";
                }
                //Console.WriteLine();
                matrizString += "\r\n";
            }
            return matrizString;
        }
        public string BFS(char start)
        {
            string cadena="";
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                //Console.WriteLine($"Error: el vértice '{s}' no existe.");
                return $"El vértice '{s}' no existe.";
            }
            bool[] visitado = new bool[nodos.Count];
            Queue<int> cola = new Queue<int>();

            visitado[s] = true;
            cola.Enqueue(s);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                //Console.Write(nodos[actual].Data + " ");
                cadena = cadena + nodos[actual].Data + " ";
                for (int i = 0; i < nodos.Count; i++)
                {
                    if (matriz[actual, i] != 0 && !visitado[i])
                    {
                        visitado[i] = true;
                        cola.Enqueue(i);
                    }
                }
            }
            return cadena;
        }

        public string DFS(char start)
        {
            string cadena="";
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                //Console.WriteLine($"Error: el vértice '{s}' no existe.");
                return cadena;
            }
            bool[] visitado = new bool[nodos.Count];
            cadena = cadena + DFSRecursivo(s, visitado,cadena);
            return cadena;
        }

        private string DFSRecursivo(int v, bool[] visitado, string cadena)
        {
            
            visitado[v] = true;
            //Console.Write(nodos[v].Data + " ");
            cadena = cadena + nodos[v].Data + " ";
            for (int i = 0; i < nodos.Count; i++)
            {
                if (matriz[v, i] != 0 && !visitado[i])
                {
                   cadena = DFSRecursivo(i, visitado,cadena);
                }
            }
            return cadena;
        }
        public void EliminarArista(int src, int dst)
        {
            matriz[src, dst] = 0;
            if (!dirigido) matriz[dst, src] = 0;
        }
        public void EliminarArista(char src, char dst)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                //Console.WriteLine($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            matriz[i, j] = 0;
            if (!dirigido) matriz[j, i] = 0;
            //Console.WriteLine("Arista eliminada");
        }
        public void RemoveNodo(char src)
        {
            int s = ObtenerIndice(src);
            if (s == -1)
            {
                //Console.WriteLine("Índice inválido");
                return;
            }

            // Eliminar el nodo de la lista
            nodos.RemoveAt(s);

            int size = matriz.GetLength(0);
            int[,] nuevaMatriz = new int[size - 1, size - 1];

            // Copiar todas las filas y columnas excepto la que se elimina
            int filaNueva = 0;
            for (int i = 0; i < size; i++)
            {
                if (i == s) continue; // saltar la fila eliminada
                int colNueva = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == s) continue; // saltar la columna eliminada
                    nuevaMatriz[filaNueva, colNueva] = matriz[i, j];
                    colNueva++;
                }
                filaNueva++;
            }

            // Reemplazar la matriz antigua
            matriz = nuevaMatriz;
        }
        internal int ObtenerIndice(char id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Data == id) return i;
            }
            return -1;
        }
        public List<Nodo> GetNodos()
        {
            return nodos;
        }
        public bool IsDirigido()
        {
            return dirigido;
        }
        public bool IsPonderado()
        {
            return ponderado;
        }
    }
}
