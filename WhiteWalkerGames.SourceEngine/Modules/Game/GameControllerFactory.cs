using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal class GameControllerFactory
    {
        static IGameController mySinglePlayerGameController;
        private static IGameViewModel myGameViewModel;

        internal static IGameController CreateGameController(GameMode gameMode)
        {
            if (gameMode == GameMode.SinglePlayer)
            {
                if(mySinglePlayerGameController == null)
                {
                    mySinglePlayerGameController = new SinglePlayerGameController(myGameViewModel);
                }
                return mySinglePlayerGameController;
            }
            else if (gameMode == GameMode.Multiplayer)
            {

            }
            else if(gameMode == GameMode.MultiplayerRemote)
            {

            }
            return mySinglePlayerGameController;
        }

        internal static void SetViewModel(IGameViewModel gameViewModel)
        {
            myGameViewModel = gameViewModel;
        }
    }
}
