using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InputFieldController : MonoBehaviour
{
    public InputField inputField;

    // Событие наведения курсора
    public void OnPointerEnter()
    {
        // Вы можете добавить здесь визуальную обратную связь, например, изменение цвета InputField
        Debug.Log("Наведен курсор");
    }

    // Событие выхода курсора
    public void OnPointerExit()
    {
        // Вы можете добавить здесь визуальную обратную связь, например, возврат цвета InputField
        Debug.Log("Курсор ушел");
    }

    // Событие нажатия
    public void OnPointerClick()
    {
        // Выбор InputField
        inputField.Select();
        Debug.Log("Нажатие на InputField");
    }
}
