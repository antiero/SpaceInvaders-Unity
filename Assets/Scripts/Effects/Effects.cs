using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceOrigin.SpaceInvaders
{
    public enum EffectsType
    {
        AlianExplodeEffect
    }

    public class Effects : MonoBehaviour
    {
        public void DestroyAfterSomeTime(float time)
        {
            Invoke("DestroyEffect", time);
        }

        private void DestroyEffect()
        {
            gameObject.SetActive(true); 
            SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("EffectsFactory");
            spaceInvaderFactory.RecycleEffect(this);
        }

    }
}
