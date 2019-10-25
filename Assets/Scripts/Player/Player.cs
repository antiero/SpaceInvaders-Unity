using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Data;

namespace SpaceOrigin.SpaceInvaders
{
    public class Player : MonoBehaviour, IKillable
    {
        public IntSO m_playerLifeSO;
        private PlayerController m_playerController;
        // Start is called before the first frame update
        void Awake()
        {
            m_playerController = GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitializePlayer()
        {
            PlayerModel playerModel = new PlayerModel();
            playerModel.Position = transform.position;
            m_playerController.CreatePlayerController(playerModel);
        }

        public void Kill()
        {
            Debug.Log("Player dies");
            gameObject.SetActive(false);
            SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("PlayerFactory");
            spaceInvaderFactory.RecyclePlayer(this);
            Exlode();
            m_playerLifeSO.Value = m_playerLifeSO.Value - 1;
        }

        private void Exlode()
        {
            SpaceInvaderAbstractFactory spaceInvaderFactory = SpaceInvaderFactoryProducer.GetFactory("EffectsFactory");
            Effects invadeExplodeEffect = spaceInvaderFactory.GetEffects(EffectsType.PlayerExplode);
            invadeExplodeEffect.transform.position = transform.position;
            invadeExplodeEffect.transform.rotation = Quaternion.identity;
            invadeExplodeEffect.gameObject.SetActive(true);
            invadeExplodeEffect.DestroyAfterSomeTime(.8f);
        }
    }
}
