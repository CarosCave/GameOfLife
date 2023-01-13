using System;
using System.Windows.Controls;

namespace GameOfLife;

public class Board
{
    public Cell[,] cells = new Cell[Constants.ValueColumn,Constants.ValueRows];

    public CellCoordinates[,] cellCoordinates = new CellCoordinates[Constants.ValueColumn,Constants.ValueRows];

    private double distanceX;
    private double distanceY;

    private State InitCell()
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        State state = (rnd.Next(0, 2) == 1) ? State.alive : State.dead;
        return state;
    }
    
    
    public Board(Canvas plotArea)
    {
        distanceX = plotArea.ActualWidth / Constants.ValueColumn;
        distanceY = plotArea.ActualHeight / Constants.ValueRows;
        
        InitBoard(plotArea);
    }

    public void InitBoard(Canvas plotArea)
    {
        for (int iRows = 0; iRows < Constants.ValueRows; iRows++)
        {
            for (int iColums = 0; iColums < Constants.ValueColumn; iColums++)
            {
                cellCoordinates[iColums, iRows].posX = distanceX * iColums;
                cellCoordinates[iColums, iRows].posY = distanceY * iRows;
                
                cells[iColums, iRows] = new Cell(cellCoordinates[iColums, iRows].posX, cellCoordinates[iColums, iRows].posY, InitCell(), plotArea);
                
            }
        }
    }

    public void SearchNeigbour()
    {
        //TODO: Count all neighbours 
        // First lines neighbour are also the last line (periodic continuation)
    }
    
}