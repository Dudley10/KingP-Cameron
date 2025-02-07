using UnityEngine;
using TMPro;
public class DashIconBehavior : MonoBehaviour
{ TextMeshProUGUI label;
float cooldown;
float cooldownRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        cooldownRate = NewMonoBehaviourScript.cooldownRate;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = NewMonoBehaviourScript.cooldown;
        string message = "";
        if (cooldown > 0.0) {
            message = string.Format("{0:0.0}", cooldown);
        }
        label.SetText(message);
    }
}
