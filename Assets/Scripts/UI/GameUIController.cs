using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceOrigin.Data;

namespace SpaceOrigin.SpaceInvaders
{
    public class GameUIController : MonoBehaviour
    {
        public Text m_scoreText;
        public IntSO m_gameScoreSO; // score to display
        public IntSO m_playerLifeSO;

        // Start is called before the first frame update
        void Start()
        {
            m_gameScoreSO.onValueChanged.AddListener(OnGameScoreUpdated); // 
        }

        // Update is called once per frame
        void Update()
        {
            // not a good aprach so ,we can also implement event base update ssytem. Time :(
        }

        private void OnDestroy()
        {
            m_gameScoreSO.onValueChanged.RemoveListener(OnGameScoreUpdated);
        }

        private void OnGameScoreUpdated(int value)
        {
            m_scoreText.text = m_gameScoreSO.Value.ToString();
        }
    }
}
