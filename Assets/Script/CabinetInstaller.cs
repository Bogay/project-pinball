using UnityEngine;
using Zenject;

public class CabinetInstaller : MonoInstaller<CabinetInstaller>
{
    [Inject]
    private PlayerRepository repository;
    // Where to spawn the ball
    [SerializeField]
    private Vector3 spawnPosition;
    [SerializeField]
    private int me;
    [SerializeField]
    private int opponent;

    public override void InstallBindings()
    {
        Container.BindInstance(this.repository[this.opponent]).WithId("opponent").AsCached();
        var playerMe = this.repository[this.me];
        Container.BindInstance(playerMe).WithId("me").AsCached();
        Container.Bind<SkillHolder>().FromComponentsInChildren();
    }
}
