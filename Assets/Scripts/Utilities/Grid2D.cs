using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Utilities
{
    /// <summary>
    /// Cell individual blocks of the grid
    /// </summary>
    public struct Cell 
    {
        public Vector3 m_center;
        public float m_height;
        public float m_width;
    }

    /// <summary>
    /// class for creating  2d Grids 
    /// </summary>
    public class Grid2D
    {
        #region private  variables
        private int m_rows; // number of raws inside the cell
        private int m_columns; // number of columns inside the cell
        private float m_cellWidth; //  width of the cell
        private float m_cellHeight;//  height of the cell
        private Cell[][] m_cells;
        #endregion

        #region properties  variables
        public Cell[][] Cells
        {
            get { return m_cells; }
        }
        #endregion

        #region constructor
        public Grid2D(int rows, int columns, float cellWidth, float cellHeight, Vector3 gridRootPosition)
        {
            m_rows = rows;
            m_columns = columns;
            m_cellWidth = cellWidth;
            m_cellHeight = cellHeight;

            m_cells = new Cell[m_rows][];
            for (int i = 0; i < m_rows; i++)
            {
                m_cells[i] = new Cell[m_columns];
            }

            CalculateGridCells(gridRootPosition);
        }
        #endregion

        #region private methods
        // caluclates cell centre
        private void CalculateGridCells(Vector3 gridRootPosition)
        {
            Vector3 centrePosition = gridRootPosition;
            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    Cell cell = new Cell();
                    cell.m_width = m_cellWidth;
                    cell.m_height = m_cellHeight;

                    Vector2 cellPos = new Vector2((float)j * cell.m_width, (float)i * -cell.m_height);
                    cell.m_center = centrePosition + new Vector3(cellPos.x, cellPos.y, 0) + new Vector3(-m_columns / 2 * cell.m_width, 0, 0);
                    m_cells[i][j] = cell;
                }
            }
        }
        #endregion
    }
}
