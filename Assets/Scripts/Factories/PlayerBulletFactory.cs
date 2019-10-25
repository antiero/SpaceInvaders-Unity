using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;

namespace SpaceOrigin.SpaceInvaders
{
    public class PlayerBulletFactory : SpaceInvaderFactory
    {
        public override PlayerBullet GetPlayerBullet()
        {
            return PoolManager.Instance.GetObjectFromPool("PlayerBullet").GetComponent<PlayerBullet>();
        }

        public override void RecyclePlayerBullet(PlayerBullet playerbullet)
        {
            PoolManager.Instance.PutObjectBacktoPool(playerbullet.gameObject);
        } 
    }
}
