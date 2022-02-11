using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Cabinet : MonoBehaviour
{
    [Inject(Id = "me")]
    private Player me;
    [SerializeField]
    private Flipper left;
    [SerializeField]
    private Flipper right;

    private void Start()
    {
        Debug.Assert(this.me != null);
        this.left.triggerKey = this.me.state.left;
        this.right.triggerKey = this.me.state.right;
    }
}
