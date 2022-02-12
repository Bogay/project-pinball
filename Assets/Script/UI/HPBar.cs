using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class HPBar : MonoBehaviour
{
    [Inject]
    private PlayerRepository repository;
    [SerializeField]
    private int playerId;

    void Start()
    {
        var player = this.repository[this.playerId];
        var image = GetComponent<Image>();
        // TODO: Smooth it
        player.hp
            .Select(h => (float)h / player.state.maxHP)
            .Do(r => image.fillAmount = r)
            .Subscribe()
            .AddTo(this);
    }
}
