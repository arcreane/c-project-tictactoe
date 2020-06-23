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
    /// Logique d'interaction pour Game1.xaml
    /// </summary>
    public partial class Game1 : Page
    {
        
            
        
            int turn;
            int i, j;
            public Game1()
            {
                InitializeComponent();
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                turn = 1;
            }

            private void Win(string btnContent)
            {
                if ((A1.Content == btnContent & A2.Content == btnContent & A3.Content == btnContent)
                    | (A1.Content == btnContent & B1.Content == btnContent & C1.Content == btnContent)
                    | (A1.Content == btnContent & B2.Content == btnContent & C3.Content == btnContent)
                    | (A2.Content == btnContent & B2.Content == btnContent & C2.Content == btnContent)
                    | (A3.Content == btnContent & B3.Content == btnContent & C3.Content == btnContent)
                    | (B1.Content == btnContent & B2.Content == btnContent & B3.Content == btnContent)
                    | (C1.Content == btnContent & C2.Content == btnContent & C3.Content == btnContent)
                    | (A3.Content == btnContent & B2.Content == btnContent & C1.Content == btnContent))
                {
                    if (btnContent == "O")
                    {
                        MessageBox.Show("PLAYER O WINS");
                        label3.Content = ++i;


                    }
                    else if (btnContent == "X")
                    {

                        MessageBox.Show("PLAYER X WINS");
                        label2.Content = ++j;

                    }
                    disablebuttons();
                }
                else
                {
                    foreach (Button btn in wrapPanel1.Children)
                    {
                        if (btn.IsEnabled == true)
                            return;
                    }
                    MessageBox.Show("GAME OVER NO ONE WINS");
                }
            }

            private void disablebuttons()
            {
                foreach (Button btn in wrapPanel1.Children)
                {
                    btn.IsEnabled = false;
                }
            }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turn == 1)
            {
                btn.Foreground = new SolidColorBrush(Colors.Red);
                btn.Content = "O";

                label6.Content = "X";
            }
            else
            {
                btn.Foreground = new SolidColorBrush(Colors.Blue);
                btn.Content = "X";
                label6.Content = "O";
            }
            btn.IsEnabled = false;
            Win(btn.Content.ToString());
            turn += 1;
            if (turn > 2)
                turn = 1;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
            {
                foreach (Button btn in wrapPanel1.Children)
                {
                    btn.Content = "";
                    btn.IsEnabled = true;
                }
            }

            private void Reset_Click_1(object sender, RoutedEventArgs e)
            {

            }


        }
    }

       

