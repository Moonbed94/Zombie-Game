using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    int VelocityHash;

    Animator animator; 

    float velocity = 0.0f;
    float acceleration = 0.1f;
    float deceleration = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        VelocityHash = Animator.StringToHash("Velocity"); 
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKeyDown(KeyCode.W);
        bool runPressed = Input.GetKeyDown(KeyCode.LeftShift);

        if (forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        animator.SetFloat(VelocityHash, velocity);
        
    }
}
