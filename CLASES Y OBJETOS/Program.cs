using System;

namespace _21100254_ALGEBRA_BOOLEANA_1
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] _mat;
            int _con, _aux, _inc;
            int _res = 1;
            while (_res == 1)
            {
                OPERACION_LOGICA miOpLog = new OPERACION_LOGICA();

                Console.Clear();
                _con = 0; _aux = 0; _inc = 1;

                Console.SetCursorPosition(30, 5);
                Console.Write("Ingrese el total de variables: ");
                miOpLog.Variables = int.Parse(Console.ReadLine());

                if (miOpLog.Variables > 0)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Ingrese el total de operaciones: ");
                    miOpLog.Operaciones = int.Parse(Console.ReadLine());

                    miOpLog.Columnas = miOpLog.Variables + miOpLog.Operaciones;
                    miOpLog.Filas = (int)Math.Pow(2, miOpLog.Variables);

                    _mat = new int[miOpLog.Filas, miOpLog.Columnas];

                    for (int i = miOpLog.Variables - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < miOpLog.Filas; j++)
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
                    miOpLog.MostrarMatriz(_mat);

                    if (miOpLog.Operaciones > 0)
                    {
                        // Pide la operacion logica segun la cantidad de operaciones
                        for (int i = 0; i < miOpLog.Operaciones; i++)
                        {
                            // Da a elegir la operacion logica
                            miOpLog.MostrarMenu();

                            Console.SetCursorPosition(5, 15);
                            Console.Write("Ingrese el numero de la operacion que desee: ");
                            miOpLog.OperacionLogica = int.Parse(Console.ReadLine());

                            // Valida que haya elegido una opcion existente
                            if (miOpLog.Operaciones > 0 && miOpLog.Operaciones < 7)
                            {
                                if (miOpLog.OperacionLogica == 6) // Selecciono la operacion NOT
                                {
                                    Console.SetCursorPosition(5, 17);
                                    Console.Write("Seleccione la columna que desea operar: ");
                                    miOpLog.ColumnaSeleccionada1 = int.Parse(Console.ReadLine());

                                    miOpLog.OperarNOT(_mat);

                                    Console.Clear();

                                    // Muestra la matriz en pantalla
                                    miOpLog.MostrarMatriz(_mat);
                                }
                                else // Selecciono cualquier otra operacion logica
                                {
                                    Console.SetCursorPosition(5, 17);
                                    Console.Write("Seleccione la primera columna que desea operar: ");
                                    miOpLog.ColumnaSeleccionada1 = int.Parse(Console.ReadLine());

                                    Console.SetCursorPosition(5, 18);
                                    Console.Write("Seleccione la segunda columna que desea operar: ");
                                    miOpLog.ColumnaSeleccionada2 = int.Parse(Console.ReadLine());

                                    if (miOpLog.Variables <= miOpLog.Columnas &&
                                        miOpLog.ColumnaSeleccionada1 > 0 &&
                                        miOpLog.ColumnaSeleccionada1 < miOpLog.Columnas &&
                                        miOpLog.ColumnaSeleccionada2 > 0 &&
                                        miOpLog.ColumnaSeleccionada2 < miOpLog.Columnas)
                                    {
                                        switch (miOpLog.OperacionLogica)
                                        {
                                            // Operacion AND

                                            case 1:
                                                miOpLog.OperarAND(_mat);
                                                break;
                                            // Operacion OR
                                            case 2:
                                                miOpLog.OperarOR(_mat);
                                                break;
                                            // Operacion XOR
                                            case 3:
                                                miOpLog.OperarXOR(_mat);
                                                break;
                                            // Operacion NAND
                                            case 4:
                                                miOpLog.OperarNAND(_mat);
                                                break;
                                            // Operacion NOR
                                            case 5:
                                                miOpLog.OperarNOR(_mat);
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

                                    Console.Clear();

                                    // Muestra la matriz en pantalla
                                    miOpLog.MostrarMatriz(_mat);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.SetCursorPosition(5, 5);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Lo siento. Debes seleccionar una opcion valida. :/");
                                Console.ForegroundColor = ConsoleColor.White;

                                miOpLog.MostrarMatriz(_mat);
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
    }
}