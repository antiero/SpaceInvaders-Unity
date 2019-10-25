using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// Factory for creating and recycling player
    /// </summary>
    public class PlayerFactory : SpaceInvaderFactory
    {
        public override Player GetPlayer()
        {
            return PoolManager.Instance.GetObjectFromPool("Player").GetComponent<Player>();
        }

        public override void RecyclePlayer(Player player)
        {
            PoolManager.Instance.PutObjectBacktoPool(player.gameObject);
        }
    }
}
