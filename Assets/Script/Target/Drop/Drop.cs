using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using DG.Tweening;

namespace Pinball.Target
{
    public class Drop : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private float delay = 1;
        private List<DropChild> children = new List<DropChild>();
        [Inject(Id = "opponent")]
        private Player opponent;

        private void Start()
        {
            transform.DOKill();
        }

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
            Camera.main.DOShakePosition(0.1f, 1);
            // Delay invoke
            Observable
                .Timer(System.TimeSpan.FromSeconds(this.delay))
                .Subscribe(_ =>
                {
                    // Reset children
                    foreach (var child in this.children)
                    {
                        child.hit.Value = false;
                    }
                })
                .AddTo(this);
        }
    }
}

