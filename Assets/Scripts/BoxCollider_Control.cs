using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider_Control : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacles")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacles")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
