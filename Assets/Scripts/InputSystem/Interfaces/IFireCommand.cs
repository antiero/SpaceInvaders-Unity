using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Inputs
{
    /// <summary>
    /// command for fire execution when the user press teh spacebar
    /// </summary>
    public interface IFireCommand
    {
        void ExecuteFire();
    }
}

