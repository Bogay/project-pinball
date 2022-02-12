using UnityEngine;
using Zenject;
using UniRx;

public class DropChild : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [Inject]
    private Drop parent;
    [Inject(Id = "opponent")]
    private Player opponent;
    public BoolReactiveProperty hit { get; private set; } = new BoolReactiveProperty();

    void Start()
    {
        // Register self on parent
        this.parent.Add(this);

        var sprite = GetComponent<SpriteRenderer>();
        this.hit.Subscribe(h =>
        {
            sprite.color = h ? Color.red : Color.white;
        }).AddTo(this);
    }

    // TODO: Add VFX
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (this.hit.Value) return;

        if (other.gameObject.CompareTag("Ball"))
        {
            this.hit.Value = true;
            this.opponent.hp.Value -= this.damage;
        }
    }
}
