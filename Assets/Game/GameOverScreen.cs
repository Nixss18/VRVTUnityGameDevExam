using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
