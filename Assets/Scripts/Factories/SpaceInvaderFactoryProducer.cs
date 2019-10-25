using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SpaceOrigin.SpaceInvaders
{
    public class SpaceInvaderFactoryProducer 
    {
        public static SpaceInvaderFactory GetFactory(string factoryName)
        {
            switch (factoryName)
            {
                case "InvaderFactory":
                    return new InvaderFactory();

                case "InvaderBulletFactory":
                    return new InvaderBulletFactory();

                case "PlayerBulletFactory":
                    return new PlayerBulletFactory();

                case "EffectsFactory":
                    return new EffectsFactory();

                default:
                    return null;
            }
        }
    }
}
