using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
   private string PlayerInputString { get; set; }

   [Header("~~~~Event~~~~")]
   public UnityEvent<string> onSubmitWord = new UnityEvent<string>();

   public UnityEvent<string> onLetterInput = new UnityEvent<string>();
   
   [Header("~~~~InputText~~~~")]
   public List<TMP_Text> inputText = new List<TMP_Text>();
   
   [Header("~~~~Keyboard~~~~")]
   [SerializeField] private GameObject[] _keyboardLayout;
   private PlayerInput _playerInput;

   private readonly string[] _letters = 
   {
      "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L",
      "Z", "X", "C", "V", "B", "N", "M"
   };

   private void Start()
   {
      PlayerInputString = "";
      inputText[0].text = "";

      InitializeKeyboard();
      
   }

   private void Update()
   {
      if (Input.anyKeyDown)
      {
         if (PlayerInputString.Length <= 4)
         {
            if (Input.inputString.All(Char.IsLetter))
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
         EnterWord();
      }
   }

   //Resets the input to blank.
   private void ResetLetters()
   {
      for (int i = 0; i < PlayerInputString.Length; i++)
      {
         inputText[i].text = " ";
      }
      PlayerInputString = "";
   }

   public void EnterWord()
   {
      onSubmitWord.Invoke(PlayerInputString);
      ResetLetters();
   }

   public void Backspace()
   {
      if(PlayerInputString.Length > 0)
         PlayerInputString = PlayerInputString.Remove(PlayerInputString.Length - 1);
     
      //Removes a letter from the input field.
      inputText[PlayerInputString.Length].text = " ";
   }
   
   private void InitializeKeyboard()
   {
      for (int i = 0; i < _keyboardLayout.Length; i++)
      {
         _keyboardLayout[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _letters[i];
      }
   }
}
