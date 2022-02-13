using UnityEngine;
using Zenject;
using UniRx;

namespace Pinball.Target
{
    public class Standup : MonoBehaviour
    {
        [Inject(Id = "opponent")]
        private Player opponent;
        [SerializeField]
        private int damage = 1;
        public ReactiveProperty<bool> triggered = new ReactiveProperty<bool>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                SceneAudioManager.instance.PlayByName("hit3");
                this.triggered.Value = true;
                this.opponent.hp.Value -= this.damage;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            this.triggered.Value = false;
        }
    }
}
