using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player runtime instance
public class Player : MonoBehaviour
{
    public PlayerState state { get; private set; }

    // Set player state and initliaze runtime state
    public void SetState(PlayerState state)
    {
        this.state = state;
    }
}
