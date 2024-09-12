

using UnityEngine;
using UnityEngine.InputSystem;


public class StickManager : MonoBehaviour
{
    InputActions inputActions;
    float xPosition { get; set; }
    bool isLeftPressed;
    bool isRightPressed;
    public int shootPower;
 
    bool isTurning;
    int rotationSpeed = 80;
    //Vector2 touchPos;
    //Touchscreen touchscreen; for mobile

    private void Awake()
    {
        inputActions = new InputActions();

        //input class yöntemi 
        inputActions.GameControl.TurnRight.performed += ctx => isRightPressed = ctx.ReadValueAsButton();
        inputActions.GameControl.TurnRight.canceled += ctx => isRightPressed = ctx.ReadValueAsButton();


        inputActions.GameControl.TurnLeft.performed += ctx => isLeftPressed = ctx.ReadValueAsButton();
        inputActions.GameControl.TurnLeft.canceled += ctx => isLeftPressed = ctx.ReadValueAsButton();

        //touchScreen = Touchscreen.current;
        //touchPos = touchscreen.primaryTouch.position.value; for mobile
        // TODO(talatuccar) mobile input for mobile build;

        // Using Methods
        //inputActions.GameControl.TurnRight.performed += _ => RightSettings();
        //inputActions.GameControl.TurnRight.canceled += _ => RightSettings();

        //inputActions.GameControl.TurnLeft.performed += x => LeftSettings();
        //inputActions.GameControl.TurnLeft.canceled += x => LeftSettings();


    }

    // Using Methods
    //public void RightSettings()
    //{

    //    transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -rotationSpeed * Time.deltaTime)); 
    //}
    //public void LeftSettings()
    //{
    //    transform.rotation *= Quaternion.Euler(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    //}





    void Update()
    {

        if (isLeftPressed)
        {          
                transform.rotation *= Quaternion.Euler(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
               //print(touchscreen.primaryTouch.position.value);
            

        }


        if (isRightPressed)
        {         
                transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
                 //print(touchscreen.primaryTouch.position.value);
                 // alternative way to rotate it
                 //transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));

        }



    }

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 poz = collision.GetContact(0).point;
        if (gameObject.transform.position.y > poz.y)
        {

            collision.gameObject.GetComponent<Rigidbody>().AddForce(poz * shootPower);

        }

        return;

    }

    private void OnEnable()
    {
        inputActions.GameControl.Enable();

    }

    private void OnDisable()
    {
        inputActions.GameControl.Disable();

    }

}
