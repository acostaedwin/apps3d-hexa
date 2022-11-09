using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int carril;

    public int lateral;

    public int posicionZ;

    private int limitX = 15;

    private float velocidad = 10f;

    public Vector3 posObjetivo;

    private Rigidbody Physics;

    private float jumpForce = 10f;

    public Transform grafico;

    /*public AudioSource audioData;
    public Vector3 jump;
    Rigidbody rb;*/
    void Start()
    {
        Physics = GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();
        // jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private Vector3 fp; //First touch position

    private Vector3 lp; //Last touch position

    private float dragDistance; //minimum distance for a swipe to be registered

    // Update is called once per frame
    void Update()
    {
        ActualizarPos();

        if (
            Input.touchCount == 1 // user is touching the screen with a single touch
        )
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (
                touch.phase == TouchPhase.Began //check for the first touch
            )
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (
                touch.phase == TouchPhase.Moved // update the last position based on where they moved
            )
            {
                lp = touch.position;
            }
            else if (
                touch.phase == TouchPhase.Ended //check if the finger is removed from the screen
            )
            {
                lp = touch.position; //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (
                    Mathf.Abs(lp.x - fp.x) > dragDistance ||
                    Mathf.Abs(lp.y - fp.y) > dragDistance
                )
                {
                    //It's a drag
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        //If the horizontal movement is greater than the vertical movement...
                        if (
                            (lp.x > fp.x) //If the movement was to the right)
                        )
                        {
                            //Right swipe
                            Debug.Log("Right Swipe");
                            MoverLados(1);
                        }
                        else
                        {
                            //Left swipe
                            Debug.Log("Left Swipe");
                            MoverLados(-1);
                        }
                    }
                    else
                    {
                        //the vertical movement is greater than the horizontal movement
                        if (
                            lp.y > fp.y //If the movement was up
                        )
                        {
                            //Up swipe
                            Debug.Log("Up Swipe");
                            Avanzar();
                        }
                        else
                        {
                            //Down swipe
                            Debug.Log("Down Swipe");
                            Retroceder();
                        }
                    }
                }
                else
                {
                    //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }

        /*
        if (Input.touchCount > 0)
        {
            Debug.Log("touchCount");
            Avanzar();
        }*/
        if (Input.GetKeyDown(KeyCode.W))
        {
            Avanzar();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Retroceder();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoverLados(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoverLados(-1);
        }
    }

    public void ActualizarPos()
    {
        posObjetivo = new Vector3(lateral, 0, posicionZ);
        transform.position =
            Vector3
                .Lerp(transform.position,
                posObjetivo,
                velocidad * Time.deltaTime);
    }

    public void Avanzar()
    {
        grafico.eulerAngles = Vector3.zero;

        //audioData.Play(0);
        posicionZ++;
        if (posicionZ > carril)
        {
            Physics.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            carril = posicionZ;
        }
    }

    public void Retroceder()
    {
        grafico.eulerAngles = new Vector3(0, 180, 0);

        //audioData.Play(0);
        if (posicionZ > carril - 4)
        {
            posicionZ--;
        }
    }

    public void MoverLados(int cuanto)
    {
        grafico.eulerAngles = new Vector3(0, 90 * cuanto, 0);

        //audioData.Play(0);
        lateral += cuanto;
        lateral = Mathf.Clamp(lateral, -limitX, limitX);
    }
}
