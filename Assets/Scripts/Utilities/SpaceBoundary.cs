using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.DesignPatterns;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// Boundary struct defines the bounds of the Game area, only will render in editor mode
    /// </summary>
    public struct Boundary
    {
        public Vector3 m_centre; // center of the boundary
        public float m_xRight; // positive right direction
        public float m_yUp; // positive up direction
    }

    /// <summary>
    /// class for calculating and storing bounds of the playable area.
    /// its centre is fixed at world position (0,0,z)
    /// </summary>
    public class SpaceBoundary : Singleton<SpaceBoundary>
    {
        #region public variables
        public float m_boundaryWidth; // total width of the boundary
        public float m_boundaryHeight; // total height of the boundary
        public bool m_showGizmozePlayMode = false;
        #endregion 

        public float RightMax // max right 
        {
            get { return m_boundary.m_xRight; }
        }

        public float LeftMax // max Left
        {
            get { return -m_boundary.m_xRight; }
        }

        private Boundary m_boundary; // present game boundary

        #region unity events
        public override void Awake()
        {
            base.Awake();
            CalculateBoundary();
        }
        // removed update and start methods which are not needed
        #endregion

        #region gizmos region
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying | m_showGizmozePlayMode)
            {
                CalculateBoundary();
                DrawBoundary();
            }
        }

        private void DrawBoundary()
        {
            Vector3 bottomLeftPos = new Vector3(-m_boundary.m_xRight, -m_boundary.m_yUp, m_boundary.m_centre.z);
            Vector3 bottomRightPos = new Vector3(m_boundary.m_xRight, -m_boundary.m_yUp, m_boundary.m_centre.z);
            Vector3 topLeftPos = new Vector3(-m_boundary.m_xRight, m_boundary.m_yUp, m_boundary.m_centre.z);
            Vector3 topRightPos = new Vector3(m_boundary.m_xRight, m_boundary.m_yUp, m_boundary.m_centre.z);

            Gizmos.color = Color.yellow;
           
            Gizmos.DrawLine(bottomLeftPos, bottomRightPos);
            Gizmos.DrawLine(bottomRightPos, topRightPos);
            Gizmos.DrawLine(topRightPos, topLeftPos);
            Gizmos.DrawLine(topLeftPos, bottomLeftPos);
        }
        #endregion

        #region private region
        // calculate the boundary bounds
        private void CalculateBoundary()
        {
            Vector3 centerPosition = transform.position;
            m_boundary = new Boundary();
            m_boundary.m_centre = centerPosition;

            float xRight = m_boundaryWidth / 2; // centre + half of actual width
            float yUp =  m_boundaryHeight / 2; // centre + half of actual height

            m_boundary.m_xRight = xRight;
            m_boundary.m_yUp = yUp;  
        }
        #endregion
    }
}
