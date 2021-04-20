using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class ScoreBox : MonoBehaviour
{

      public TextMeshPro ScoreField;
       public TextMeshPro TimeField;

      public static int currentScore;

      public AudioSource source;
       public AudioClip finishSound;

      private float gameTime = 120;

      public GameObject finishMenu;

      private bool isGameRunning;

      void Start()
      {
       Time.timeScale = 1f;
            isGameRunning = true;
            // gameTime = 20f;
             currentScore = 0;
            //    finishMenu.SetActive(false);
      }


      void Update()
      {

            if(isGameRunning){
            ScoreField.text = currentScore.ToString();
            // TimeField.text = gameTime.ToString();
            TimeField.text =  Mathf.Round(gameTime).ToString();
           

            gameTime -= Time.deltaTime;

            if (gameTime < 0)
            {
                  isGameRunning = false;
                  finishGame();
            }
            }

      }


      // void replay()
      // {
      //       SceneManager.LoadScene("Scene-01");
      // }


      void finishGame()
      {
      
            finishMenu.SetActive(true);
             source.PlayOneShot(finishSound);
                   Time.timeScale = 0f;
      }


//       void quitGame()
//       {

// #if UNITY_EDITOR
//          // Application.Quit() does not work in the editor so
//          // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
//          UnityEditor.EditorApplication.isPlaying = false;
// #else
//             Application.Quit();
// #endif
//       }

}
