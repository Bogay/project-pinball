using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaa : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotaSpeed; 
    private Rigidbody2D rb;
    public bool RT;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {      
        if(Input.GetKeyDown(KeyCode.X)){
            RT = true;
        }
        if(Input.GetKeyUp(KeyCode.X)){
            RT = false;
        }

        if(RT == true&& rb.rotation >= 150){
            rb.angularVelocity = -360*RotaSpeed;
        }
        else if(RT == false&& rb.rotation <= 210){
            rb.angularVelocity = 360*RotaSpeed;
        }
        else{
            rb.angularVelocity = 0;
        }
        
    }
}
