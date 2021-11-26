using System;
using System.Collections.Generic;
using System.Text;

namespace _21100254_ALGEBRA_BOOLEANA_1
{
    class OPERACION_LOGICA
    {
        // Atributos
        private int _col, _row, _var, _ops, _opl;
        private int _col1 = 0, _col2 = 0;

        // Propiedades
        public int Columnas
        {
            get { return _col; }
            set { _col = value; }
        }

        public int Filas
        {
            get { return _row; }
            set { _row = value; }
        }

        public int Variables
        {
            get { return _var; }
            set { _var = value; }
        }

        public int Operaciones
        {
            get { return _ops; }
            set { _ops = value; }
        }

        public int OperacionLogica
        {
            get { return _opl; }
            set { _opl = value; }
        }

        public int ColumnaSeleccionada1
        {
            get { return _col1; }
            set { _col1 = value; }
        }

        public int ColumnaSeleccionada2
        {
            get { return _col2; }
            set { _col2 = value; }
        }

        // Metodos
        public void MostrarMatriz(int[,] _mat)
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

        public void MostrarMenu()
        {
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
        }

        public void OperarNOT(int[,] _mat)
        {
            if (_var <= _col &&
                _col1 > 0 && _col1 < _col)
            {
                for (int i = 0; i < _row; i++)
                {
                    if (!(_mat[i, _col1 - 1] == 0))
                    {
                        _mat[i, _var] = 0;
                    }
                    else if (!(_mat[i, _col1 - 1] == 1))
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

        public void OperarAND(int[,] _mat)
        {
            for (int i = 0; i < _row; i++)
            {
                if (_mat[i, _col1 - 1] == 1 &&
                    _mat[i, _col2 - 1] == 1)
                {
                    _mat[i, _var] = 1;
                }
            }
            _var++;
        }

        public void OperarOR(int[,] _mat)
        {
            for (int i = 0; i < _row; i++)
            {
                if (_mat[i, _col1 - 1] == 1 ||
                    _mat[i, _col2 - 1] == 1)
                {
                    _mat[i, _var] = 1;
                }
            }
            _var++;
        }

        public void OperarXOR(int[,] _mat)
        {
            for (int i = 0; i < _row; i++)
            {
                if (_mat[i, _col1 - 1] !=
                    _mat[i, _col2 - 1])
                {
                    _mat[i, _var] = 1;
                }
            }
            _var++;
        }

        public void OperarNAND(int[,] _mat)
        {
            for (int i = 0; i < _row; i++)
            {
                if (!(_mat[i, _col1 - 1] == 1) &&
                    !(_mat[i, _col2 - 1] == 1))
                {
                    _mat[i, _var] = 0;
                }
                else
                {
                    _mat[i, _var] = 1;
                }
            }
            _var++;
        }

        public void OperarNOR(int[,] _mat)
        {
            for (int i = 0; i < _row; i++)
            {
                if (!(_mat[i, _col1 - 1] != 0) &&
                    !(_mat[i, _col2 - 1] != 0))
                {
                    _mat[i, _var] = 1;
                }
            }
            _var++;
        }
    }
}