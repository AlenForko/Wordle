using TMPro;
using UnityEngine;

public class LetterUI : MonoBehaviour
{
    private TextMeshProUGUI _textUI;

    // Start is called before the first frame update
    void Start()
    {
        _textUI = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        _textUI.text = text;
    }

    public void SetCorrectLetter()
    {
        _textUI.color = Color.green;
    }
    
    public void SetMisplacedPosition()
    {
        _textUI.color = Color.yellow;
    }
    
    public void SetDefaultLetter()
    {
        _textUI.color = Color.black;
    }
    
}
