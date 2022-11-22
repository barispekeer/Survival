using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolsticeContol : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(new Vector3(500f, 0, 500f), -Vector3.right, 2f * Time.deltaTime);
    }
}
