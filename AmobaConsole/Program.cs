using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmobaConsole
{
    internal class Program
    {
        private static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static char currentPlayer = 'X';
        static void Main(string[] args)
        {
            int move;
            bool isValidMove;

            while (true)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Játékos " + currentPlayer + ", választ egy mezőt (1-9):");
                isValidMove = int.TryParse(Console.ReadLine(), out move) && MoveValid(move);

                if (isValidMove)
                {
                    board[move -1 ] = currentPlayer;
                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("Játékos " + currentPlayer + " nyert!");
                        Console.ReadLine();
                        break;
                    }
                    SwithcPlayer();
                }
                else
                {
                    Console.WriteLine("Érvénytelen lépés. Próbáld újra");
                    Console.ReadLine();
                }
                if (isBoardFull())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("Döntetlen");
                    Console.ReadLine();
                    break;
                }
            }
        }
        static void PrintBoard()
        {
            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
        }

        static bool MoveValid(int move)
        {
            return move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != '0';
        }

        static void SwithcPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? '0' : 'X';
        }

        static bool CheckWin()
        {
            return (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
                   (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
                   (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
                   (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
                   (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
                   (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
                   (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
                   (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);

        }

        static bool isBoardFull()
        {
            foreach (var spot in board)
            {
                if(spot != 'X' && spot != '0'){
                    return false;
                }
            }
            return true;
        }
    }
}
