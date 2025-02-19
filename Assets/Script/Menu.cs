using UnityEngine;

public class Menu : MonoBehaviour
{
    public void goToGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ex4");
    }
    public void goToMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    public void goToPins() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Character Selection");
    }
    
}
