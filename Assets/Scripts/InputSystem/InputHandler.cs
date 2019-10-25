using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.DesignPatterns;

namespace SpaceOrigin.Inputs
{
    /// <summary>
    /// class for handling inputs, just for the spaceinvaders now
    /// </summary>
    public class InputHandler : Singleton<InputHandler>
    {
        public IFireCommand m_fireCommand;
        public IMoveCommand m_moveCommand;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && m_fireCommand != null)
            {
                m_fireCommand.ExecuteFire();
            }

            float axisDirection = Input.GetAxisRaw("Horizontal");

            if (axisDirection != 0 && m_moveCommand != null) // if axis the key pressed, it will execute the Move command
            {
                m_moveCommand.ExecuteMove(axisDirection);
            }
        }
    }
}
