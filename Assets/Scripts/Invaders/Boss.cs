using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Data;
using SpaceOrigin.Utilities;

namespace SpaceOrigin.SpaceInvaders
{
    public class Boss : MonoBehaviour, IKillable
    {
        #region public variables
        public float m_directionMove = 1; //
        public InvadersManager m_invaderManger; // can we  avoid this kind of dependeis?
        #endregion

        #region private variables
        private float m_moveSpeed = 1.3f;
        private AudioSource m_audioSource;
        #endregion

        #region unity callback variables
        void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector3( m_moveSpeed * Time.deltaTime* m_directionMove, 0, 0));
        }

        void FixedUpdate()
        {
            // resend to teh factory if the position goes beyonf boundary
            if ((m_directionMove > 0 &&transform.position.x > 3.6f) || (m_directionMove < 0 && transform.position.x < -3.6f))// reached borders
            {
                gameObject.SetActive(false);
                SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("BossFactory"); // accessomg boss factoy
                spaceInvaderFactory.RecycleBoss(this);
                m_invaderManger.RemoveBoss();
            }
        }
        #endregion

        #region interface implementations
        public void PlaySound()
        {
            m_audioSource.Play();
        }

        public void Kill()
        {
            gameObject.SetActive(false);
            m_invaderManger.DestroyBoss(this);
            m_audioSource.Stop();
        }




        #endregion
    }
}
