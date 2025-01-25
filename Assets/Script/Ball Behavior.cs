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
    public float timeSinceLastLaunch;
    public bool launching;
    public float launchDuration;
    public float timeLastLaunch;
    public float timeLaunchDuration;
    public Vector2 targetPosition;

    public int secondsToMaxSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //secondsToMaxSpeed = 30.0f;
    //minSpeed = 0.75f;
    //maxSpeed = 2.0f;
     targetPosition = getRandomPosition();  
    Vector2 getRandomPosition(){
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 v = new Vector2(randomX, randomY);
            return v;
        }
        //public float
        private float getDifficultyPercentage() {
        float difficulty=Mathf.Clamp01 (Time.timeSinceLevelLoad / secondsToMaxSpeed);
        return difficulty;
    }
    
    private void launch() {
        targetPosition = target.transform.position;
        if (launching == false) {
            timeLaunchStart = Time.time;
            launching = true;
        }
    }
    //public bool
    private bool onCooldown() {
        bool onCooldown = true;
        float timeSinceLastLaunch = (Time.time - timeLastLaunch);
        if(timeSinceLastLaunch > cooldown) {
           onCooldown = false;
        }
        return onCooldown;
    }
    //public void
    private void startCooldown() {
        launching = false;
        timeLastLaunch = Time.time;
    }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        if (onCooldown() == false) {
            if (launching == true) {
                float currentLaunchTime = Time.time - timeLaunchStart;
                if (currentLaunchTime > launchDuration) {
                     startCooldown();
                }
            } else {
                launch();
            }
        
        Vector2 currentPosition = transform.position;
        float distance = Vector2.Distance((Vector2) transform.position, targetPosition);
        if (distance > 0.1f) {
            float currentSpeed;
            if(launching == true) {
                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, getDifficultyPercentage());
            } else{
                currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, getDifficultyPercentage());
            }
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            transform.position = newPosition;
        } else {
            if(launching == true) {
                startCooldown();
            }
            targetPosition = randomPosition();
        }
        }
        // }
        // float timeLaunching = Time.time - timeLastLaunch;
        // if(timeLaunching > launchDuration){
        //     startCooldown();
        // }
        // else {
        //     launch();
        // }
        // getRandomPosition();
        //}
        //}
        //}
    //     Vector2 getRandomPosition(){
    //         float randomX = Random.Range(minX, maxX);
    //         float randomY = Random.Range(minY, maxY);
    //         Vector2 v = new Vector2(randomX, randomY);
    //         return v;
    //     }
    //     //public float
    //     public float getDifficultyPercentage() {
    //     float difficulty=Mathf.Clamp01 (Time.timeSinceLevelLoad / secondsToMaxSpeed);
    //     return difficulty;
    // }
    
    // public void launch() {
    //     targetPosition = target.transform.position;
    //     if (launching == false) {
    //         timeLaunchStart = Time.time;
    //         launching = true;
    //     }
    // }
    // //public bool
    // public bool onCooldown() {
    //     bool onCooldown = true;
    //     float timeSinceLastLaunch = (Time.time - timeLastLaunch);
    //     if(timeSinceLastLaunch > cooldown) {
    //        onCooldown = false;
    //     }
    //     return onCooldown;
    // }
    // //public void
    // public void startCooldown() {
    //     launching = false;
    //     timeLastLaunch = Time.time;
    // }
}
}

