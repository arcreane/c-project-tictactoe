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
using System.Windows.Threading;

namespace tictactoe
{
    /// <summary>
    /// Logique d'interaction pour Game2.xaml
    /// </summary>
    public partial class Game2 : Page
    {
        private List<Point> bonusPoints = new List<Point>();
        private List<Point> snakePoints = new List<Point>();
        private Brush snakeColor = Brushes.Blue;

        private enum SIZE
        {
            THIN = 4,
            NORMAL = 6,
            THICK = 8
        };

        private enum MOVINGDIRECTION
        {
            UP = 8,
            DOWN = 2,
            LEFT = 4,
            RIGHT = 6
        };

        private TimeSpan DAWNSLOW = new TimeSpan(500000);

        private Point startPoint = new Point(100, 100);
        private Point CurrentPosition = new Point();
        public Canvas paintCanvas;
        private int direction = 0;
        private int previousDirection = 0;
        private int headSize = (int)SIZE.THICK;

        private int lenght = 10;
        private int score = 0;
        private Random rand = new Random();

        

        public Game2()
        {
            InitializeComponent();
            
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Game()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);

            timer.Interval = DAWNSLOW;
            timer.Start();

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            paintSnake(startPoint);
            CurrentPosition = startPoint;

            paintBonus(0);
        }

        private void paintSnake(Point currentPosition)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = snakeColor;
            newEllipse.Width = headSize;
            newEllipse.Height = headSize;

            Canvas.SetTop(newEllipse, currentPosition.Y);
            Canvas.SetLeft(newEllipse, currentPosition.X);

            
            int count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(newEllipse);
            snakePoints.Add(currentPosition);

            if(count >lenght)
            {
                paintCanvas.Children.RemoveAt(count - lenght);
                snakePoints.RemoveAt(count - lenght);
            }
        }
        private void paintBonus(int index)
        {
            Point bonusPoint = new Point(rand.Next(5, 620), rand.Next(5, 375));

            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Red;
            newEllipse.Width = headSize;
            newEllipse.Height = headSize;

            Canvas.SetTop(newEllipse, bonusPoint.Y);
            Canvas.SetLeft(newEllipse, bonusPoint.X);
            paintCanvas.Children.Insert(index, newEllipse);
            bonusPoints.Insert(index, bonusPoint);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            switch(direction)
            {
                case (int)MOVINGDIRECTION.DOWN:
                    CurrentPosition.Y += 10;
                    paintSnake(CurrentPosition);
                    break;
                case (int)MOVINGDIRECTION.UP:
                    CurrentPosition.Y -= 10;
                    paintSnake(CurrentPosition);
                    break;
                case (int)MOVINGDIRECTION.LEFT:
                    CurrentPosition.X += 10;
                    paintSnake(CurrentPosition);
                    break;
                case (int)MOVINGDIRECTION.RIGHT:
                    CurrentPosition.X -= 10;
                    paintSnake(CurrentPosition);
                    break;
            }
            if ((CurrentPosition.X < 5) || (CurrentPosition.X > 620) ||
                (CurrentPosition.Y < 5) || (CurrentPosition.Y > 375))
                GameOver();

            int n = 0;
            foreach(Point point in bonusPoints)
            {
                if((Math.Abs(point.X - CurrentPosition.X)<headSize)&&
                    (Math.Abs(point.Y -CurrentPosition.Y)<headSize))
                {
                    lenght += 10;
                    score += 10;

                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);
                    paintBonus(n);
                    break;
                }
                n++;
            }
            for (int q = 0; q<(snakePoints.Count -1); q++)
            {
                Point point = new Point(snakePoints[q].X, snakePoints[q].Y);
                if((Math.Abs(point.X - CurrentPosition.X)<(headSize))&&
                    (Math.Abs(point.Y - CurrentPosition.Y)<(headSize)))
                {
                    GameOver();
                    break;
                }
            }
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Down:
                    if (previousDirection != (int)MOVINGDIRECTION.UP)
                        direction = (int)MOVINGDIRECTION.DOWN;
                    break;
                case Key.Up:
                    if (previousDirection != (int)MOVINGDIRECTION.DOWN)
                        direction = (int)MOVINGDIRECTION.UP;
                    break;
                case Key.Left:
                    if (previousDirection != (int)MOVINGDIRECTION.RIGHT)
                        direction = (int)MOVINGDIRECTION.LEFT;
                    break;
                case Key.Right:
                    if (previousDirection != (int)MOVINGDIRECTION.LEFT)
                        direction = (int)MOVINGDIRECTION.RIGHT;
                    break;    
            }
            previousDirection = direction;
        }

        private void GameOver()
        {
            MessageBox.Show("Vous avez perdu ! Votre score est de : " + score.ToString());
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
       

        
        private void MenuItem_ClickS(object sender, RoutedEventArgs e)
        {
            
            //foreach (Button btn in Canvas.Children)
            //{
            //    btn.Content = "";
            //    btn.IsEnabled = true;
            //}
        }
    }
}
