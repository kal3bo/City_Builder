using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    public void DestroyAllBuildings()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        for (int i = 0; i < buildings.Length; i++)
        {
            Destroy(buildings[i]);
        }
    }
}
