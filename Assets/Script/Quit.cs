using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        quit();
    }
    private void quit(){
        if (Input.GetMouseButtonDown(0)){
            Application.Quit();
        }

    }
}
