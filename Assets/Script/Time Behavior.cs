using TMPro;
using UnityEngine;

public class TimeBehavior : MonoBehaviour
{
    private float timer;
    private TextMeshProUGUI textField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();

        if(textField == null ) {
            Debug.Log("No component found");
        }
    }


    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if(textField != null){
            int minutes = Mathf.FloorToInt(timer/60);
            int seconds = Mathf.FloorToInt(timer % 60);
            string timeLabel = 
            string.Format("Time: {0:00}:{1:00}", minutes, seconds);
            textField.SetText(timeLabel);
        }

        //textField.text = timer.ToString();
        //Debug.Log("time thus far: " + timer);
    }
}
