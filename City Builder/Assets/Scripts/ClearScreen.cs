using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    /// <summary>
    /// Find all the objects and destroy them.
    /// </summary>
    public void DestroyAllBuildings()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        for (int i = 0; i < buildings.Length; i++)
        {
            Destroy(buildings[i]);
        }

        for (int i = 0; i < characters.Length; i++)
        {
            Destroy(characters[i]);
        }
    }
}
