using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public BuildableObject[] buildables;
    public Camera mainCamera;
    public LayerMask buildableAreaMask;

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
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity, buildableAreaMask);

                if (hit.collider != null)
                {
                    BuildableObject buildable = buildables[selectionIndex];
                    Instantiate(buildable.prefab, hit.point + buildable.offset, Quaternion.identity);
                }
            }
        }
    }
}
