using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Inputs;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerController : MonoBehaviour, IFireCommand, IMoveCommand
    {
        private PlayerView m_playerView;
        private PlayerModel m_playerModel;

        public void Start()
        {
         
        }

        void OnDisable()
        { 
            InputHandler.Instance.m_fireCommand = null;
            InputHandler.Instance.m_moveCommand = null;
        }

        public void CreatePlayerController(PlayerModel playerModel)
        {
            m_playerView = GetComponent<PlayerView>(); // view is attached to the same object
            m_playerModel = playerModel;
            m_playerModel.OnPositionChanged += m_playerView.SetPosition;
            InputHandler.Instance.m_fireCommand = this;
            InputHandler.Instance.m_moveCommand = this;
        }

        #region input callbacks
        public void ExecuteFire() // invokded from Input handler
        {
            if(m_playerModel.LastFireTime + m_playerModel.FireInterval <= Time.time) // handling firing interval
            {
                SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("PlayerBulletFactory"); // accessomg InvaderFactory
                PlayerBullet playerBullet = spaceInvaderFactory.GetPlayerBullet();

                playerBullet.transform.position = m_playerModel.Position + new Vector3(0, .3f, 0); // adding little offset on y axist for stating not fromcentre
                playerBullet.transform.rotation = Quaternion.identity;
                playerBullet.gameObject.SetActive(true);

                m_playerModel.LastFireTime = Time.time;

                playerBullet.PlayFireSound();
            } 
        }

        public void ExecuteMove(float direction) // invokded from Input handler
        {
            Vector3 playerLastPosition = m_playerModel.Position;
            Vector3 newPosition = new Vector3(playerLastPosition.x + m_playerModel.MoveSpeed * direction * Time.deltaTime, playerLastPosition.y, playerLastPosition.z);

            if (newPosition.x +.3f >= SpaceBoundary.Instance.RightMax || newPosition.x -.3f <= SpaceBoundary.Instance.LeftMax)
            {
                m_playerModel.Position = playerLastPosition;
            }
            else
            {
                m_playerModel.Position = newPosition;
            }
            #endregion
        }
    }
}

