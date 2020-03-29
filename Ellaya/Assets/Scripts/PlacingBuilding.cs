using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingBuilding : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 offset;
    private int indexForBuilding = -1;

    private GameObject spawnHandler;

    private void Awake()
    {
        spawnHandler = GameObject.FindWithTag("SpawnHandler");
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        
        // Check if the user clicks:
        if (Input.GetMouseButtonDown(0))
        {
            // Checks if the ray collides with something:
            if (hit.collider != null)
            {
                // Checks if the user has a building selected:
                if (indexForBuilding >= 0)
                {
                    GameObject building = prefabs[indexForBuilding];
                    Vector3 position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
                    Instantiate(building, position + offset, Quaternion.identity);
                    spawnHandler.GetComponent<SpawnSystem>().buildingPositions.Add(position);
                }
            }
        }
    }

    public void SetIndexForBuilding(int indexForBuilding)
    {
        this.indexForBuilding = indexForBuilding;
    }
}
