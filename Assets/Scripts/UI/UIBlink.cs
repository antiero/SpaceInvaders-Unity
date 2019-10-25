using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// utility class that helps to blink UI component
    /// component must be child of UIBehaviour Class
    /// </summary>
    public class UIBlink : MonoBehaviour
    {
        #region public varaibles
        public UIBehaviour m_blinkElement; // blinkable component, 
        public float m_blinkInterval = 1.0f; // interval of the blinking
        public bool m_blinkOnStart = false; // do you need to start blink on start
        public float m_blinkDurationFromStart = 2.0f; // max time of blink after start unity callback
        #endregion

        #region private varaibles
        private bool m_blinkingNow; // checker for while loop
        #endregion

        #region unity callbacks
        // Start is called before the first frame update
        void Start()
        {
            if (m_blinkOnStart) Blink();
            if (m_blinkDurationFromStart > 0.0f) Invoke("StopBlink", m_blinkDurationFromStart); // stoping after some time
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region public methods
        public void Blink()
        {
            m_blinkingNow = true;
            StartCoroutine(BlinkIE());
        }

        public void StopBlink()
        {
            m_blinkingNow = false;
        }
        #endregion

        #region private methods
        IEnumerator BlinkIE()
        {
            while (m_blinkingNow)
            {
                m_blinkElement.enabled = !m_blinkElement.enabled;
                yield return new WaitForSeconds(m_blinkInterval); // waiting for the intervals
            }
            m_blinkElement.enabled = true;
            yield return null;
        }
        #endregion
    }
}
