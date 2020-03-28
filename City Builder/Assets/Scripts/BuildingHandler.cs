using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    // List of possible buildings in game and 
    // an index to manage them on the UI:
    public BuildableObject[] buildables;
    private int selectionIndex;

    // Raycast variables. The screen sends a ray that can
    // only collide with an specific layer on game.
    public Camera mainCamera;
    public LayerMask buildableAreaMask;

    // Before placing a building, the user can see the
    // preview of how it would look with a transparent
    // material called "ghost".
    private GameObject ghost;
    public Material ghostMaterial;

    /// <summary>
    /// External script that stores all the building positions
    /// to be targets for the characters in game.
    /// </summary>
    private GameObject spawnHandler;
    private void Awake()
    {
        spawnHandler = GameObject.FindWithTag("SpawnHandler");
    }

    /// <summary>
    /// Select & Deselect:
    /// Simple constructor to change the building prefab
    /// or deselect it if the user doesn't want to place any 
    /// more buildings
    /// </summary>
    public void Select(int index)
    {
        if (index >= 0 || index < buildables.Length)
            selectionIndex = index;
    }

    public void Deselect()
    {
        selectionIndex = -1;
    }

    /// <summary>
    /// 
    /// </summary>
    public Vector3 hitPosition;
    void Update()
    {
        #region Placing buildings.
        // Checking if the user has a building selected
        if (selectionIndex >= 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, buildableAreaMask);

            // Grid System:
            hitPosition = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));

            // Checking if the raycast is colliding:
            if (hit.collider != null)
            {
                BuildableObject buildable = buildables[selectionIndex];
                
                // Creating the building with transparent material for preview:
                if (ghost == null)
                {
                    ghost = Instantiate(buildable.prefab, hitPosition + buildable.offset, Quaternion.identity);
                    ghost.GetComponent<Renderer>().material = ghostMaterial;
                }
                else
                {
                    ghost.transform.position = hitPosition + buildable.offset;
                }
            }

            // When the user clicks the left mouse button:
            if (Input.GetMouseButtonDown(0))
            {
                // Placing the building if the user clicks over the building area:
                if (hit.collider != null)
                {
                    BuildableObject buildable = buildables[selectionIndex];
                    Instantiate(buildable.prefab, hitPosition + buildable.offset, Quaternion.identity);
                    // Storing the position in the Spawn Handler:
                    spawnHandler.GetComponent<SpawnPeople>().SetNewPosition(hitPosition);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Update the selected building preview if the user selects a 
    /// different building on the UI.
    /// </summary>
    public void UpdateGhost(int newIndex)
    {
        Destroy(ghost);
        selectionIndex = newIndex;
        ghost = Instantiate(buildables[selectionIndex].prefab, hitPosition + buildables[selectionIndex].offset, Quaternion.identity);
        ghost.GetComponent<Renderer>().material = ghostMaterial;
    }
}