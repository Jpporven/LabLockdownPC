using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineOfSight : MonoBehaviour
{
    private RaycastHit vision;
    public float rayLength;
    private bool isGrabbed;

    public float power = 500.0f;
    private Rigidbody grabbeddObject;
    private Rigidbody rb;

    void Start()
    {
        rayLength = 4.0f;
        isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength))
        {
            if(vision.collider.tag == "Interactive")
            {
                Debug.Log (vision.collider.name);

                if(Input.GetKeyDown(KeyCode.E) && !isGrabbed)
                {
                    grabbeddObject = vision.rigidbody;
                    grabbeddObject.isKinematic = true;
                    grabbeddObject.transform.SetParent (gameObject.transform);
                    isGrabbed = true;
                    //LoadScene();
                }
                else if(isGrabbed && Input.GetKeyDown(KeyCode.E))
                {
                    grabbeddObject.isKinematic = false;
                    grabbeddObject.transform.parent = null;
                    isGrabbed = false;
                }
                /*
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Destroy(vision.collider.gameObject);
                    grabbeddObject.isKinematic = false;
                    grabbeddObject.transform.parent = null;
                    isGrabbed = false;
                }*/

                //Use a raycast to display the distance between the object and the character
                //controller in the console.

                Debug.Log (Vector3.Distance (vision.collider.transform.position, transform.position));

                //Use the raycast to allow the user to press a button on the keyboard that will
                //project the object away from the user.

                /*if (Input.GetKeyDown(KeyCode.F))
                {
                    rb = vision.collider.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * power);
                }*/
            }
        }
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene("Side-Room");
    }*/
}
