using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour
{ 
    public string letter;
    public PlayerInput playerInput;
    
    //Dependency injection
    public void Init(PlayerInput input, string letters)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = letters;
        this.playerInput = input;
        this.letter = letters;
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        playerInput.InputWord(letter);
    }
}
