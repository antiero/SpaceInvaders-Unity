using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;

namespace SpaceOrigin.SpaceInvaders
{
    public class EffectsFactory : SpaceInvaderFactory
    {
        public override Effects GetEffects(EffectsType effectType)
        {
            return PoolManager.Instance.GetObjectFromPool(effectType.ToString()).GetComponent<Effects>(); // we are assuming enum name is same as gameobject name
        }

        public override void RecycleEffect(Effects effects)
        {
            PoolManager.Instance.PutObjectBacktoPool(effects.gameObject);
        }
    }
}
