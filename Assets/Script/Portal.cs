using UnityEngine;
using Zenject;

public class Portal : MonoBehaviour
{
    [Inject(Id = "opponent")]
    private Player opponent;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.transform.position = this.opponent.transform.position;
            var rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            rb2d.velocity = (rb2d.velocity.normalized + Vector2.right * Random.Range(-10, 10)).normalized;
        }
    }
}
