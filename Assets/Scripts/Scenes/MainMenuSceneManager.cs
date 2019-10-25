using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Inputs;
using UnityEngine.SceneManagement;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// Handles the main menu scene, Game scene loads from here
    /// </summary>
    public class MainMenuSceneManager : MonoBehaviour, IFireCommand
    {
        #region public variables
        public string m_gameSceneName; 
        #endregion

        #region unity callbacks
        void Start()
        {
            InputHandler.Instance.m_fireCommand = this; // adding listner to the input handler
        }
        void OnDestroy()
        {
            InputHandler.Instance.m_fireCommand = null; // removing listner
        }
        #endregion

        #region input callbacks
        public void ExecuteFire() // invokded from Input handler when user pres space bar
        {
            Debug.Log("Loading game Scene");
            SceneManager.LoadScene(m_gameSceneName, LoadSceneMode.Single); // loads game scene
        }
        #endregion
    }
}
