using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    //returns whether or not a box or player is on the pressure plate
    protected bool ObjectsAreOnPlate()
    {
        foreach (GameObject obj in ObjectsAtPosition(transform.position))
        {
            if (obj.name.Contains("Box") || obj.name.Contains("Player"))
                return true;
        }
        return false;
    }

    //returns whether or not an object with an exact name is on the plate
    protected bool ObjectWithSpecificNameIsOnPlate(string n)
    {
        foreach (GameObject obj in ObjectsAtPosition(transform.position))
        {
            if (obj.name.Equals(n))
                return true;
        }
        return false;
    }

    //returns all of the objects at a specific position
    private List<GameObject> ObjectsAtPosition(Vector3 position)
    {
        List<GameObject> inPosition = new List<GameObject>();

        foreach (GameObject obj in LevelGrid.gridObjects)
        {
            if (PositionIsInObject(position, obj))
                inPosition.Add(obj);
        }

        return inPosition;
    }


    //returns if a specific point is within the area of an object
    private bool PositionIsInObject(Vector3 position, GameObject obj)
    {
        return obj != null && obj.transform.position.x - obj.transform.localScale.x / 2 < position.x &&
               obj.transform.position.x + obj.transform.localScale.x / 2 > position.x &&
               obj.transform.position.y - obj.transform.localScale.y / 2 < position.y &&
               obj.transform.position.y + obj.transform.localScale.y / 2 > position.y &&
               obj.transform.position.z - obj.transform.localScale.z / 2 < position.z &&
               obj.transform.position.z + obj.transform.localScale.z / 2 > position.z;
    }
}
