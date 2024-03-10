using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figurine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fig")
        {
            other.gameObject.transform.position = this.transform.position;
        }
    }
}
