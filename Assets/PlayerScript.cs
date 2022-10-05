using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 moving;          //プレイヤーの向き
    Rigidbody rb;               
    public float Speed=90.0f;
    public float Grabity=9.0f;
    public float jumpPower=10.0f;
    bool jumpNow;
    float x,y,z;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの重力コンポーネントを取得し、倒れないように回転を制御
       rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControll();
         rb.velocity=moving;
       
    }

    void FixedUpdate()
    {
         MoveDir();
         JumpGrabity();
    }

    void MoveControll()
    {
       x=Input.GetAxisRaw("Horizontal");
       z=Input.GetAxisRaw("Vertical");
       moving=new Vector3(x*Time.deltaTime,0,z*Time.deltaTime);
       moving.Normalize();
       moving=moving*Speed;
    }

    public void MoveDir()
    {
            if(Mathf.Abs(moving.x)>0.001f)
            {
            Quaternion rotX = Quaternion.AngleAxis(moving.x,Vector3.up);
            rotX = Quaternion.Slerp(rb.transform.rotation, rotX, 0.1f);
            this.transform.rotation = rotX;
            }
            else if(Mathf.Abs(moving.z)>0.001f)    
            {
            Quaternion rotZ = Quaternion.AngleAxis(moving.z-90,Vector3.up);
            rotZ = Quaternion.Slerp(rb.transform.rotation, rotZ, 0.2f);
            this.transform.rotation = rotZ;
            }
    }

    void JumpControll(Collision other)
    {
        if(other.gameObject.CompareTag("Stage"))
        {
            jumpNow=false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
		    rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
		    jumpNow = true;
        }
    }

    void JumpGrabity()
    {
        if(jumpNow)
        {
            rb.AddForce(new Vector3(0,Grabity,0));
        }
    }
}
