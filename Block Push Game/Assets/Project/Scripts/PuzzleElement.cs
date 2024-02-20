using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleElement : MonoBehaviour
{
    public bool inverted = false;
    public Vector3 activatedScale;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        ActivateElement(false);
    }

    public void ActivateElement(bool on)
    {
        if (inverted)
            on = !on;

        if (on)
        {
            transform.localScale = activatedScale;
        }
        else
        {
            transform.localScale = originalScale;
        }
    }
}
