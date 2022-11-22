using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    
    [SerializeField] private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void CorrectLetter()
    {
        _image.color = Color.green;
    }

    public void IncorrectLetterPos()
    {
        _image.color = Color.yellow;
    }

    public void IncorrectLetter()
    {
        _image.color = Color.black;
    }
}
