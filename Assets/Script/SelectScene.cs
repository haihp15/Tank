using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour {

	public void selectScene()
    {
        switch (this.gameObject.name)
        {
            case "PlayerGame":
                SceneManager.LoadScene("Play");
                break;

            case "Guide":
                SceneManager.LoadScene("Guide");
                break;
            case "GameOver":
                SceneManager.LoadScene("GameOver");
                break;
            case "GameClear":
                SceneManager.LoadScene("GameClear");
                break;
            case "BackButton":
                SceneManager.LoadScene("Start_Menu");
                break;
            case "Quit":
                Application.Quit();
                break;


        }
    }
}
