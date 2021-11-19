using System;

namespace _21100254_Algebra_booleana
{
    class Program
    {
        static int[,] int_Matriz_Comb;
        static int[] int_Matriz_Res;
        static int int_Columnas;
        static int int_Filas;
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cantidad de variables que desea operar: ");
            int_Columnas = int.Parse(Console.ReadLine()); // Ej.: 4
            if (int_Columnas > 0 && int_Columnas < 6)
            {
                int_Filas = (int)Math.Pow(2, int_Columnas); // Ej.: 16

                int_Matriz_Comb = new int[int_Filas, int_Columnas];

                // Llena la matriz con ceros
                for (int i = 0; i < int_Filas; i++)
                {
                    for (int j = 0; j < int_Columnas; j++)
                    {
                        int_Matriz_Comb[i, j] = 0;
                    }
                }

                // Pone los unos en su lugar
                for (int i = 1; i <= int_Filas; i++)
                {
                    // Matriz de 1 x 1
                    if (i % 2 == 0)
                    {
                        int_Matriz_Comb[i - 1, int_Columnas - 1] = 1;
                    }
                    // Matriz de 2 x 2
                    if (i % 4 == 0)
                    {
                        int_Matriz_Comb[i - 1, int_Columnas - 2] = 1;
                        int_Matriz_Comb[i - 2, int_Columnas - 2] = 1;
                    }
                    // Matriz de 3 x 3
                    if (i % 8 == 0)
                    {
                        int_Matriz_Comb[i - 1, int_Columnas - 3] = 1;
                        int_Matriz_Comb[i - 2, int_Columnas - 3] = 1;
                        int_Matriz_Comb[i - 3, int_Columnas - 3] = 1;
                        int_Matriz_Comb[i - 4, int_Columnas - 3] = 1;
                    }
                    // Matriz de 4 x 4
                    if (i % 16 == 0)
                    {
                        int_Matriz_Comb[i - 1, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 2, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 3, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 4, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 5, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 6, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 7, int_Columnas - 4] = 1;
                        int_Matriz_Comb[i - 8, int_Columnas - 4] = 1;
                    }
                    // Matriz de 5 x 5
                    if (i % 32 == 0)
                    {
                        int_Matriz_Comb[i - 1, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 2, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 3, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 4, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 5, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 6, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 7, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 8, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 9, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 10, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 11, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 12, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 13, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 14, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 15, int_Columnas - 5] = 1;
                        int_Matriz_Comb[i - 16, int_Columnas - 5] = 1;
                    }
                }

                // Muestra los indices de las columnas
                Console.Write("\n");
                char letra = 'A';
                while (letra <= 'E')
                {
                    Console.Write("[ " + letra + " ]");
                    letra++;
                    // Oculta el indice si no aplica
                    if (int_Columnas == 4 && letra == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (int_Columnas == 3 && letra == 'D')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (int_Columnas == 2 && letra == 'C')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (int_Columnas == 1 && letra == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                // Regresa el color para continuar
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                
                // Imprime la matriz en pantalla
                for (int i = 0; i < int_Filas; i++)
                {
                    for (int j = 0; j < int_Columnas; j++)
                    {
                        Console.Write("[ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(int_Matriz_Comb[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ]");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("\n");
                Console.WriteLine("Seleccione e ingrese el numero de las columnas que desea: ");
                Console.Write("Primera opcion: ");
                int int_ColSel1 = int.Parse(Console.ReadLine());
                Console.Write("Segunda opcion: ");
                int int_ColSel2 = int.Parse(Console.ReadLine());

                // Valida que exista la columna que seleccione
                if (int_ColSel1 > 0 && int_ColSel1 <= int_Columnas &&
                    int_ColSel2 > 0 && int_ColSel2 <= int_Columnas)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Seleccione e ingrese el numero de la operacion que desea: ");
                    Console.WriteLine("1. AND\n" +
                                      "2. OR\n" +
                                      "3. XOR\n" +
                                      "4. NAND\n" +
                                      "5. NOR\n");
                    int int_OpLogica = int.Parse(Console.ReadLine());

                    // Define el vector que guarda el resultado de la operacion logica
                    int_Matriz_Res = new int[int_Filas];

                    // Lo llena de ceros
                    for (int i = 0; i < int_Matriz_Res.Length; i++)
                    {
                        int_Matriz_Res[i] = 0;
                    }

                    // Llama el metodo para llenar el vector
                    CompararColumnas(int_ColSel1, int_ColSel2, int_OpLogica);

                    // Muestra el resultado en pantalla
                    for (int i = 0; i < int_Matriz_Res.Length; i++)
                    {
                        Console.Write("[ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(int_Matriz_Res[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ]\n");
                    }
                }
                else
                {
                    // Alguna de las columnas no existe
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lo siento. Debe seleccionar columnas existentes.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lo siento. Debe ingresar un numero entre 1 y 5.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadKey();
        }

        static void CompararColumnas(int col1, int col2, int op)
        {
            switch (op)
            {
                // Operacion AND
                case 1:
                    for (int i = 0; i < int_Filas; i++)
                    {
                        if (int_Matriz_Comb[i, col1-1] == 1 &&
                            int_Matriz_Comb[i, col2-1] == 1)
                        {
                            int_Matriz_Res[i] = 1;
                        }
                    }
                    break;
                // Operacion OR
                case 2:
                    for (int i = 0; i < int_Filas; i++)
                    {
                        if (int_Matriz_Comb[i, col1 - 1] == 1 ||
                            int_Matriz_Comb[i, col2 - 1] == 1)
                        {
                            int_Matriz_Res[i] = 1;
                        }
                    }
                    break;
                // Operacion XOR
                case 3:
                    for (int i = 0; i < int_Filas; i++)
                    {
                        if (int_Matriz_Comb[i, col1 - 1] !=
                            int_Matriz_Comb[i, col2 - 1])
                        {
                            int_Matriz_Res[i] = 1;
                        }
                    }
                    break;
                // Operacion NAND
                case 4:
                    for (int i = 0; i < int_Filas; i++)
                    {
                        if (!(int_Matriz_Comb[i, col1 - 1] == 1) &&
                            !(int_Matriz_Comb[i, col2 - 1] == 1))
                        {
                            int_Matriz_Res[i] = 0;
                        }
                        else
                        {
                            int_Matriz_Res[i] = 1;
                        }
                    }
                    break;
                // Operacion NOR
                case 5:
                    for (int i = 0; i < int_Filas; i++)
                    {
                        if (!(int_Matriz_Comb[i, col1 - 1] != 0) &&
                            !(int_Matriz_Comb[i, col2 - 1] != 0))
                        {
                            int_Matriz_Res[i] = 1;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
