using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// enum defines different types of bullets
    /// </summary>
    public enum InvaderBulletTypes
    {
        SquiglyShot,
        PlungerShot,
        RollingShot
    }

    public class InvaderBullet : MonoBehaviour
    {
        public InvaderBulletTypes m_bulletType;
        private float m_moveSpeed = 2.0f;

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.Translate(new Vector3(0, -m_moveSpeed * Time.deltaTime, 0));
        }

        public void DestroyBullet()
        {
            Destroy();
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
            SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("InvaderBulletFactory"); // accessomg InvaderFactory
            spaceInvaderFactory.RecycleInvaderBullet(this);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                Destroy();
                col.gameObject.GetComponent<Player>().Kill();
            }

            if (col.gameObject.tag == "Border")
            {
                Destroy();
            }
        }
    }
}

