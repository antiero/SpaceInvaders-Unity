using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceOrigin.Data;

namespace SpaceOrigin.SpaceInvaders
{
    /// <summary>
    /// Handles the game scene mangement, back to main mene happens here
    /// </summary>
    public class GameSceneManager : MonoBehaviour
    {
        #region public variables
        public string m_mainMenuSceneName;
        public IntSO m_playerLifeSO; // life data
        public IntSO m_totalAliveInvadersSO; // invaderCount
        #endregion

        #region unity callbacks
        void Start()
        {
            m_playerLifeSO.onValueChanged.AddListener(OnPlayerLifeStatusUpdated); // adding listerner to m_playerLifeSO
            m_totalAliveInvadersSO.onValueChanged.AddListener(OnAliveInvadersCountUpdated);
        }

        void OnDestroy()
        {
            m_playerLifeSO.onValueChanged.RemoveListener(OnPlayerLifeStatusUpdated);
            m_totalAliveInvadersSO.onValueChanged.RemoveListener(OnAliveInvadersCountUpdated);
        }
        #endregion

        #region private methods
        public void LoadMenuScene() 
        {
            Debug.Log("Loading main Menu Scene");
            SceneManager.LoadScene(m_mainMenuSceneName, LoadSceneMode.Single); // loads game scene
        }
        #endregion

        #region event listners
        private void OnPlayerLifeStatusUpdated(int value) // called when player los any life
        {
            if(value == 0) // game over
                Invoke("LoadMenuScene",4.0f);
        }

        private void OnAliveInvadersCountUpdated(int value) // calls when an invader dies
        {
            if (value == 0) // game over
                Invoke("LoadMenuScene", 4.0f);
        }
        #endregion
    }
}