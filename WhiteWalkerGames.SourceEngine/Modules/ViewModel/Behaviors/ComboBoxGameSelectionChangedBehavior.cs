using System.Windows;
using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Behaviors
{
    public class ComboBoxGameSelectionChangedBehavior
    {
        public static bool GetGameSelection(DependencyObject target)
        {
            return (bool)target.GetValue(ComboBoxGameSelectionChangedBehavior.GameSelectionChangedProperty);
        }


        public static void SetGameSelection(DependencyObject target, bool value)
        {
            target.SetValue(ComboBoxGameSelectionChangedBehavior.GameSelectionChangedProperty, value);
        }


        public static readonly DependencyProperty GameSelectionChangedProperty =
            DependencyProperty.RegisterAttached("GameSelectionChanged", typeof(bool), typeof(ComboBoxGameSelectionChangedBehavior),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(KeyPressPropertyChanged)));


        public static void KeyPressPropertyChanged(DependencyObject dependencyObject,
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
        }
    }
}
