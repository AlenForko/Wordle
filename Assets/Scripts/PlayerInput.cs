using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
   private string _playerInputString;
   public string PlayerInputString => _playerInputString;
   
   [Header("~~~~Event~~~~")]
   public UnityEvent<string> onSubmitWord = new UnityEvent<string>();

   public UnityEvent<string> onLetterInput = new UnityEvent<string>();
   
   [Header("~~~~InputText~~~~")]
   public List<TMP_Text> inputText = new List<TMP_Text>();
   
   [Header("~~~~Keyboard~~~~")]
   [SerializeField] private GameObject[] _keyboardLayout;
   private PlayerInput _playerInput;

   public readonly string[] Letters = 
   {
      "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L",
      "Z", "X", "C", "V", "B", "N", "M"
   };

   private void Start()
   {
      _playerInputString = "";
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
               _playerInputString += Input.inputString;
               
               for (int i = 0; i < _playerInputString.Length; i++)
               {
                  inputText[i].text = _playerInputString[i].ToString().ToUpper();
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
      for (int i = 0; i < _playerInputString.Length; i++)
      {
         inputText[i].text = " ";
      }
      _playerInputString = " ";
   }

   public void EnterWord()
   {
      onSubmitWord.Invoke(_playerInputString);
      ResetLetters();
   }

   public void Backspace()
   {
      if(PlayerInputString.Length > 0)
         _playerInputString = _playerInputString.Remove(PlayerInputString.Length - 1);
     
      //Removes a letter from the input field.
      inputText[_playerInputString.Length].text = " ";
   }
   
   private void InitializeKeyboard()
   {
      for (int i = 0; i < _keyboardLayout.Length; i++)
      {
         _keyboardLayout[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = Letters[i];
      }
   }
}
