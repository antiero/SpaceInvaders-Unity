using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceOrigin.Utilities
{
    public class Trigger2DEventRaiser : MonoBehaviour
    {
        public UnityEvent m_triggerEvent;
        public string m_otherObjTag;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == m_otherObjTag)
            {
                if(m_triggerEvent != null)
                     m_triggerEvent.Invoke();
            }
        }
    }
}
