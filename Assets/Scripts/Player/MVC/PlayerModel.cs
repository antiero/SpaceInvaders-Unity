using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// Model class for player, stores the player 
    /// </summary>
    public class PlayerModel
    {
        #region private variables 
        private Vector3 m_position;
        private float m_moveSpeed = 1.5f;
        private float m_lastFireTime = 0.0f;
        private float m_fireInterval = 0.8f;
        #endregion

        #region events
        public delegate void PositionEvent(Vector3 position);
        public event PositionEvent OnPositionChanged;
        #endregion

        #region properties 
        public Vector3 Position
        {
            get
            {
                return m_position;
            }
            set
            {
                if (m_position != value)
                {
                     m_position = value;
                     OnPositionChanged?.Invoke(value);
                }
            }
        }

        public float MoveSpeed
        {
            get
            {
                return m_moveSpeed;
            }
        }

        public float LastFireTime
        {
            get
            {
                return m_lastFireTime;
            }
            set
            {
                m_lastFireTime = value;
            }
        }

        public float FireInterval
        {
            get
            {
                return m_fireInterval;
            }
            set
            {
                m_fireInterval = value;
            }
        }
        #endregion
    }
}
