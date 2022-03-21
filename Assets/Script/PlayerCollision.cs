using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
    }

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay");
    }

    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
    }
}
