using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public Transform cam;

    public float turnSmoothVelocity; 
    public float turnSmoothTime = 0.1f; 
    public float speed = 6f; 

    void Start() 
    
    {
        
    }


    void Update()
    {

        //Movement code for Forwards, Backwards and Side to Side. As well as Player Facing directions
        //and moving in the direction carmea is looking 

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);        
        
        }

    }


}
