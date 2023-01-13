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

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            PlotArea.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            PlotArea.Arrange(new Rect(0.0, 0.0, PlotArea.DesiredSize.Width, PlotArea.DesiredSize.Height));
            
            Board board = new Board(PlotArea);
            board.InitBoard(PlotArea);
            
        }

       
        private void BtnStartStop_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}