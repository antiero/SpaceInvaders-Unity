using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Utilities;

namespace SpaceOrigin.SpaceInvaders
{
    public class PlayerBullet : MonoBehaviour
    {
        private float m_moveSpeed = 10.0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector3(0, m_moveSpeed * Time.deltaTime, 0));
        }

        void FixedUpdate()
        {
           
        }

        public void DestroyBullet()
        {
            Destroy();
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
            SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("PlayerBulletFactory"); // accessomg InvaderFactory
            spaceInvaderFactory.RecyclePlayerBullet(this);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Invader")
            {
                Destroy();
                col.gameObject.GetComponent<Invader>().Kill();
            }

            if (col.gameObject.tag == "Bunker")
            {
                Destroy();
            }
        }
    }
}
