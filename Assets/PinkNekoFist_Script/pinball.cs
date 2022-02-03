using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ltabble;
    public GameObject Rtabble;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "voidL"){
            transform.position = Rtabble.transform.position;
            rb.velocity = new Vector2(-1,0);
        }
        if(other.gameObject.name == "voidR"){
            transform.position = Ltabble.transform.position;
            rb.velocity = new Vector2(-1,0);

        }
    }
}
