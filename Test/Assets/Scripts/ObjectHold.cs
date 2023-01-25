using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public float Go = 100f;
    public Camera Camera;
    public static bool held = false;
    GameObject theHitObject = null;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartPickUp();
        }

        if (Input.GetKey(KeyCode.Q) && held == true)
        {
            Drop();
        }
    }

    void StartPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Throwing")
            {
                Debug.Log(hit.transform.name);
                theHitObject = hit.collider.gameObject;
                PickUp();
            }
        }
    }

    void PickUp()
    {
        held = true;
        theHitObject.transform.parent = PlayerTransform.transform;
        theHitObject.transform.position += Vector3.up * 2;
        ThrowingTutorial.objectToThrow = theHitObject;
        ThrowingTutorial.totalThrows += 1;
        ThrowingTutorial.projectileRb.isKinematic = true;



    }

    void Drop()
    {
        held = false;
        theHitObject.transform.parent = null;
        ThrowingTutorial.totalThrows -= 1;
        ThrowingTutorial.projectileRb.isKinematic = false;


    }

}