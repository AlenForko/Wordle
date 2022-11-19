using System.Collections.Generic;
using Unity.VisualScripting;
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
    public bool invalidWord = false;
    private void Start()
    {
        textWords = new List<string>(_textAsset.text.Split("\n"));
        SelectRandomWord();
    }

    public void CheckWord(string word)
    {
        bool exists = false;
        if (tries < 4)
        {
            if (word == _selectedWord.Trim())
            {
                Win();
                Invoke(nameof(ReloadScene), 2f);
            }

            foreach (string item in textWords)
            {
                if (item.Contains(word))
                {
                    if (word != _selectedWord)
                    {
                        IncorrectWord();
                        tries++;
                        exists = true;
                    }
                }
            }
            if (!exists)
            {
                InvalidInput();
                invalidWord = true;
            }
        }
        else
        {
            Debug.Log("You lose!");
            Invoke(nameof(ReloadScene), 5f);
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
        Debug.Log("Incorrect word! Remaining tries: " + tries);
    }

    public void InvalidInput()
    {
        Debug.Log("Invalid word, try again!");
        //return invalidWord = true;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
