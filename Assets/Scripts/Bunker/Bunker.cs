using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// handles bunker and its damages
    /// </summary>
    /// 
    public class Bunker : MonoBehaviour
    {
        #region private varibales
        private float m_radiusOfPixelCheck = 8.04f;
        private SpriteRenderer m_bunkerSprite;  // bunker sprite coomponent
        #endregion

        #region unity callbacks
        // Start is called before the first frame update
        void Start()
        {
            m_bunkerSprite = gameObject.GetComponent<SpriteRenderer>(); // accesing the sprite components
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void OnTriggerEnter2D(Collider2D other)
        {

        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "InvaderShot")
            {
                Vector3 hitTestPosition = other.gameObject.transform.position - Vector3.forward * 2.0f;
                if (CheckBunkerHit(hitTestPosition, -Vector3.up) || CheckBunkerHit(hitTestPosition + Vector3.up * .01f, -Vector3.up) || CheckBunkerHit(hitTestPosition - Vector3.up * .01f, -Vector3.up))
                {
                    other.gameObject.GetComponent<InvaderBullet>().DestroyBullet();
                }
            }
            else if (other.gameObject.tag == "PlayerBullet")
            {
                Vector3 hitTestPosition = other.gameObject.transform.position - Vector3.forward * 2.0f;
                if (CheckBunkerHit(hitTestPosition, Vector3.up))
                {
                    other.gameObject.GetComponent<PlayerBullet>().DestroyBullet();
                }
            }
            else if (other.gameObject.tag == "Invader")
            {
                Destroy(gameObject);
            }
        }
        #endregion

        #region private varibales
        private bool CheckBunkerHit(Vector3 rayCastPoint, Vector3 hitDir)
        {
            Ray ray = new Ray();
            ray.origin = rayCastPoint;
            ray.direction = Vector3.forward;
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 4.0f);
            if (hit.collider != null)
            {
                Vector2 coords = TextureSpaceCoord(hit.point);
                Color pixel = m_bunkerSprite.sprite.texture.GetPixel((int)coords.x, (int)coords.y);

                bool notDamagedArea = false;
                if (pixel.a != 0) notDamagedArea = true;

                pixel = new Color(0,0,0,0);
                Texture2D sourceTex = m_bunkerSprite.sprite.texture;
                Color32[] pix = sourceTex.GetPixels32();
                Texture2D destTex = new Texture2D(sourceTex.width, sourceTex.height);
                destTex.SetPixels32(pix);

                destTex.wrapMode = TextureWrapMode.Clamp;
                int startX = (int)coords.x - 7;
                int startY = (int)coords.y;
                int rowLenght = Random.Range(7, 20);
                int columnRange = Random.Range(4, 10);
                int yDestroyDirection = (int)Mathf.Sign(hitDir.y);

                for (int i = 0; i < rowLenght; i++) // i have to write some better code
                {
                    for (int j = 0; j < columnRange; j++)
                    {
                        destTex.SetPixel(startX + i, startY+j* yDestroyDirection, pixel);
                    }
                }

                destTex.Apply();

                Sprite mySprite = Sprite.Create(destTex, new Rect(0.0f, 0.0f, destTex.width, destTex.height), new Vector2(0.5f, 0.5f), 160.0f);
                m_bunkerSprite.sprite = mySprite;
                if (notDamagedArea) return true;
            }

            return false;
        }
        
        private Vector2 TextureSpaceCoord(Vector3 worldPos)
        {
            float ppu = m_bunkerSprite.sprite.pixelsPerUnit;
            Vector2 localPos = transform.InverseTransformPoint(worldPos) * ppu;
            var texSpacePivot = new Vector2(m_bunkerSprite.sprite.rect.x, m_bunkerSprite.sprite.rect.y) + m_bunkerSprite.sprite.pivot;
            Vector2 texSpaceCoord = texSpacePivot + localPos;
            return texSpaceCoord;
        }
        #endregion
    }
}

