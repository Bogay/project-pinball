using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.SceneManagement;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerRepository repository;
    [Inject]
    private GameResult result;

    public override void InstallBindings()
    {
        var players = FindObjectsOfType<Player>();
        this.repository.BindPlayers(players);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].hp
                .Where(hp => hp == 0)
                // TODO: This only work for 0 & 1 ...
                .Subscribe(this.PlayerWin(1 - i));
        }
        Container.BindInstance(this.repository).AsSingle();
    }

    // TODO: Enhance game result recording
    // Set winner and load end scene
    private System.Action<int> PlayerWin(int playerIndex)
    {
        return (_) =>
        {
            this.result.win = playerIndex;
            SceneManager.LoadScene("End");
        };
    }
}
