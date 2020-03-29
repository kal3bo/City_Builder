using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour
{
    public GameObject[] characters;
    private float time = 0.0f;

    [HideInInspector] public List<Vector3> buildingPositions = new List<Vector3>();

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.01f)
        {
            time = 0;

            // If there are at least 2 buildings in game, we can spawn characters:
            if (buildingPositions.Count > 1)
            {
                // Each period of time there is a 50% chance to spawn a character:
                if (Random.Range(1, 3) == 1)
                {
                    // Spawning a random character from the library if there are:
                    if (characters.Length > 0)
                    {
                        int indexOfSpawn = Random.Range(0, buildingPositions.Count);
                        int indexOfTarget = Random.Range(0, buildingPositions.Count);
                        // Probability of how many characters are spawning:
                        int numberOfCharacters = Random.Range(1, 5);
                        for (int i = 0; i < numberOfCharacters; i++)
                        {
                            if (indexOfSpawn != indexOfTarget)
                            {
                                GameObject newCharacter = characters[Random.Range(0, characters.Length)];
                                Instantiate(newCharacter, buildingPositions[indexOfSpawn], Quaternion.identity);
                                newCharacter.GetComponent<AINavigation>().SetTargetPosition(buildingPositions[indexOfTarget]);
                            }
                            else
                            {
                                return;
                            }
                        }
                        
                    }
                }
            }
        }
    }

    public void SetNewPosition(Vector3 newPosition)
    {
        buildingPositions.Add(newPosition);
    }

    public void Clear()
    {
        buildingPositions.Clear();
    }
}
