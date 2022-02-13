using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class SkillHolder : MonoBehaviour
{
    [Inject(Id = "me")]
    private Player me;
    private new SpriteRenderer renderer;

    public Skill skill { get; private set; }

    public void SetSkill(Skill toHold)
    {
        this.skill = toHold;
        this.renderer = GetComponent<SpriteRenderer>();
        this.renderer.sprite = this.skill.sprite;
    }

    // TODO: Add feedback
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            this.me.AddSkill(this.skill);
            this.skill = null;
            gameObject.SetActive(false);
        }
    }
}
