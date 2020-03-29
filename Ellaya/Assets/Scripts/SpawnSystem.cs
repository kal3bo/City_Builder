using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [HideInInspector] public List<Vector3> buildingPositions = new List<Vector3>();
    public GameObject[] characters;


    private void Update()
    {
        // Check if I have at least 2 buildings:
        if (buildingPositions.Count > 1)
        {
            GameObject newCharacter = characters[Random.Range(0, characters.Length)];
            Instantiate(newCharacter, buildingPositions[Random.Range(0, buildingPositions.Count)], Quaternion.identity);
            newCharacter.GetComponent<AINavigation>().SetNewTarget(buildingPositions[Random.Range(0, buildingPositions.Count)]);
        }
    }
}