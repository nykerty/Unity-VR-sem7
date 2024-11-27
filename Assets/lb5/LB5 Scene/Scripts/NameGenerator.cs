using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGenerator : MonoBehaviour
{
    public Text NameInput;
    public InputField inputField;


    private string[] names = {
    "Alex", "Bob", "Charlie", "David", "Eve",
    "Frank", "Grace", "Heidi", "Ivan", "Judy"
    };

    public void GenerateName()
    {
        int randomIndex = Random.Range(0, names.Length);
        Debug.Log(names[randomIndex]);

        inputField.text = names[randomIndex];
        NameInput.text = names[randomIndex];
    }
}
