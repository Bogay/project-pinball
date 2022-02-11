using UniRx;
using UnityEngine;


[CreateAssetMenu(fileName = "new PlayerState", menuName = "Player/State")]
public class PlayerState : ScriptableObject
{
    [field: SerializeField]
    public int maxHP { get; private set; }
    [field: SerializeField]
    public KeyCode left { get; private set; }
    [field: SerializeField]
    public KeyCode right { get; private set; }
}
