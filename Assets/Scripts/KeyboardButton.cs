using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour
{
    public PlayerInput playerInput;
    
    [Header("~~~~Keyboard~~~~")]
    public GameObject[] keyboardLayout;
    
    private readonly string[] _letters = 
    {
        "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L",
        "Z", "X", "C", "V", "B", "N", "M"
    };

    private void Start()
    {
        Keyboard();
    }

    private void Keyboard()
    {
        for (int i = 0; i < keyboardLayout.Length; i++)
        {
            keyboardLayout[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _letters[i];

            string letter = _letters[i]; 
            keyboardLayout[i].gameObject.GetComponent<Button>().onClick.AddListener
                (() => { playerInput.InputWord(letter); });
        }
    }
}
