using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board;
        private DispatcherTimer _timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            
            PlotArea.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            PlotArea.Arrange(new Rect(0.0, 0.0, PlotArea.DesiredSize.Width, PlotArea.DesiredSize.Height));
            
            _board = new Board(PlotArea);
            _board.InitBoard(PlotArea);

            //_timer.Interval = TimeSpan.FromSeconds(0.1);
           // _timer.Tick += TimeTick;
           // _timer.Start();

        }
       
        private void BtnStartStop_OnClick(object sender, RoutedEventArgs e)
        {
            _board.SearchNeighbours();
            _board.GiveBirthOrDeath();
        }

        private void TimeTick(object sender, EventArgs e)
        {
            _board.SearchNeighbours();
            _board.GiveBirthOrDeath();
        }
        
    }
}