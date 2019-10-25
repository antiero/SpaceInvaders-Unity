using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Data;

namespace SpaceOrigin.SpaceInvaders
{ 
    public class GameManager : MonoBehaviour
    {
        public IntSO m_gameScoreSO; // score to display
        public IntSO m_playerLifeSO;

        // Start is called before the first frame update
        void Start()
        {
            ResetGameData();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void ResetGameData()
        {
            m_gameScoreSO.Value = 0;
            m_playerLifeSO.Value = 0;
        }
    }
}
