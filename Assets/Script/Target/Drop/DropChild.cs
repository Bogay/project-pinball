using UnityEngine;
using Zenject;
using UniRx;

namespace Pinball.Target
{
    [RequireComponent(typeof(Collider2D))]
    public class DropChild : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private Sprite normal;
        [SerializeField]
        private Sprite triggered;
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
                sprite.sprite = h ? this.triggered : this.normal;
                // Disable collider if self is hit
                GetComponent<Collider2D>().enabled = !h;
            }).AddTo(this);
        }

        // TODO: Add VFX
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (this.hit.Value) return;

            if (other.gameObject.CompareTag("Ball"))
            {
                SceneAudioManager.instance.PlayByName("hit2");
                this.hit.Value = true;
                this.opponent.hp.Value -= this.damage;
            }
        }
    }
}
