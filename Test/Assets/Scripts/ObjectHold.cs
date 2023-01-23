using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public static GameObject Object;
    public static Transform PlayerTransform;
    public float range = 3f;
    public float Go = 100f;
    public Camera Camera;
    public static bool held = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            StartPickUp();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Drop();
        }
    }

    void StartPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        held = true;
        Target.Example();
    }

    void Drop()
    {
        held = false;
        Target.Example();   
    }

}