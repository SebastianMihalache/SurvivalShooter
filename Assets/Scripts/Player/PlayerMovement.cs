using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody rb;
    private int floorMask;
    private float camRayLenght = 100;

    private void Awake()
    {
        // set the components to the variables
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //get input from the WASD keys
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // calling the functions
        Move(h, v);
        Turning ();
        Animating(h, v);
    }

    // function for movement that gets the input from the h and v variables from the keys
    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    //function for turning that uses the mouse position as the input and turns the player to face the mosue
    private void Turning()
    {
        //new variable that stores the mouse position
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //variable that only allows the mouse to be on the floor for the input to take place
        RaycastHit floorHit;

        //if statement with new function that makes the player turn
        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            //make the turning only in 2 directions and not go up and down
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    //funtion for setting true and false to IsWalking condition for animation
    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);

    }
}
