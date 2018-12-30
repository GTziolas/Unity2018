using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public float mainSpeed = 10.0f;   // Regular speed
    public float shiftAdd = 25.0f;   // Amount to accelerate when shift is pressed
    public float maxShift = 100.0f;  // Maximum speed when holding shift
    public float camSens = 0.15f;   // Mouse sensitivity

    private Vector3 lastMouse = new Vector3(255, 255, 255);  // kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Move forward
        if (Input.GetKeyDown(moveForward))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, 100);
        }
        if (Input.GetKeyUp(moveForward))
        {
            stopMovingVelocity();
        }

        // Move backward
        if (Input.GetKeyDown(moveBackward))
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100);
        }
        if (Input.GetKeyUp(moveBackward))
        {
            stopMovingVelocity();
        }

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        // Mouse camera angle done.  

        // Keyboard commands
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p *= totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p *= mainSpeed;
        }

        p *= Time.deltaTime;
        transform.Translate(p);
    }


    void stopMovingVelocity()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    void stopMovingAngularVelocity()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();

        // Forwards
        if (Input.GetKey(KeyCode.W))
            p_Velocity += new Vector3(0, 0, 1);
        if (Input.GetKeyUp(moveForward))
        {
            stopMovingVelocity();
        }

        // Backwards
        if (Input.GetKey(KeyCode.S))
            p_Velocity += new Vector3(0, 0, -1);
        if (Input.GetKeyUp(moveBackward))
        {
            stopMovingVelocity();
        }

        // Left
        if (Input.GetKey(KeyCode.A))
            p_Velocity += new Vector3(-1, 0, 0);
        if (Input.GetKeyUp(KeyCode.A))
        {
            stopMovingVelocity();
        }

        // Right
        if (Input.GetKey(KeyCode.D))
            p_Velocity += new Vector3(1, 0, 0);
        if (Input.GetKeyUp(KeyCode.D))
        {
            stopMovingVelocity();
        }

        // Up
        if (Input.GetKey(KeyCode.Space))
            p_Velocity += new Vector3(0, 1, 0);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stopMovingVelocity();
        }
        // Down
        if (Input.GetKey(KeyCode.LeftControl))
            p_Velocity += new Vector3(0, -1, 0);
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            stopMovingVelocity();
        }
        return p_Velocity;
    }
}


//Strafe Left
// if (Input.GetKeyDown(strafeLeft))
// {
//     GetComponent<Rigidbody>().AddRelativeForce(-100, 0, 0);
// }
// if (Input.GetKeyUp(strafeLeft))
// {
//     stopMoving();
// }


//Strafe Right
// if (Input.GetKeyDown(strafeRight))
// {
//     GetComponent<Rigidbody>().AddRelativeForce(100, 0, 0);
// }
// if (Input.GetKeyUp(strafeRight))
// {
//     stopMoving();
// }

// void stopMoving()
//{
//    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
// }