using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Skill : ScriptableObject
{
    [field: SerializeField]
    public string skillName { get; private set; }
    [field: SerializeField]
    public Sprite sprite { get; private set; }

    public abstract void Trigger(Player target);
}
