using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minX = -8.05;
    puublic float minY;
    public float maxX;
    public float MaxY = 3.96;
    public float minSpeed;
    public float maxSpeed;
    public float Vector2 targetPosition;

    public int secondsToMaxSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    secondsToMaxSpeed = 30;
    minSpeed = 0.75;
    maxSpeed = 2.0;
     targetPosition = getRandomPosition();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = gameObject.GetComponent<Transform>()
        if(targetPosition != currentPos) {
            float currentSpeed = minSpeed;
            Vector2 newPosition = Vector2.MoveTowards(currentPos, currentSpeed, targetPosition);
            transform.position = newPosition;
        } else {
            targetPosition = getRandomPosition;
        }
        }
        
}
