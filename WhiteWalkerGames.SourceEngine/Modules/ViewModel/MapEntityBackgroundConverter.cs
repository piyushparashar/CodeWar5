using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel
{
    internal class MapEntityBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isActive = (bool)value;

            if (isActive)
            {
                return Brushes.DarkGreen;
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
