using UnityEngine;
using Zenject;

public class DropInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var drop = GetComponent<Drop>();
        Debug.Assert(drop != null, "DropInstaller should be attached on a GameObject with Drop");
        Container.BindInstance(drop).AsCached();
    }
}