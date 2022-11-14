using System.Collections.Generic;
using UnityEngine;

public class WordleManager : MonoBehaviour
{
    [Header("~~~~TextFile~~~~")]
    [SerializeField] private TextAsset _textAsset;

    [Header("~~~~WordList~~~~")]
    public List<string> textWords = new List<string>();
    
    private string _selectedWord;
    private int _tries = 5;
    
    private void Start()
    {
        textWords = new List<string>(_textAsset.text.Split("\n"));
        SelectRandomWord();
    }

    public void CheckWord(string word)
    {
        if (_tries > 0)
        {
            if (!textWords.Contains(word))
            {
                InvalidInput();
            }
            else if (word == _selectedWord)
            {
                Win();
                _tries = 0;
            }
            else
            {
                _tries--;
                IncorrectWord();
                
                if (_tries <= 0)
                {
                    Debug.Log("You lose!");
                }
            }
        }
    }

    private void SelectRandomWord()
    {
        _selectedWord = textWords[Random.Range(0, textWords.Count - 1)];
        Debug.Log("Current word: " + _selectedWord);
    }

    private void Win()
    {
        Debug.Log("You Win!");
    }

    private void IncorrectWord()
    {
        Debug.Log("Incorrect word!" + _tries);
    }

    private void InvalidInput()
    {
        Debug.Log("Invalid word, try again!");
    }
}
