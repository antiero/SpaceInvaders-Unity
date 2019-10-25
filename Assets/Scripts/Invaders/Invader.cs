using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Data;
using SpaceOrigin.Utilities;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// enum defines different types of space invaders
    /// </summary>
    public enum InvaderTypes
    {
        Octopus, //30 psoints
        Crab, // 20 points
        Squid // 10 points  
    }

    /// <summary>
    /// Invader class, No need for complicated inheritance here
    /// </summary>
    public class Invader : MonoBehaviour, IKillable, IAnimatable
    {
        #region public varibales
        public Sprite[] m_walkStateSprites;
        public InvaderTypes m_type;
        public IntSO m_killValue;

        // change latter to property, dont expose to inspecter
        public InvadersManager m_invaderManger; // manager reference
        public int m_rowIndex; //row index in the invader manger array, this will helps to remove the object once it is hit by the bulltet
        public int m_coumnIndex; //column index in the invader manger array,
        #endregion

        #region public varibales
        private int m_currentSpriteIndex = 0;
        private SpriteRenderer m_spriteRender;
        #endregion

        #region unity callbacks
        public void Start()
        {
            m_spriteRender = GetComponent<SpriteRenderer>();
        }
        #endregion

        #region interface implementations
        public void Kill()
        {
            gameObject.SetActive(false);
            m_invaderManger.DestroyInvader(this);
        }

        public void PlayAnimation()
        {
            ChangeWalkState();
        }
        #endregion

        #region public methods
        public void Move(Vector3 deltaMove)
        {
            gameObject.transform.position += deltaMove;
        }
        #endregion

        #region private methods
        private void ChangeWalkState()
        {
            m_currentSpriteIndex++;
            if (m_currentSpriteIndex >= m_walkStateSprites.Length) m_currentSpriteIndex = 0;

            m_spriteRender.sprite = (m_walkStateSprites[m_currentSpriteIndex]);
        }
        #endregion
    }
}
