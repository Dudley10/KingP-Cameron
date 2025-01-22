using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minX = -6.09f;
    public float minY = -4.08f;
    public float maxX = 7.04f;
    public float maxY = 3.96f;
    public float minSpeed = 5.0f;
    public float maxSpeed = 10.0f;
    public GameObject target;
    public float minLaunchSpeed;
    public float maxLaunchSpeed;
    public float minTimeToLaunch;
    public float maxTimeToLaunch;
    public float cooldown;
    //public bool 
    public Vector2 targetPosition;

    public int secondsToMaxSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //secondsToMaxSpeed = 30.0f;
    //minSpeed = 0.75f;
    //maxSpeed = 2.0f;
     targetPosition = getRandomPosition();   
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        float distance = Vector2.Distance(currentPosition, targetPosition);
        if (distance > 0.1f) {
        //if (targetPosition != currentPosition) {
            float difficulty = getDifficultyPercentage();
            float currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, difficulty);
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            transform.position = newPosition;
        } else {
            targetPosition = getRandomPosition();
        }
        getRandomPosition();
    
        }
        Vector2 getRandomPosition(){
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 v = new Vector2(randomX, randomY);
            return v;
        }
        public float getDifficultyPercentage() {
        float difficulty=Mathf.Clamp01 (Time.timeSinceLevelLoad / secondsToMaxSpeed);
        return difficulty;
    }
}
