using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public BuildableObject[] buildables;
    public Camera mainCamera;
    public LayerMask buildableAreaMask;

    private GameObject ghost;
    public Material ghostMaterial;

    [SerializeField]
    private int selectionIndex;

    public void Select(int index)
    {
        if(index >= 0 || index < buildables.Length)
        {
            selectionIndex = index;
        }
    }

    public void Deselect()
    {
        selectionIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectionIndex >= 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, buildableAreaMask);

            // Grid System:
            Vector3 position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));

            if (hit.collider != null)
            {
                BuildableObject buildable = buildables[selectionIndex];
                if (ghost == null)
                {
                    ghost = Instantiate(buildable.prefab, position + buildable.offset, Quaternion.identity);
                    ghost.GetComponent<Renderer>().material = ghostMaterial;
                }
                else
                {
                    ghost.transform.position = position + buildable.offset;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    BuildableObject buildable = buildables[selectionIndex];
                    Instantiate(buildable.prefab, position + buildable.offset, Quaternion.identity);
                }
            }
        }
    }
}
