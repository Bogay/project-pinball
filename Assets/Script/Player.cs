using UnityEngine;
using UniRx;

// Player runtime instance
public class Player : MonoBehaviour
{
    public PlayerState state { get; private set; }
    public ReactiveProperty<int> hp { get; private set; }
    public ReactiveProperty<Skill> skill { get; private set; }

    // TODO: Move this to a better place...
    private void Start()
    {
        SceneAudioManager.instance.PlayByName("bgm");
    }

    // Set player state and initliaze runtime state
    public void SetState(PlayerState state)
    {
        this.state = state;
        this.hp = new ReactiveProperty<int>(this.state.maxHP);
        this.skill = new ReactiveProperty<Skill>();
    }

    private void useSkill()
    {
        if (this.skill.Value == null) return;
        this.skill.Value.Trigger(this);
        this.skill.Value = null;
    }

    public void AddSkill(Skill got)
    {
        Debug.Log($"Got skill: {got.skillName}");
        this.skill.Value = got;
    }

    private void Update()
    {
        if (this.state && Input.GetKeyDown(this.state.trigger))
        {
            this.useSkill();
        }
    }
}
