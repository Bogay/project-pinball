using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class SkillGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Skill> skills;
    [Inject]
    private List<SkillHolder> holders;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.generateSkill());
    }

    private IEnumerator generateSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (Random.Range(0f, 1f) > 0.5f) continue;
            int offset = Random.Range(0, this.holders.Count);
            for (int i = 0; i < this.holders.Count; i++)
            {
                var holder = this.holders[(i + offset) % this.holders.Count];
                if (holder.skill == null)
                {
                    // If the ball is too close to the holder
                    var collisions = Physics2D.CircleCastAll(holder.transform.position, 3, Vector2.one, 0);
                    if (collisions.Any(c => c.collider.CompareTag("Ball"))) continue;
                    // Choose a skill to generate
                    var newSkill = ScriptableObject.Instantiate(this.skills[Random.Range(0, this.skills.Count)]);
                    holder.SetSkill(newSkill);
                    holder.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
