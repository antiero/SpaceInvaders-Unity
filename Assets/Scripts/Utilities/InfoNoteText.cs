using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Utilities
{
    /// <summary>
    /// helper class adding helper comments to the game objects.
    /// </summary>
    public class InfoNoteText : MonoBehaviour
    {
        [TextArea]
        public string m_note = " add comment here";
    }
}
