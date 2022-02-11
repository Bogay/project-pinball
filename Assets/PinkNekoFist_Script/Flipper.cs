using UnityEngine;

public class Flipper : MonoBehaviour
{
    public KeyCode triggerKey;
    [SerializeField]
    private float initialAngle;
    [SerializeField]
    private float finalAngle;
    [SerializeField]
    private float speed;

    private HingeJoint2D joint2D;

    private void Start()
    {
        this.joint2D = GetComponent<HingeJoint2D>();
    }

    private void FixedUpdate()
    {
        var motor = this.joint2D.motor;
        var speed = Input.GetKey(this.triggerKey) ? this.speed : -this.speed;
        motor.motorSpeed = speed;
        this.joint2D.motor = motor;
    }
}
