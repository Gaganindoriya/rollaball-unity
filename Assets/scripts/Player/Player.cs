using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float jump = 8;
    private bool isFalling = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
        //inputs from keyboard

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        //adding force to ball

        Vector3 move = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(move * speed);
      
        //for adding jump behaviour
        if (Input.GetKeyDown(KeyCode.Space) && isFalling==false)
        {
            Debug.Log("space pressed");
            
            rb.velocity = new Vector3(0.0f,jump,0.0f);
           
        }
        isFalling = true;
         

	}

    //this will call when the player is on the ground
    void OnCollisionStay()
    {
        Debug.Log("on the ground");
        isFalling = false;
    }


    //for collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
           // count = count + 1;
            //  setCountText();
        }
        if (other.gameObject.CompareTag("finalpickup"))
        {
            other.gameObject.SetActive(false);
            // count = count + 1;
            //  setCountText();
        }
    }

}
