using System;

namespace PrimerArbol
{
    class Ezquizofrenia
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

		public class ArbolBinario
		{

			private Nodo root;
			internal int cant;
			internal int altura;

			public ArbolBinario()
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
			//Metodos de las hojas
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
			//Metodos de el nivel
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
			ArbolBinario ggmen = new ArbolBinario();
			int ob;
			int a = 52, b = 14, c = 69, d = 35, e = 41, f = 4;
			Console.WriteLine(" Insertando valores manualmente en el árbol: ");
            ggmen.Agregar(a);
			ggmen.Agregar(b);
			ggmen.Agregar(c);
			ggmen.Agregar(d);
			ggmen.Agregar(e);
			ggmen.Agregar(f);
			
			Console.WriteLine(" " + "/" + "f");
			Console.WriteLine("e" + " " + " " + "/" + "d");
			Console.WriteLine(" " + "|" + "a" + " " + "--" + "c");
			Console.WriteLine(" " + " " + " " + "|" + "b");

			Console.WriteLine("Valores insertados: " + a + " " + b + " " + c + " " + d + " " + e + " " + f + " ");
			ggmen.PrintAlturaDeCadaNod();
			do
			{
				Console.WriteLine("/////////////////////////// ");
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
