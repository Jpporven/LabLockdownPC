using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private RaycastHit vision;
    // this private variable would have RaycastHit vision be able to detect the object that the gun is pointing at.

    public float rayLength;
    // this float RayLength would be used to set the length of the ray that the gun is pointing at.

    private bool isGrabbed;
    // this bool isGrabbed would be used to check if the object is grabbed or not.

    //public float power = 500.0f;
    private Rigidbody grabbeddObject;
    // this private Rigidbody grabbedObject would be used to get the rigidbody of the object that the gun is pointing at.
    private Rigidbody rb;
    // this private Rigidbody rb would be used to get the rigidbody with the gradbbeddObject.
    public Text ObjectName;
    // this public Text ObjectName would be used to set the name of the object that the gun is pointing at.

    void Start()
    {
        rayLength = 4.0f;
        isGrabbed = false;
    }
    /*
     this Start method would be used to set the rayLength to 4.0f where the raycast would be used to detect the object that is pointing at.
        and then it would be used to set the isGrabbed to false where the object is not grabbed.
    */


    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);
        // this Debug.DrawRay would be used to have the Camera.main.transform.position and Camera.main.transform.forward * rayLength to draw the ray that the gun is pointing at.
        // And have the color red and 0.5f to set the duration of the ray.

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength))
        {
            // this if statement would start with the Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength) 
            // Where the ray would be used to detect the object that the gun is pointing at and have a out vision to set the rayLength.
            if(vision.collider.tag == "Interactive")
            {
                // this if statement would be used to check if the vision.collider.tag is equal to "Interactive"
                Debug.Log (vision.collider.name);
                // this Debug.Log would be used to log the name of the object that the gun is pointing at.

                // this if statement would be used to check if the Input.GetMouseButtonDown(1) is pressed and the object is not grabbed
                if(Input.GetMouseButtonDown(1) && !isGrabbed)
                {
                    grabbeddObject = vision.rigidbody;
                    // this grabbeddObject would be used to get the rigidbody of the object that the gun is pointing at.
                    grabbeddObject.isKinematic = true;
                    // this grabbeddObject.isKinematic would be used to set the object to be kinematic.
                    grabbeddObject.transform.SetParent (gameObject.transform);
                    // this grabbeddObject.transform.SetParent would be used to set the object to be the parent of the gun.
                    ObjectName.text = "Object Name: " + grabbeddObject.name;
                    // this ObjectName.text would be used to set the name of the object that the gun is pointing at.
                    //grabbeddObject.GetComponent<Renderer>().material.color = Color.red;
                    isGrabbed = true;
                    // this isGrabbed would be used to set the object to be grabbed.
                }
                else if(isGrabbed && Input.GetMouseButtonDown(1))
                {
                    // this else if statement would be used to check if the object is grabbed and the Input.GetMouseButtonDown(1) is pressed
                    grabbeddObject.isKinematic = false;
                    // this grabbeddObject.isKinematic would be used to set the object to be kinematic.
                    grabbeddObject.transform.parent = null;
                    // this grabbeddObject.transform.parent would be used to set the object to be the parent of the gun.
                    ObjectName.text = "Object Name: ";
                    // this ObjectName.text would be used to set the name of the object, when the object is grabbed but would be set to null when the object is not grabbed.
                    //grabbeddObject.GetComponent<Renderer>().material.color = Color.blue;
                    isGrabbed = false;
                    // this isGrabbed would be used to set the object to be grabbed.
                    
                }
            }
        }
        /*
         the if statement would be used to detect the object that the gun is pointing at
         and then it would be used to detect the target and then it would be used to take damage.
        */
    }
}
