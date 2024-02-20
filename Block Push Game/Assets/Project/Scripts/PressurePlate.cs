using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Plate
{
    public List<PuzzleElement> elementsToActivate = new List<PuzzleElement>();
    
    // Update is called once per frame
    void Update()
    {
        ActivateElements(ObjectsAreOnPlate());
    }

    private void ActivateElements(bool on)
    {
        foreach(PuzzleElement puzzle in elementsToActivate)
        {
            puzzle.ActivateElement(on);
        }
    }
}
