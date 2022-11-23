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

   [Header("~~~~InputText~~~~")]
   public List<TMP_Text> inputText = new List<TMP_Text>();

   private WordleManager _manager;
   
   private void Start()
   {
      PlayerInputString = "";
      inputText[0].text = "";

      _manager = GetComponent<WordleManager>();
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
      ResetLetters();
   }

   public void Backspace()
   {
      if(PlayerInputString.Length > 0)
         PlayerInputString = PlayerInputString.Remove(PlayerInputString.Length - 1);
     
      //Removes a letter from the input field.
      inputText[PlayerInputString.Length].text = " ";
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
