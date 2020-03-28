using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buildable Object", menuName = "Buildable Object")]
public class BuildableObject : ScriptableObject
{
    public GameObject prefab;
    public Vector2 hitboxSize;
    public Vector3 offset;
}
