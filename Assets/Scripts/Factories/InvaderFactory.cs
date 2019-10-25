using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;


namespace SpaceOrigin.SpaceInvaders
{
    public class InvaderFactory : SpaceInvaderFactory
    {
        public override Invader GetInvader(InvaderTypes type)
        {
            return PoolManager.Instance.GetObjectFromPool(type.ToString()).GetComponent<Invader>();
        }

        public override void RecycleInvader(Invader invader)
        {
            PoolManager.Instance.PutObjectBacktoPool(invader.gameObject);
        }
    }
}
