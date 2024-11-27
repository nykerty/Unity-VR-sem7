using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CallMenuButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty CallMenu;

    private void OnEnable()
    {
        CallMenu.action.performed += OnCallMenuPressed;
        CallMenu.action.Enable();
    }

    private void OnDisable()
    {
        CallMenu.action.performed -= OnCallMenuPressed;
        CallMenu.action.Disable();
    }

    private void OnCallMenuPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Нажата кнопка 'A' на контроллере!");
        SceneManager.LoadScene("MenuScene");
    }
}
