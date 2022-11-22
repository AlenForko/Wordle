using System;
using TMPro;
using UnityEngine;

public class WordleUIManager : MonoBehaviour
{
    private int _currentRow;
    [Header("~~~~Row Entries~~~~")]
    [SerializeField] private GameObject[] _entries;

    private PlayerInput _playerInput;
    private KeyboardButton _keyboardButton;
    private ButtonUI _buttonUI;

    private void Start()
    {
        _keyboardButton = GetComponent<KeyboardButton>();
    }

    public void EnterWord(string word, int[] lettersValidity, int row)
    {
        for (int i = 0; i < lettersValidity.Length; i++)
        {
            GameObject thisLetter = _entries[row].transform.GetChild(i).gameObject;
            thisLetter.GetComponent<LetterUI>().SetText(word[i].ToString().ToUpper());
            string thisLetterText = thisLetter.GetComponent<TextMeshProUGUI>().text;
            
            for (int j = 0; j < _keyboardButton.keyboardLayout.Length; j++)
            {
                GameObject thisButton = _keyboardButton.keyboardLayout[j];
                string buttonText = _keyboardButton.keyboardLayout[j].GetComponentInChildren<TextMeshProUGUI>().text;
                
                if (thisLetterText == buttonText)
                {
                    switch (lettersValidity[i])
                    {
                        case 0: 
                            thisLetter.GetComponent<LetterUI>().SetDefaultLetter(); 
                            thisButton.GetComponent<ButtonUI>().IncorrectLetter(); 
                            continue;
                        case 1: 
                            thisLetter.GetComponent<LetterUI>().SetCorrectLetter(); 
                            thisButton.GetComponent<ButtonUI>().CorrectLetter(); 
                            continue; 
                        case 2: 
                            thisLetter.GetComponent<LetterUI>().SetMisplacedPosition(); 
                            thisButton.GetComponent<ButtonUI>().IncorrectLetterPos(); 
                            continue;
                    }
                }
            }
        }
    }
}
