using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rota : MonoBehaviour
{
    // Start is called before the first frame updat
    public float RotaSpeed; 
    private Rigidbody2D rb;
    public bool RT;
    public static bool trigger;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger == false)
        {
            if(Input.GetKeyDown(KeyCode.Z)){
                RT = true;
            }
            if(Input.GetKeyUp(KeyCode.Z)){
                RT = false;
            }
            if(RT == true&&rb.rotation <= 30){
                rb.angularVelocity = 360*RotaSpeed;
            }
            else if(RT == false&&rb.rotation >= -15){
                rb.angularVelocity = -360*RotaSpeed;
            }
            else{
                rb.angularVelocity = 0;
            }
        }

        if (trigger == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                RT = true;
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                RT = false;
            }
            if (RT == true && rb.rotation <= 30)
            {
                rb.angularVelocity = 360 * RotaSpeed;
            }
            else if (RT == false && rb.rotation >= -15)
            {
                rb.angularVelocity = -360 * RotaSpeed;
            }
            else
            {
                rb.angularVelocity = 0;
            }
        }
    }
}
