using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Data;
using SpaceOrigin.Utilities;
using SpaceOrigin.DesignPatterns;

namespace SpaceOrigin.SpaceInvaders
{
    public enum GameState // state pattern
    {
        Default,
        Start,
        Running,
        GameOver
    }

    /// <summary>
    /// Controls game, initilaization of objects and game states
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        #region public varibles
        public IntSO m_gameScoreSO; // score data 
        public IntSO m_playerLifeSO; // life data
        public IntSO m_totalAliveInvadersSO; // invaderCount

        public Transform m_playerInitialePos; // player spwan position
        public InvadersManager m_invaderManager; // invader manager that present inthe game
        #endregion

        #region private varibles
        private GameState m_gameState = GameState.Default; // tracking the game state
        #endregion

        #region unity callbacks
        public override void Awake()
        {
            base.Awake(); // must be called to initialize singleton
            ResetGameData(); // reseting the scriptable object data
        }

        // Start is called before the first frame update
        IEnumerator Start()
        {
            m_gameState = GameState.Start; // game state set to Start
            m_playerLifeSO.onValueChanged.AddListener(OnPlayerLifeStatusUpdated); // adding listerner to m_playerLifeSO
            m_totalAliveInvadersSO.onValueChanged.AddListener(OnAliveInvadersCountUpdated);

            yield return new WaitForSeconds(2.0f); // Wait For score label blings
            CreateAndShowInvaders(() =>
            {
                CreateNewPlayer(); // creating new player after invaders are displayed
                m_gameState = GameState.Running; // game state changed to running
                Debug.Log("Game play starts");
            });
        }

        private void OnDestroy()
        {
            m_playerLifeSO.onValueChanged.RemoveListener(OnPlayerLifeStatusUpdated);
            m_totalAliveInvadersSO.onValueChanged.RemoveListener(OnAliveInvadersCountUpdated);
        }
        #endregion

        #region public variable
        public void ForceGameOver()
        {
            m_playerLifeSO.Value = 0;
        }
        #endregion

        #region private methods
        private void CreateAndShowInvaders(Action onComplete)
        {
            m_invaderManager.CreateAndShowInvaders(onComplete); // asking invader manager to show invaders
        }

        private void ResetGameData() // reseting game data
        {
            m_gameScoreSO.Value = 0;
            m_playerLifeSO.Value = 3;
        }

        private bool CreateNewPlayer() // creates new player using the factory pattern
        {
            Debug.Log("Creating the player");
            SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("PlayerFactory"); // getting PlayerFactory
            Player player = spaceInvaderFactory.GetPlayer(); // factory returns new player
            player.gameObject.transform.position = m_playerInitialePos.position; // assing spawn position to player
            player.gameObject.SetActive(true);
            player.InitializePlayer(); // initializing player
            return true;
        }
        #endregion

        #region event listners
        private void OnPlayerLifeStatusUpdated(int value) // called when player los any life
        {
            if (value > 0)
            {
                Invoke("CreateNewPlayer", 1.0f); // creates new player after playing layer death animation
            }
            else
            {
                Debug.Log("Game is over");
                m_invaderManager.SetStateToPause();
                m_gameState = GameState.GameOver;
            }
            // else Game
        }

        private void OnAliveInvadersCountUpdated(int value) // calls when an invader dies
        {
            if (value == 0)
            {
                Debug.Log("game is over");
                m_gameState = GameState.GameOver;
            }
        }
        #endregion
    }
}
