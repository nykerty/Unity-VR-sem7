using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusButton : MonoBehaviour
{
    public InputField inputField;

    public void NameSubmit()
    {
        Debug.Log("submit click");
        //inputField.OnSubmit(inputField.text);
    }
}
