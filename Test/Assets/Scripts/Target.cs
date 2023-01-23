using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static GameObject child;
    public Transform parent;
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public static void Example()
    {
        if (ObjectHold.held)
        {
            child.transform.SetParent(ObjectHold.PlayerTransform);
            Debug.Log("HELP");
        }
        else
        {
            child.transform.SetParent(null);
        }
    }
}