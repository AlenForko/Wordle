using UnityEngine;

public class WordleUIManager : MonoBehaviour
{
    private int _currentRow;
    [SerializeField] private GameObject[] _entries;

    public void EnterWord(string word, int[] lettersValidity, int row)
    {
        for (int i = 0; i < lettersValidity.Length; i++)
        {
            GameObject thisLetter = _entries[row].transform.GetChild(i).gameObject;
            thisLetter.GetComponent<LetterUI>().SetText(word[i].ToString().ToUpper());
            if (lettersValidity[i] == 0)
            {
                thisLetter.GetComponent<LetterUI>().SetDefaultLetter();
            }
            else if (lettersValidity[i] == 1)
            {
                thisLetter.GetComponent<LetterUI>().SetCorrectLetter();
            }
            else if (lettersValidity[i] == 2)
            {
                thisLetter.GetComponent<LetterUI>().SetMisplacedPosition();
            }
        }
    }
}
