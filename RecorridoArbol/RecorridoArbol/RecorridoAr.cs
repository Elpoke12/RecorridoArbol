using System;
using System.Collections.Generic;

namespace RecorridoArbol
{
	class Tree
	{
		public class Nodo
		{
			private int dato;
			private Nodo left, right;

			public Nodo(int dato, Nodo izq, Nodo der)
			{
				this.dato = dato;
				this.left = izq;
				this.right = der;
			}

			public virtual int Dato
			{
				get
				{
					return dato;
				}
				set
				{
					this.dato = value;
				}
			}

			//Ramas izquierdas
            public virtual Nodo Izquierda
			{
				get
				{
					return left;
				}
				set
				{
					this.left = value;
				}
			}

			//Ramas derechas
            public virtual Nodo Derecha
			{
				get
				{
					return right;
				}
				set
				{
					this.right = value;
				}
			}


		}

		public class ArbolBinary
		{

			private Nodo root;
			internal int cant;
			internal int altura;

			public ArbolBinary()
			{
				this.root = null;
			}
			//Metodos que agregan los datos
			public virtual void Agregar(int dato)
			{
				Nodo nuevo = new Nodo(dato, null, null);
				Insert(nuevo, root);
			}

			public virtual void Insert(Nodo nuevo, Nodo pivote)
			{
				if (this.root == null)
				{
					root = nuevo;
				}
				else
				{
					if (nuevo.Dato <= pivote.Dato)
					{
						if (pivote.Izquierda == null)
						{
							pivote.Izquierda = nuevo;
						}
						else
						{
							Insert(nuevo, pivote.Izquierda);
						}
					}
					else
					{
						if (pivote.Derecha == null)
						{
							pivote.Derecha = nuevo;
						}
						else
						{
							Insert(nuevo, pivote.Derecha);
						}
					}
				}

			}
			//Nodos
			public virtual bool Exist(int info)
			{
				Nodo recoil = root;
				while (recoil != null)
				{
					if (info == recoil.Dato)
					{
						return true;
					}
					else if (info > recoil.Dato)
					{
						recoil = recoil.Derecha;
					}
					else
					{
						recoil = recoil.Izquierda;
					}
				}
				return false;
			}

			public virtual int Cantidad()
			{
				cant = 0;
				Cantidad(root);
				return cant;
			}
			//Metodos de hojas
			private void Cantidad(Nodo recoil)
			{
				if (recoil != null)
				{
					cant++;
					Cantidad(recoil.Izquierda);
					Cantidad(recoil.Derecha);
				}
			}

			private void CantidadNodosLeaf(Nodo recoil)
			{
				if (recoil != null)
				{
					if (recoil.Izquierda == null && recoil.Derecha == null)
					{
						cant++;
					}
					CantidadNodosLeaf(recoil.Izquierda);
					CantidadNodosLeaf(recoil.Derecha);
				}
			}

			public virtual int CantidadNodosLeaf()
			{
				cant = 0;
				CantidadNodosLeaf(root);
				return cant;
			}
			//Metodos de como obtener la altura
			public virtual int ReturnAltura()
			{
				altura = 0;
				ReturnAltura(root, 1);
				return altura;
			}
			private void ReturnAltura(Nodo recoil, int level)
			{
				if (recoil != null)
				{
					ReturnAltura(recoil.Izquierda, level + 1);
					if (level > altura)
					{
						altura = level;
					}
					ReturnAltura(recoil.Derecha, level + 1);
				}
			}
			//altura arbol
			internal string[] levels;

			public virtual int AlturaArbol()
			{
				altura = 0;
				AlturaArbol(root, 0);
				return altura;
			}
			private void AlturaArbol(Nodo pivote, int level)
			{
				if (pivote != null)
				{
					AlturaArbol(pivote.Izquierda, level + 1);
					if (level > altura)
					{
						altura = level;
					}
					AlturaArbol(pivote.Derecha, level + 1);
				}
			}
			//Metodos del nivel
			public virtual void PrintLevel()
			{
				levels = new string[altura + 1];

				PrintLevel(root, 0);
				for (int i = 0; i < levels.Length; i++)
				{
					Console.WriteLine(levels[i] + " En nivel: " + i);
				}
			}
			public virtual void PrintLevel(Nodo pivote, int lvl)
			{
				if (pivote != null)
				{
					levels[lvl] = pivote.Dato + ", " + ((!string.ReferenceEquals(levels[lvl], null)) ? levels[lvl] : "");
					PrintLevel(pivote.Derecha, lvl + 1);
					PrintLevel(pivote.Izquierda, lvl + 1);
				}
			}
			public virtual void PrintAlturaDeCadaNod()
			{
				PrintAlturaDeCadaNod(root, 1);
			}
			private void PrintAlturaDeCadaNod(Nodo reco, int nivel)
			{
				if (reco != null)
				{
					Console.WriteLine("Nodo contiene: " + reco.Dato + " y su altura es: " + nivel);
					PrintAlturaDeCadaNod(reco.Izquierda, nivel + 1);
					PrintAlturaDeCadaNod(reco.Derecha, nivel + 1);
				}
			}
		}

		static void Main(string[] args)
		{
			ArbolBinary ggmen = new ArbolBinary();
			int ob;
			int a = 4, b = 70, c = 7, d = 61, e = 55, f = 53, g = 56, h = 58, i = 64, j = 69, k = 52;
			Console.WriteLine(" Insertando valores manualmente en el árbol: ");
			ggmen.Agregar(a);
            ggmen.Agregar(b);
			ggmen.Agregar(c);
			ggmen.Agregar(d);
			ggmen.Agregar(e);
			ggmen.Agregar(f);
			ggmen.Agregar(g);
			ggmen.Agregar(h);
			ggmen.Agregar(i);
			ggmen.Agregar(j);
			ggmen.Agregar(k);

			Console.WriteLine(" " + " " + " " + " " + " " + " " + "/" + "j");
			Console.WriteLine("/" + "b" + " " + " " + "/" + "i" + " " + " " + "/" + "h");
			Console.WriteLine("|--" + "d" + " " + " " + " " + "/" + "g");
			Console.WriteLine("k" + " " + " " + "|_" + "e");
			Console.WriteLine("|_" + "c" + " " + " " + " " + "|_" + "f");
			Console.WriteLine("|_" + "a");

			Console.WriteLine("Valores insertados: " + a + " " + b + " " + c + " " + d + " " + e + " " + f + " ");
			ggmen.PrintAlturaDeCadaNod();
			do
			{
				Console.WriteLine("/////////////////////// ");
				Console.WriteLine("1.-Cantidad de nodos del arbol.");
				Console.WriteLine("2.-Altura del arbol.");
				Console.WriteLine("0.-Salir");
				ob = int.Parse(Console.ReadLine());
				switch (ob)
				{
					case 1:
						Console.WriteLine("Cantidad de nodos del árbol:" + ggmen.Cantidad());
						break;
					case 2:
						Console.WriteLine("La altura del arbol es:" + ggmen.ReturnAltura());
						break;
				}
			} while (ob != 0);
		}
	}
}
