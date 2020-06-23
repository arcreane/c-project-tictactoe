using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tictactoe
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>

    partial class MainWindow
    {

        private void TetrisClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Game1();
        }

        private void TictactoeClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Game2();
        }

        public void MenuClickG1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Game1();
        }
        private void MenuClickG2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Game1();
        }
    }
}
