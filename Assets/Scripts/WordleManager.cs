using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordleManager : MonoBehaviour
{
    [Header("~~~~TextFile~~~~")]
    [SerializeField] private TextAsset _textAsset;

    [Header("~~~~WordList~~~~")]
    public List<string> textWords = new List<string>();
    
    private string _selectedWord;
    public int tries = 0;
    
    private void Start()
    {
        textWords = new List<string>(_textAsset.text.Split("\n"));
        SelectRandomWord();
    }

    public void CheckWord(string word)
    {
        if (tries <= 4)
        {
            if (!textWords.Contains(word))
            {
                InvalidInput();
            }
            else if (word == _selectedWord)
            {
                Win();
            }
            else
            {
                tries++;
                IncorrectWord();
                
                if (tries >= 5)
                {
                    Debug.Log("You lose!");
                    Invoke(nameof(ReloadScene), 2f);
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
        Debug.Log("Incorrect word!" + tries);
    }

    public void InvalidInput()
    {
        Debug.Log("Invalid word, try again!");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
