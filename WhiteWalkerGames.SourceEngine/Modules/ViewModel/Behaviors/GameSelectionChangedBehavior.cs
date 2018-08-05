using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Behaviors
{
    internal class GameSelectionChangedBehavior
    {
        internal static bool GetGameSelection(DependencyObject target)
        {
            return (bool)target.GetValue(GameSelectionChangedBehavior.GameSelectionChangedProperty);
        }


        internal static void SetGameSelection(DependencyObject target, bool value)
        {
            target.SetValue(GameSelectionChangedBehavior.GameSelectionChangedProperty, value);
        }


        internal static readonly DependencyProperty GameSelectionChangedProperty =
            DependencyProperty.RegisterAttached("GameSelectionChanged", typeof(bool), typeof(GameSelectionChangedBehavior),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(KeyPressPropertyChanged)));


        internal static void KeyPressPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var comboBox = dependencyObject as ComboBox;

            if (comboBox != null)
            {
                if ((bool)dependencyPropertyChangedEventArgs.NewValue && !(bool)dependencyPropertyChangedEventArgs.OldValue)
                {
                    comboBox.SelectionChanged += ComboBoxOnSelectionChanged;
                }
                else if (!(bool)dependencyPropertyChangedEventArgs.NewValue && (bool)dependencyPropertyChangedEventArgs.OldValue)
                {
                    comboBox.SelectionChanged -= ComboBoxOnSelectionChanged;
                }
            }
        }

        private static void ComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            IGameViewModel gameViewModel = (sender as ComboBox).DataContext as IGameViewModel;

            var selectedGame = (KeyValuePair<string, IGame>)(selectionChangedEventArgs.AddedItems[0]);

            IGameControllerContext gameControllerContext = new GameControllerContext { Game = selectedGame.Value, GameMode = gameViewModel.GameMode };

            gameViewModel.GameControllerCommand.Execute(gameControllerContext);

            gameViewModel.StartGameCommand.Execute(gameViewModel.GameMode);
        }
    }
}
