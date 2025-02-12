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
    Rigidbody2D body;
    public bool rerouting;
    
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
            body.MovePosition(newPosition);
        } else {
            if(launching == true) {
                startCooldown();
            }
            targetPosition = getRandomPosition();
        }
        }
        
        void FixedUpdate(){
            body = GetComponent<Rigidbody2D>();
            Vector2 currentPosition = body.position;
            if (onCooldown() == false) {
                if (launching == true) {
                    float currentLaunchTime = Time.time - timeLaunchStart;
                    if (currentLaunchTime > launchDuration) {
                        startCooldown();
                    }
                } else { 
                    launch();
                }
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
        //targetPosition = target.transform.position;
        Rigidbody2D targetBody = target.GetComponent<Rigidbody2D>();
        targetPosition = targetBody.position;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collided with: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Wall") {
            targetPosition = getRandomPosition();
        }
        if(collision.gameObject.tag == "Ball") {
            Reroute(collision);
        }
    }

    public void initialPosition() {
        body = GetComponent<Rigidbody2D>();
        body.position = getRandomPosition();
        targetPosition = getRandomPosition();
        launching = false;
        rerouting = true;
    }

    public void Reroute(Collision2D collision) {
        GameObject otherBall = collision.gameObject;
        if (rerouting == true) {
            otherBall.GetComponent<BallBehavior>().rerouting = false;
            Rigidbody2D ballBody = otherBall.GetComponent<Rigidbody2D>();
            Vector2 contact = collision.GetContact(0).normal;
            targetPosition = Vector2.Reflect(targetPosition, contact).normalized;
            launching = false;
            float seperationDistance = 0.1f;
            ballBody.position += contact * seperationDistance;
        } else { 
            rerouting = true;
            }
    }
    public void setBounds (float miX, float maX, float miY, float maY) {
        minX = miX;
        maxX = maX;
        minY = miY;
        maxY = maY;
    }
    
}


