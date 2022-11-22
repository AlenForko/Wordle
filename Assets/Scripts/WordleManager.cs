using System.Collections.Generic;
using TMPro;
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

    public WordleUIManager wordleUIManager;

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
                Win(word);
                return;
            }

            foreach (string item in textWords)
            {
                if (item.Contains(word))
                {

                    IncorrectWord(word, tries);
                    tries++;
                    exists = true;
                    
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

    private void Win(string word)
    {
        _popUpText.text = "You Win!";
        wordleUIManager.EnterWord(word, new int[]{1,1,1,1,1}, tries);
        Invoke(nameof(ReloadScene), 2f);
    }

    private void IncorrectWord(string word, int trie)
    {
        _popUpText.text = "Incorrect word! Try again.";
        int[] validity = new int[word.Length]; 
        
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == _selectedWord[i])
            {
                validity[i] = 1;
            }
            else if(_selectedWord.Contains(word[i]))
            {
                validity[i] = 2;
            }
            else
            {
                validity[i] = 0;
            }
        }
        wordleUIManager.EnterWord(word, validity, trie);
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
