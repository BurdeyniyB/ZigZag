using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCudeAuto : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
           Destroy(this.gameObject);
        }
    }
}
