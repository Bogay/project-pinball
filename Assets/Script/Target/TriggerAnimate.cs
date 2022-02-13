using UnityEngine;
using UniRx;

public class TriggerAnimate : MonoBehaviour
{
    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite triggered;

    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        GetComponent<Pinball.Target.Standup>().triggered
            .Subscribe(t => renderer.sprite = t ? this.triggered : this.normal)
            .AddTo(this);
    }
}
