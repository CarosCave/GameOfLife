using System;
using System.Windows.Controls;

namespace GameOfLife;

public class Board
{
    public Cell[,] cells = new Cell[Constants.ValueColumn,Constants.ValueRows];

    public CellCoordinates[,] cellCoordinates = new CellCoordinates[Constants.ValueColumn,Constants.ValueRows];

    private double distanceX;
    private double distanceY;

    private Status InitCell()
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        //Status status = (rnd.Next(0, 2) == 1) ? Status.alive : Status.dead;
        //return status;
        return Status.dead;
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

    public void SearchNeighbours()
    {
        // First lines neighbour are also the last line (periodic continuation)

        for (int iRows = 0; iRows < Constants.ValueRows; iRows++)
        {
            for (int iColums = 0; iColums < Constants.ValueColumn; iColums++)
            {
                // Check if Cell is in first or last Row. 
                int iTop = iRows - 1;
                if (iTop < 0) iTop = Constants.ValueRows - 1;
                int iBottom = iRows + 1;
                if (iBottom >= Constants.ValueRows) iBottom = 0;
                
                // Check if Cell in first or last Column
                int iLeft = iColums - 1;
                if (iLeft < 0) iLeft = Constants.ValueColumn - 1;
                int iRight = iColums + 1;
                if (iRight >= Constants.ValueColumn) iRight = 0;
                    
                // TOP LEFT
                if (cells[iTop, iLeft].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }

                // TOP CENTER
                if (cells[iTop, iColums].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }
                
                // TOP RIGHT
                if (cells[iTop, iRight].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }
                
                // CENTER LEFT
                if (cells[iRows, iLeft].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }

                // CENTER RIGHT
                if (cells[iRows, iRight].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }

                // BOTTOM LEFT
                if (cells[iBottom, iLeft].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }

                // BOTTOM CENTER
                if (cells[iBottom, iColums].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }

                // BOTTOM RIGHT
                if (cells[iBottom, iRight].Status == Status.alive) { cells[iRows, iColums].Neighbour++; }

            }
        }

    }

    public void ThreeNeighbours()
    {
        cells.ne
    }

    public void GiveBirthOrDeath()
    {
        for (int iRows = 0; iRows < Constants.ValueRows; iRows++)
        {
            for (int iColums = 0; iColums < Constants.ValueColumn; iColums++)
            {
                if (cells[iColums, iRows].Neighbour < 2 || cells[iColums, iRows].Neighbour > 3)
                {
                    cells[iColums, iRows].Status = Status.dead;
                }
                else if (cells[iColums, iRows].Neighbour == 3)
                {
                    cells[iColums, iRows].Status = Status.alive;
                }
            }
        }
    }
}