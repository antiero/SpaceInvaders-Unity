using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.SpaceInvaders
{
    public class SpaceInvaderFactory : SpaceInvaderAbstractFactory
    {
        public override Effects GetEffects(EffectsType effectType)
        {
            return null;
        }

        public override Invader GetInvader(InvaderTypes type)
        {
           
            return null;
        }

        public override InvaderBullet GetInvaderBullet(InvaderBulletTypes type)
        {
           
            return null;
        }

        public override PlayerBullet GetPlayerBullet()
        {
            return null;
        }

        public override Player GetPlayer()
        {
            return null;
        }

        public override Boss GetBoss()
        {
            return null;
        }

        public override void RecyclePlayerBullet(PlayerBullet playerbullet)
        {
            
        }

        public override void RecycleInvader(Invader invader)
        {
        }

        public override void RecycleEffect(Effects effects)
        {   
        }

        public override void RecycleInvaderBullet(InvaderBullet invaderBullet)
        {  
        }

        public override void RecyclePlayer(Player player)
        {
        }

        public override void RecycleBoss(Boss boss)
        {
        }  
    }
}
