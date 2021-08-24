using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    float dealyInSec = 2F;
    public void LoadGame() {    
        StartCoroutine(LoadGameWithDelay());
    }

    IEnumerator LoadGameWithDelay() {
        yield return new WaitForSeconds(dealyInSec);
        SceneManager.LoadScene("Game");
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver() {
        StartCoroutine(LoadGameOverWithDelay());
    }

    IEnumerator LoadGameOverWithDelay() {
        yield return new WaitForSeconds(dealyInSec);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadInfoScene() {
        SceneManager.LoadScene("Information");
    }

    public void LoadHowToPlay() {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
