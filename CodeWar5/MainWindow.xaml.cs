using System.Windows;
using CodeWar5.GameEngine;
using CodeWar5.GameEngine.Drivers;

namespace CodeWar5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisplayContext
    {
        private DummyGame myGame;

        public MainWindow()
        {
            InitializeComponent();

            IDisplayDriver displayDriver = new DisplayDriver(this, myCanvas);
            IInputDriver inputDriver = new InputDriver(this);
            myGame = new DummyGame(displayDriver, inputDriver);
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            myGame.Start();
        }
    }
}
