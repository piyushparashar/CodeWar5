using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWar5
{
    internal interface IGameController
    {
        void InitializeGame();

        void LoadConfigIfAvailable();

        void StartGame();

        void RestartGame();

        void StopGame();
    }

    internal class GameController : IGameController
    {
        public void InitializeGame()
        {
        }

        public void LoadConfigIfAvailable()
        {
        }

        public void RestartGame()
        {
        }

        public void StartGame()
        {
        }

        public void StopGame()
        {
        }
    }
}
