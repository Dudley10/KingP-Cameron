using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public void goToGame() {
       StartCoroutine(WaitForSoundAndTransition("ex4"));
    }
    private IEnumerator WaitForSoundAndTransition(string sceneName){
        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void goToMenu() {
       StartCoroutine(WaitForSoundAndTransition("Main Menu"));
    }
    public void goToPins() {
        StartCoroutine(WaitForSoundAndTransition("Character Selection"));
    }
    
}
