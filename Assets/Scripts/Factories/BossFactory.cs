using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;

namespace SpaceOrigin.SpaceInvaders
{
    public class BossFactory : SpaceInvaderFactory
    {
        public override Boss GetBoss()
        {
            return PoolManager.Instance.GetObjectFromPool("Boss").GetComponent<Boss>();
        }

        public override void RecycleBoss(Boss boss)
        {
            PoolManager.Instance.PutObjectBacktoPool(boss.gameObject);
        }
    }
}

