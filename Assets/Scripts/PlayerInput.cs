using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
   private string PlayerInputString { get; set; }
   private readonly string[] _letters = 
   {
      "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L",
      "Z", "X", "C", "V", "B", "N", "M"
   };

   [Header("~~~~Event~~~~")]
   public UnityEvent<string> onSubmitWord = new UnityEvent<string>();

   [Header("~~~~InputText~~~~")]
   public List<TMP_Text> inputText = new List<TMP_Text>();
   
   [Header("~~~~Keyboard~~~~")]
   [SerializeField] private GameObject[] _keyboardLayout;

   private WordleManager _manager;
   
   private void Start()
   {
      PlayerInputString = "";
      inputText[0].text = "";

      _manager = GetComponent<WordleManager>();

      Keyboard();
   }

   private void Update()
   {
      if (Input.anyKeyDown)
      {
         if (PlayerInputString.Length <= 4)
         {
            if (Input.inputString.All(char.IsLetter))
            {
               PlayerInputString += Input.inputString;
               
               for (int i = 0; i < PlayerInputString.Length; i++)
               {
                  inputText[i].text = PlayerInputString[i].ToString().ToUpper();
               }
            }
         }
      }

      if (Input.GetKeyDown(KeyCode.Backspace))
      {
         Backspace();
      }

      if (Input.GetKeyDown(KeyCode.Return))
      {
         SubmitWord();
      }
   }
   
   private void ResetLetters()
   {
      for (int i = 0; i < PlayerInputString.Length; i++)
      {
         inputText[i].text = " ";
      }
      PlayerInputString = "";
   }

   public void SubmitWord()
   {
      onSubmitWord.Invoke(PlayerInputString.ToLower());

      if (PlayerInputString.Length < 5 || _manager.invalidWord)
      {
         _manager.invalidWord = false;
      }
      ResetLetters();
   }

   public void Backspace()
   {
      if(PlayerInputString.Length > 0)
         PlayerInputString = PlayerInputString.Remove(PlayerInputString.Length - 1);
     
      //Removes a letter from the input field.
      inputText[PlayerInputString.Length].text = " ";
   }
   
   private void Keyboard()
   {
      for (int i = 0; i < _keyboardLayout.Length; i++)
      {
         _keyboardLayout[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _letters[i];
         //_keyboardLayout[i].gameObject.AddComponent<KeyboardButton>().Init(this, _letters[i]); 
         
         string letter = _letters[i]; 
         _keyboardLayout[i].gameObject.GetComponent<Button>().onClick.AddListener(() => { InputWord(letter); });
      }
   }

   public void InputWord(string word)
   {
      if (PlayerInputString.Length <= 4)
      {
         PlayerInputString += word;
         for (int i = 0; i < PlayerInputString.Length; i++)
         {
            inputText[i].text = PlayerInputString[i].ToString();
         }
      }
   }
}
