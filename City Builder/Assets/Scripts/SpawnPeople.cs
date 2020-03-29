using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour
{
    // List of characters to provide more in the future:
    public GameObject[] characters;

    // List of the position of all buildings to spawn characters there.
    [HideInInspector] public List<Vector3> buildingPositions = new List<Vector3>();

    /// <summary>
    /// Spawn random characters in random buildings going to RANDOM places:
    /// </summary>
    private float time = 0.0f;
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
                            // Checking if they are going somewhere else:
                            if (indexOfSpawn != indexOfTarget)
                            {
                                // Creating the character:
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

    /// <summary>
    /// Receiving all the building positions and storing
    /// them in a list to spawn and target the characters.
    /// </summary>
    public void SetNewPosition(Vector3 newPosition)
    {
        buildingPositions.Add(newPosition);
    }

    /// <summary>
    /// Clear the list of building positions in case the user 
    /// decides to clear the screen.
    /// </summary>
    public void Clear()
    {
        buildingPositions.Clear();
    }
}
