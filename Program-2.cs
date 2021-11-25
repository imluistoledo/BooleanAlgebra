using System;

namespace _21100254_ALGEBRA_BOOLEANA_1
{
    class Program
    {
        // Variables globales
        static int[,] _mat;
        static int _col, _row, _var, _ops, _opl;
        static int _con, _aux, _inc;
        static int _col1 = 0, _col2 = 0;
        static int _res = 1;

        static void Main(string[] args)
        {
            while (_res == 1)
            {
                Console.Clear();
                _con = 0; _aux = 0; _inc = 1;

                Console.SetCursorPosition(30, 5);
                Console.Write("Ingrese el total de variables: ");
                _var = int.Parse(Console.ReadLine());

                if (_var > 0)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Ingrese el total de operaciones: ");
                    _ops = int.Parse(Console.ReadLine());

                    _col = _var + _ops;
                    _row = (int)Math.Pow(2, _var);

                    _mat = new int[_row, _col];

                    for (int i = _var - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < _row; j++)
                        {
                            if (_con == _inc)
                            {
                                if (_aux == 0)
                                {
                                    _aux = 1;
                                }
                                else
                                {
                                    _aux = 0;
                                }

                                _con = 0;
                                _mat[j, i] = _aux;
                                _con++;
                            }
                            else
                            {
                                _mat[j, i] = _aux;
                                _con++;
                            }
                        }

                        _inc *= 2;
                        _aux = 0;
                        _con = 0;
                    }

                    Console.Clear();

                    // Muestra la matriz en pantalla
                    MostrarMatriz();

                    if (_ops > 0)
                    {
                        // Pide la operacion logica segun la cantidad de operaciones
                        for (int i = 0; i < _ops; i++)
                        {
                            // Da a elegir la operacion logica
                            Console.Write("\n");
                            Console.SetCursorPosition(25, 8);
                            Console.Write("1. AND\n");
                            Console.SetCursorPosition(25, 9);
                            Console.Write("2. OR\n");
                            Console.SetCursorPosition(25, 10);
                            Console.Write("3. XOR\n");
                            Console.SetCursorPosition(25, 11);
                            Console.Write("4. NAND\n");
                            Console.SetCursorPosition(25, 12);
                            Console.Write("5. NOR\n");
                            Console.SetCursorPosition(25, 13);
                            Console.Write("6. NOT\n");

                            Console.SetCursorPosition(5, 15);
                            Console.Write("Ingrese el numero de la operacion que desee: ");
                            _opl = int.Parse(Console.ReadLine());

                            // Valida que haya elegido una opcion existente
                            if (_opl > 0 && _opl < 7)
                            {
                                if (_opl == 6) // Selecciono la operacion NOT
                                {
                                    Console.SetCursorPosition(5, 17);
                                    Console.Write("Seleccione la columna que desea operar: ");
                                    _col1 = int.Parse(Console.ReadLine());

                                    OperarColumnaNOT(_col1);

                                    Console.Clear();

                                    // Muestra la matriz en pantalla
                                    MostrarMatriz();
                                }
                                else // Selecciono cualquier otra operacion logica
                                {
                                    Console.SetCursorPosition(5, 17);
                                    Console.Write("Seleccione la primera columna que desea operar: ");
                                    _col1 = int.Parse(Console.ReadLine());

                                    Console.SetCursorPosition(5, 18);
                                    Console.Write("Seleccione la segunda columna que desea operar: ");
                                    _col2 = int.Parse(Console.ReadLine());

                                    OperarColumnas(_col1, _col2, _opl);

                                    Console.Clear();

                                    // Muestra la matriz en pantalla
                                    MostrarMatriz();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.SetCursorPosition(5, 5);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Lo siento. Debes seleccionar una opcion valida. :/");
                                Console.ForegroundColor = ConsoleColor.White;

                                MostrarMatriz();
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(5, 5);
                        Console.Write("Esta es la matriz -----> ");
                        Console.SetCursorPosition(5, 6);
                        Console.Write("Pero no ha ingresado operaciones para realizar. :)");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lo siento. Debe ingresar al menos 1 variable. :/");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\n\n");
                Console.SetCursorPosition(5, 8);
                Console.Write("¿Desea repetir el programa? Si: 1. No: 0.");
                Console.SetCursorPosition(5, 14);
                _res = int.Parse(Console.ReadLine());
            }
        }

        static void MostrarMatriz()
        {
            int _fil = 4;
            for (int i = 0; i < _row; i++)
            {
                Console.SetCursorPosition(65, _fil);
                for (int j = 0; j < _var; j++)
                {
                    Console.Write("[ ");
                    if (j % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(_mat[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ]");
                }
                _fil++;
            }
        }
        static void OperarColumnaNOT(int _c1)
        {
            if (_var <= _col &&
                _c1 > 0 && _c1 < _col)
            {
                for (int i = 0; i < _row; i++)
                {
                    if (!(_mat[i, _c1-1] == 0))
                    {
                        _mat[i, _var] = 0;
                    }
                    else if (!(_mat[i, _c1-1] == 1))
                    {
                        _mat[i, _var] = 1;
                    }
                }
                _var++;
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Lo siento. Debes elegir una columna existente. :/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }

        static void OperarColumnas(int _c1, int _c2, int _op)
        {
            if (_var <= _col &&
                _c1 > 0 && _c1 < _col &&
                _c2 > 0 && _c2 < _col)
            {
                switch (_op)
                {
                    // Operacion AND
                    case 1:
                        for (int i = 0; i < _row; i++)
                        {
                            if (_mat[i, _c1 - 1] == 1 &&
                                _mat[i, _c2 - 1] == 1)
                            {
                                _mat[i, _var] = 1;
                            }
                        }
                        _var++;
                        break;
                    // Operacion OR
                    case 2:
                        for (int i = 0; i < _row; i++)
                        {
                            if (_mat[i, _c1 - 1] == 1 ||
                                _mat[i, _c2 - 1] == 1)
                            {
                                _mat[i, _var] = 1;
                            }
                        }
                        _var++;
                        break;
                    // Operacion XOR
                    case 3:
                        for (int i = 0; i < _row; i++)
                        {
                            if (_mat[i, _c1 - 1] !=
                                _mat[i, _c2 - 1])
                            {
                                _mat[i, _var] = 1;
                            }
                        }
                        _var++;
                        break;
                    // Operacion NAND
                    case 4:
                        for (int i = 0; i < _row; i++)
                        {
                            if (!(_mat[i, _c1 - 1] == 1) &&
                                !(_mat[i, _c2 - 1] == 1))
                            {
                                _mat[i, _var] = 0;
                            }
                            else
                            {
                                _mat[i, _var] = 1;
                            }
                        }
                        _var++;
                        break;
                    // Operacion NOR
                    case 5:
                        for (int i = 0; i < _row; i++)
                        {
                            if (!(_mat[i, _c1 - 1] != 0) &&
                                !(_mat[i, _c2 - 1] != 0))
                            {
                                _mat[i, _var] = 1;
                            }
                        }
                        _var++;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Lo siento. Debes elegir columnas existentes. :/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
    }
}