using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pinball.Target
{
    public class Standup : MonoBehaviour
    {
        [Inject(Id = "opponent")]
        private Player opponent;
        [SerializeField]
        private int damage = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                this.opponent.hp.Value -= this.damage;
            }
        }
    }
}
