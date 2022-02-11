using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerRepository repository;

    public override void InstallBindings()
    {
        var players = FindObjectsOfType<Player>();
        this.repository.BindPlayers(players);
        Container.BindInstance(this.repository).AsSingle();
    }
}
