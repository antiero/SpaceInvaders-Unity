using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Utilities
{
    /// <summary>
    /// Helper class to visualize the 2d Grid. only will render in editor mode
    /// </summary>
    public class Grid2DVisualizer : MonoBehaviour
    {
        #region public  variables
        public int m_rows; // number of raws inside the cell
        public int m_columns; // number of columns inside the cell
        public float m_cellWidth; //  width of the cell
        public float m_cellHeight;//  height of the cell
        #endregion

        #region private  variables
        private Grid2D m_2DGrid;
        private Vector3 m_lastTransPosition;
        #endregion

        #region unity events
        private void OnValidate()
        {
            m_2DGrid = null; // quick fix to update grid on value change in the inspecete
        }
        #endregion

        #region gizmos region
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
            {
                if (m_2DGrid == null | transform.position != m_lastTransPosition )
                {
                    m_lastTransPosition = transform.position;
                    m_2DGrid = new Grid2D(m_rows, m_columns, m_cellWidth, m_cellHeight, transform.position);
                }

                DrawGridCells();
            }
        }

        // draws the grid in the scene 
        private void DrawGridCells()
        {
            if (m_2DGrid == null) return;

            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    Cell cell = m_2DGrid.Cells[i][j];
                  
                    Vector3 bottomLeftPos = new Vector3(cell.m_center.x - cell.m_width / 2, cell.m_center.y - cell.m_height / 2, cell.m_center.z);
                    Vector3 bottomRightPos = new Vector3(cell.m_center.x + cell.m_width / 2, cell.m_center.y - cell.m_height / 2, cell.m_center.z);
                    Vector3 topLeftPos = new Vector3(cell.m_center.x - cell.m_width / 2, cell.m_center.y + cell.m_height / 2, cell.m_center.z);
                    Vector3 topRightPos = new Vector3(cell.m_center.x + cell.m_width / 2, cell.m_center.y + cell.m_height / 2, cell.m_center.z);

                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(bottomLeftPos, bottomRightPos);
                    Gizmos.DrawLine(bottomRightPos, topRightPos);
                    Gizmos.DrawLine(topRightPos, topLeftPos);
                    Gizmos.DrawLine(topLeftPos, bottomLeftPos);

                    Gizmos.DrawSphere(cell.m_center, .02f);
                }
            }
        }
        #endregion
    }
}
