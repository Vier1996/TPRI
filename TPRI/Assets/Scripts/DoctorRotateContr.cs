using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorRotateContr : MonoBehaviour
{
    private void OnMouseDrag()
    {
        if (transform.position.x > Input.mousePosition.x)
        {
            transform.Rotate(0, 0, 180*Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -180*Time.deltaTime);
        }
    }
}
