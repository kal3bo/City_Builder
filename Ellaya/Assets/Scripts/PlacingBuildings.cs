using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingBuildings : MonoBehaviour
{
    public GameObject prefab;
    public Camera mainCamera;
    public Vector3 offset;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {
            if(hit.collider != null)
            {
                Vector3 position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
                GameObject building = prefab;
                Instantiate(building, position + offset, Quaternion.identity);
            }
        }
    }
}