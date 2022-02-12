using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

// Player runtime instance
public class Player : MonoBehaviour
{
    public PlayerState state { get; private set; }
    public ReactiveProperty<int> hp { get; private set; }

    // Set player state and initliaze runtime state
    public void SetState(PlayerState state)
    {
        this.state = state;
        this.hp = new ReactiveProperty<int>(this.state.maxHP);
    }
}
