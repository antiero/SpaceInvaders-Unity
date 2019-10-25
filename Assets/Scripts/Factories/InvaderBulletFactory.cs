using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;

namespace SpaceOrigin.SpaceInvaders
{
    public class InvaderBulletFactory : SpaceInvaderFactory
    {
        public override InvaderBullet GetInvaderBullet(InvaderBulletTypes type)
        {
            return PoolManager.Instance.GetObjectFromPool(type.ToString()).GetComponent<InvaderBullet>();
        }

        public override void RecycleInvaderBullet(InvaderBullet invaderBullet)
        {
            PoolManager.Instance.PutObjectBacktoPool(invaderBullet.gameObject);
        }
    }
}
