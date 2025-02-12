using UnityEngine;

public class Menu : MonoBehaviour
{
    public void goToGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ex4");
    }
    public void goToMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    
}
