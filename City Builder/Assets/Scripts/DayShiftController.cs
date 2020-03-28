using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayShiftController : MonoBehaviour
{
    [SerializeField] private float daySpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, daySpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
