using UnityEngine;

[CreateAssetMenu(fileName = "new TestSkill", menuName = "Player/Skill/Test")]
public class TestSkill : Skill
{
    public override void Trigger(Player target)
    {
        Debug.Log("I am triggered.");
    }
}
