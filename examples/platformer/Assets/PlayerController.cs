using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // These are the variables that will scale the effect of the movement, gravity,
    // and rotation code in update.
    float rotateSpeed = 90f;
    float forwardSpeed = 8f;
    float defaultSpeed = 8f;
    float waterSpeed = 3f;
    float jumpForce = 10f;
    float gravity = -19.8f;

    public GameObject cam;

    // This is the variable we will use to accumulate gravity.
    float yVelocity = 0;
    
    GameObject movingPlatform;
    Vector3 previousPlatformPosition;

    public CharacterController cc;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        // *** Move relative to camera ***
        //Vector3 camVecForward = cam.transform.forward;
        //camVecForward.y = 0;
        //camVecForward.Normalize();

        //Vector3 camVecRight = cam.transform.right;
        //camVecRight.y = 0;
        //camVecRight.Normalize();

        //camVecRight *= hAxis;
        //camVecForward *= vAxis;

        //camVecForward += camVecRight;
        //Vector3 camVecTotal = camVecForward.normalized;

        //camVecTotal *= forwardSpeed;

        // Rotate in the direction we are facing (again, based on the input and camera)
        //if (camVecForward.magnitude > 0)
        //{
        //    transform.rotation = Quaternion.LookRotation(camVecTotal);
        //}
        // *** END Move relative to camera ***

        // --- ROTATION ---
        // Rotate on the y axis based on the hAxis value
        // NOTE: If the player isn't pressing left or right, hAxis will be 0 and there will be no rotation
        Vector3 amountToRotate = new Vector3(0, 0, 0);
        amountToRotate.y = hAxis * rotateSpeed * Time.deltaTime;
        transform.Rotate(amountToRotate, Space.Self);

        if (cc.isGrounded == false) {
            // If we go in this block of code, cc.isGrounded is false, which means
            // the last time cc.Move was called, we did not try to enter the ground.

            if (Input.GetKey(KeyCode.Space) && yVelocity < 0)
            {
                yVelocity += gravity/5 * Time.deltaTime;
            }
            else
            {
                yVelocity += gravity * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0) {
                yVelocity = 0;
            }
        }
        else
        {
            // If we are in this block of code, we are on the ground.
            // Set the yVelocity to be some small number to try to push us into
            // the ground and thus make cc.isGrounded be true.
            yVelocity = -2;

            // JUMP. When the player presses space, set yVelocity to the jump force. This will immediately
            // make the player start moving upwards, and gravity will start slowing the movement upward
            // and eventually make the player hit the ground (thus landing in the 'if' statment above)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }

        // --- MOVEMENT ---
        // Move the player forward based on the vAxis value
        // Note, If the player isn't pressing up or down, vAxis will be 0 and there will be no movement
        // based on input. However, yVelocity will still move the player downward.
        Vector3 amountToMove = transform.forward * forwardSpeed * vAxis;
        //Vector3 amountToMove = camVecTotal; //Use this if moving relative to the camera

        // -- ANIMATION --
        // Check to see if we are going to move based on the player input. Note, we
        // check this here rather than after we set yVelocity because we are always
        // moving downward (see notes above).
        if (amountToMove.magnitude > 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        // Overwrite the y value with our yVelocity variable we use to accumulate gravity, etc.
        amountToMove.y = yVelocity;
        // Scale all of that by deltaTime.
        amountToMove *= Time.deltaTime;

        // If we are attached to a platform, move the amount that the platform moved.
        // See the Trigger functions below. This is where we set movingPlatform if we collide with one
        if (movingPlatform != null)
        {
            Vector3 distancePlatformMoved = movingPlatform.transform.position - previousPlatformPosition;
            amountToMove += distancePlatformMoved;
            previousPlatformPosition = movingPlatform.transform.position;
        }

        cc.Move(amountToMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("moving_platform"))
        {
            previousPlatformPosition = other.transform.parent.position;
            movingPlatform = other.transform.parent.gameObject;
        }
        else if (other.CompareTag("water"))
        {
            forwardSpeed = waterSpeed;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("moving_platform"))
        {
            // By setting this to null here, we won't go into the if statement
            // that deals with moving platforms in the Update function.
            movingPlatform = null;
        }
        else if (other.CompareTag("water"))
        {
            forwardSpeed = defaultSpeed;
        }
    }
}


