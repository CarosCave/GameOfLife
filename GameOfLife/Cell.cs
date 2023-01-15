using System.Drawing;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace GameOfLife;

public enum Status
{
    dead, // Brushes.aqua
    alive // Brushes.coral
}

public class Cell
{
    private double width;
    private double height;
    public Status Status { get; set; }

    public double PosX { get; private set; }
    public double PosY { get; private set; }
    
    public int Neighbour { get; set; }

    private Rectangle _shape;
    
    // Constructor
    public Cell(double posX, double posY, Status status, Canvas cv)
    {
        this.PosX = posX;
        this.PosY = posY;
        this.Status = status;
        this.width = cv.ActualWidth / Constants.ValueRows - 2.0;
        this.height = cv.ActualHeight / Constants.ValueColumn - 2.0;

        _shape = new Rectangle();
        setBrush(status);
        _shape.Width = this.width;
        _shape.Height = this.height;

        cv.Children.Add(_shape);
        Canvas.SetTop(_shape,posY);
        Canvas.SetLeft(_shape, posX);

        _shape.MouseDown += ShapeOnMouseDown;
    }
    
    private void setBrush(Status status)
    {
        _shape.Fill = (status == Status.alive) ? Brushes.Coral : Brushes.Aqua;
    }
    

    public void ShapeOnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Status = (Status == Status.alive) ? Status.dead : Status.alive;
        setBrush(Status);
    }
}