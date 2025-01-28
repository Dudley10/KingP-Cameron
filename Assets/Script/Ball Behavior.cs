using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minX = -8.01f;
    public float minY = -4.06f;
    public float maxX = 8.06f;
    public float maxY = -3.96f;
    public float minSpeed;
    public float maxSpeed;
    public Vector2 targetPosition;
    public GameObject target;
    public bool launching;
    public float minLaunchSpeed;
    public float maxLaunchSpeed;
    public float cooldown;
    public float timeSinceLastLaunch;
    public float timeLaunchStart;
    public float launchDuration;
    public float timeLastLaunch;
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
        if (onCooldown() == false) {
            if (launching == true) {
                float currentLaunchTime = Time.time - timeLaunchStart;
                if (currentLaunchTime > launchDuration) {
                     startCooldown();
                }
            } else {
                Debug.Log("unim");
                launch();
            }
        }
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        float distance = Vector2.Distance(currentPosition, targetPosition);
        if (distance > 0.1f) {
            float difficulty = getDifficultyPercentage();
            float currentSpeed;
            if(launching == true) {
                float launchingForHowLong = Time.time - timeLaunchStart;
                if (launchingForHowLong > launchDuration) {
                    startCooldown();
                }
                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, difficulty);
            } else{
                currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, difficulty);
            }
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            transform.position = newPosition;
        } else {
            if(launching == true) {
                startCooldown();
            }
            targetPosition = getRandomPosition();
        }
        }

Vector2 getRandomPosition(){
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 v = new Vector2(randomX, randomY);
            return v;
        }
        //public float
        public float getDifficultyPercentage() {
            float difficulty= Mathf.Clamp01 (Time.timeSinceLevelLoad / secondsToMaxSpeed);
            return difficulty;
         }
    
    public void launch() {
        targetPosition = target.transform.position;
        if (launching == false) {
            timeLaunchStart = Time.time;
            launching = true;
        }
    }
    //public bool
    public bool onCooldown() {
        bool result = false;
        float timeSinceLastLaunch = Time.time - timeLastLaunch;
        if(timeSinceLastLaunch < cooldown) {
           result = true;
        }
        return result;
    }
    //public void
    public void startCooldown() {
        timeLastLaunch = Time.time;
        launching = false;
    }
    
}


