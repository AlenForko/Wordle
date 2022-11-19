using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI _popUpText;
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
                return;
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
            _popUpText.text = "You lose! Your word was: " + _selectedWord.ToUpper();
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
        _popUpText.text = "You Win!";
        Invoke(nameof(ReloadScene), 2f);
    }

    private void IncorrectWord()
    {
        _popUpText.text = "Incorrect word! Try again.";
    }

    private void InvalidInput()
    {
        _popUpText.text = "Invalid word, try again!";
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
