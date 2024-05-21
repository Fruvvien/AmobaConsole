using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmobaConsole
{
    internal class Player
    {
        private static char currentPlayer = 'X';


        public Player()
        {
            
        }

        public char getCurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
        }

        public  void SwithcPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? '0' : 'X';
        }
    }
}
