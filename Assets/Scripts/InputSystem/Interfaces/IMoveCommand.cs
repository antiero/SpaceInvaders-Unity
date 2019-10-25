using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Inputs
{
    /// <summary>
    /// command for move execution when the user presses the axis bar
    /// </summary>
    public interface IMoveCommand
    {
        void ExecuteMove(float direction);
    }
}
