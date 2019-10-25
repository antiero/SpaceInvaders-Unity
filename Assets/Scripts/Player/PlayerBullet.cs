using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Utilities;

namespace SpaceOrigin.SpaceInvaders
{
    public class PlayerBullet : MonoBehaviour
    {
        private float m_moveSpeed = 10.0f;
        private AudioSource m_audioSource;

        void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

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
            if (transform.position.y > 3.4f) // if the colliion to the top border doent work as expected; hard code value
            {
                Exlode();
                Destroy();
            }
        }

        public void DestroyBullet()
        {
            Destroy();
        }

        private void Exlode()
        {
            SpaceInvaderAbstractFactory spaceInvaderFactory =  SpaceInvaderFactoryProducer.GetFactory("EffectsFactory");
            Effects invadeExplodeEffect = spaceInvaderFactory.GetEffects(EffectsType.PlayerbulletExplode);
            invadeExplodeEffect.transform.position = transform.position;
            invadeExplodeEffect.transform.rotation = Quaternion.identity;
            invadeExplodeEffect.gameObject.SetActive(true);
            invadeExplodeEffect.DestroyAfterSomeTime(.15f);
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

            else if (col.gameObject.tag == "Boss")
            {
                Destroy();
                col.gameObject.GetComponent<Boss>().Kill();
            }

            else if (col.gameObject.tag == "Bunker")
            {
                Destroy();
            }

            else  if(col.gameObject.tag == "Border")
            {
                Exlode();
                Destroy();
            }
        }

        public void PlayFireSound()
        {
            m_audioSource.Play();
        }
    }
}
