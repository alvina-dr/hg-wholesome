using UnityEngine;

public class UI_TextPopperManager : MonoBehaviour
{
    [SerializeField] private UI_TextPopper _textPopperPrefab;
    [SerializeField] private Transform _textPopperParent;

    public void PopText(string text, Vector3 position)
    {
        UI_TextPopper textPopper = Instantiate(_textPopperPrefab, _textPopperParent);
        textPopper.transform.position = position;
        textPopper.PopText(text);
    }
}
