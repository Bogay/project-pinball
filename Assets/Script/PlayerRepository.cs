using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new PlayerRepository", menuName = "Player/Repository")]
public class PlayerRepository : ScriptableObject
{
    [SerializeField]
    private List<PlayerState> states;

    private List<Player> players;

    public void BindPlayers(Player[] players)
    {
        if (players.Length != this.states.Count)
        {
            var message = $"Except there is {this.states.Count} players but got {players.Length}";
            throw new ArgumentException(message);
        }
        this.players = new List<Player>(players);
        for (int i = 0; i < this.players.Count; i++)
        {
            this.players[i].SetState(this.states[i]);
        }
    }

    public Player this[int index] { get => this.players[index]; }
}
