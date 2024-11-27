using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    private bool hasScored = false;
    public static List<GameObject> allPins = new List<GameObject>();

    void Start()
    {
        allPins.Add(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "BowlingPin" || other.gameObject.tag == "BowlingBall") && !hasScored)
        {
            hasScored = true;
            GameManager.AddScore(1);

            Destroy(gameObject, 1.0f); 
            allPins.Remove(gameObject);
        }
    }

    public static void ClearRemainingPins()
    {
        foreach (GameObject pin in allPins)
        {
            if (pin != null)
            {
                Destroy(pin);
            }
        }
        allPins.Clear();
    }
}
