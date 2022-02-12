using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class Drop : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private List<DropChild> children = new List<DropChild>();
    [Inject(Id = "opponent")]
    private Player opponent;

    public void Add(DropChild child)
    {
        this.children.Add(child);
        // Trigger onChildHit for each hit
        child.hit
            .Where(h => h)
            .Subscribe(_ => this.onChildHit())
            .AddTo(this);
    }

    private void onChildHit()
    {
        foreach (var child in this.children)
        {
            if (!child.hit.Value) return;
        }
        // All child are hit
        this.opponent.hp.Value -= this.damage;
        // Reset children
        foreach (var child in this.children)
        {
            child.hit.Value = false;
        }
    }
}
