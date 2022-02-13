using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new GameResult());
    }
}
