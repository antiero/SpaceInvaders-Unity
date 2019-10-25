using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceOrigin.Data;

namespace SpaceOrigin.SpaceInvaders
{

    /// <summary>
    /// Displayes the UI and updates this aswell
    /// </summary>
    public class GameUIController : MonoBehaviour
    {
        #region public varaible 
        public Text m_scoreText;
        public Text m_lifeText;
        public Text m_gameOverText;

        public IntSO m_gameScoreSO; // score to display
        public IntSO m_playerLifeSO; // life to display
        public IntSO m_totalAliveInvadersSO; // helps to show game over screen
        #endregion

        #region unity callbacks
        private void Awake()
        {
            m_gameOverText.gameObject.SetActive(false); // desabling game over text
        }

        // Start is called before the first frame update
        void Start()
        {
            m_gameScoreSO.onValueChanged.AddListener(OnGameScoreUpdated); // registering listner to score SO
            m_playerLifeSO.onValueChanged.AddListener(OnPLayerLifeUpdated);
            m_totalAliveInvadersSO.onValueChanged.AddListener(OnAliveInvadersCountUpdated);
        }

        private void OnDestroy()
        {
            m_gameScoreSO.onValueChanged.RemoveListener(OnGameScoreUpdated); // removing listner to score SO
            m_playerLifeSO.onValueChanged.RemoveListener(OnPLayerLifeUpdated);
            m_totalAliveInvadersSO.onValueChanged.RemoveListener(OnAliveInvadersCountUpdated);
        }
        #endregion

        #region public varaible 
        private void OnGameScoreUpdated(int value) // calls on score update
        {
            m_scoreText.text = m_gameScoreSO.Value.ToString();
        }

        private void OnPLayerLifeUpdated(int value) // calls when player loses life
        {
            m_lifeText.text = m_playerLifeSO.Value.ToString();
            if (value == 0) m_gameOverText.gameObject.SetActive(true); // enabling game over text
        }

        private void OnAliveInvadersCountUpdated(int value) // calls when an invader dies
        {
            if(value == 0) m_gameOverText.gameObject.SetActive(true); // enabling game over text

        }
        #endregion
    }
}
