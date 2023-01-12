using System.Drawing;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace GameOfLife;

public enum State
{
    dead, // Brushes.aqua
    alive // Brushes.coral
}

public class Cell
{
    private double width;
    private double height;
    public State state { get; set; }

    public double posX { get; private set; }
    public double posY { get; private set; }

    private Rectangle shape;
    
    
    // Constructor
    public Cell(double posX, double posY, State state, Canvas cv)
    {
        this.posX = posX;
        this.posY = posY;
        this.state = state;
        this.width = cv.ActualWidth / Constants.ValueRows - 2.0;
        this.height = cv.ActualHeight / Constants.ValueColumn - 2.0;

        shape = new Rectangle();
        //shape.Fill = Brushes.Aqua;
        setBrush(state);
        shape.Width = this.width;
        shape.Height = this.height;

        cv.Children.Add(shape);
        Canvas.SetTop(shape,posY);
        Canvas.SetLeft(shape, posX);

        shape.MouseDown += ShapeOnMouseDown;
        
    }

    private void setBrush(State state)
    {
        shape.Fill = (state == State.alive) ? Brushes.Coral : Brushes.Aqua;
    }
    

    public void ShapeOnMouseDown(object sender, MouseButtonEventArgs e)
    {
        state = (state == State.alive) ? State.dead : State.alive;
        setBrush(state);
    }

    

}