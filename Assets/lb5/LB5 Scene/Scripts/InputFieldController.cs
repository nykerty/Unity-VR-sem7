using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InputFieldController : MonoBehaviour
{
    public InputField inputField;

    // ������� ��������� �������
    public void OnPointerEnter()
    {
        // �� ������ �������� ����� ���������� �������� �����, ��������, ��������� ����� InputField
        Debug.Log("������� ������");
    }

    // ������� ������ �������
    public void OnPointerExit()
    {
        // �� ������ �������� ����� ���������� �������� �����, ��������, ������� ����� InputField
        Debug.Log("������ ����");
    }

    // ������� �������
    public void OnPointerClick()
    {
        // ����� InputField
        inputField.Select();
        Debug.Log("������� �� InputField");
    }
}
