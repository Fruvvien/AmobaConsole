using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmobaConsole
{
    internal class Game
    {   
       static Player player;
       static Board board;

        public Game() 
        {
            player = new Player();
            board = new Board();
        
        }
         

        public void Gameplay()
        {
            int move;
            bool isValidMove;

            while (true)
            {
                Console.Clear();
                board.PrintBoard();
                Console.WriteLine("Játékos " + player.getCurrentPlayer + ", választ egy mezőt (1-9):");
                isValidMove = int.TryParse(Console.ReadLine(), out move) && MoveValid(move);

                if (isValidMove)
                {
                   board.getBoard[move - 1] = player.getCurrentPlayer;
                    if (CheckWin())
                    {
                        Console.Clear();
                        board.PrintBoard();
                        Console.WriteLine("Játékos " + player.getCurrentPlayer + " nyert!");
                        Console.ReadLine();
                        break;
                    }
                    player.SwithcPlayer();
                }
                else
                {
                    Console.WriteLine("Érvénytelen lépés. Próbáld újra");
                    Console.ReadLine();
                }
                if (isBoardFull())
                {
                    Console.Clear();
                    board.PrintBoard();
                    Console.WriteLine("Döntetlen");
                    Console.ReadLine();
                    break;
                }
            }

        }
        static bool CheckWin()
        {
            return (board.getBoard[0] == player.getCurrentPlayer && board.getBoard[1] == player.getCurrentPlayer && board.getBoard[2] == player.getCurrentPlayer) ||
                   (board.getBoard[3] == player.getCurrentPlayer && board.getBoard[4] == player.getCurrentPlayer && board.getBoard[5] == player.getCurrentPlayer) ||
                   (board.getBoard[6] == player.getCurrentPlayer && board.getBoard[7] == player.getCurrentPlayer && board.getBoard[8] == player.getCurrentPlayer) ||
                   (board.getBoard[0] == player.getCurrentPlayer && board.getBoard[3] == player.getCurrentPlayer && board.getBoard[6] == player.getCurrentPlayer) ||
                   (board.getBoard[1] == player.getCurrentPlayer && board.getBoard[4] == player.getCurrentPlayer && board.getBoard[7] == player.getCurrentPlayer) ||
                   (board.getBoard[2] == player.getCurrentPlayer && board.getBoard[5] == player.getCurrentPlayer && board.getBoard[8] == player.getCurrentPlayer) ||
                   (board.getBoard[0] == player.getCurrentPlayer && board.getBoard[4] == player.getCurrentPlayer && board.getBoard[8] == player.getCurrentPlayer) ||
                   (board.getBoard[2] == player.getCurrentPlayer && board.getBoard[4] == player.getCurrentPlayer && board.getBoard[6] == player.getCurrentPlayer);

        }
        static bool MoveValid(int move)
        {
            return move >= 1 && move <= 9 && board.getBoard[move - 1] != 'X' && board.getBoard[move - 1] != '0';
        }
        static bool isBoardFull()
        {
            foreach (var spot in board.getBoard)
            {
                if (spot != 'X' && spot != '0')
                {
                    return false;
                }
            }
            return true;
        }



    }
}
