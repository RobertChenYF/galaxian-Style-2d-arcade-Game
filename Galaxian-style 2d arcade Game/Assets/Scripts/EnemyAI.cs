using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    private float ShootTime;
    public GameObject bullet;
    private float FlankTime;
    private Vector3 positionInTheFlock;
    private Vector3 startPosition;
    //private Vector3 rightMaximumPos;
    private bool completeFlank = false;
    public float moveSpeed;
    public float lerpBound;
    private Vector3 startPos;
    private float progress = 0;
    private const float maxTime = 6.0f;
    private const float amplitude = 3f;
    private float time = 0;
    public float SinSpeed;
    private float startFlankPosX = -999;
    private int flankDirection;
    void Start()
    {
        FlankTime = (float)Random.Range(2, 15);
        ShootTime = (float)Random.Range(0, 4);
        startPosition = transform.position;
        flankDirection = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        
        positionInTheFlock =new Vector3(startPosition.x + Mathf.PingPong(Time.time, 2), startPosition.y, startPosition.z);
        //sample code from unity documentation https://docs.unity3d.com/ScriptReference/Mathf.PingPong.html
        if (completeFlank == true)
            {
            
                progress = Mathf.Clamp(progress + Time.deltaTime, 0.0f, maxTime);
                transform.position = Vector3.Lerp(startPos, positionInTheFlock, progress);
                //Debug.Log("lerp");

            if (progress>=1) {
                completeFlank = false;
                FlankTime = (float)Random.Range(2, 15);
                progress = 0;
            }
            }
       
        
        else if (FlankTime >= 0)
        {
        if (ShootTime <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            ShootTime = Random.Range(2,4);
        }
        
            transform.position = positionInTheFlock;
            FlankTime -= Time.deltaTime;
        }
        
        else if (FlankTime <=0)
        {
            
            if (transform.position.y > -4.9f)
            {
                if (startFlankPosX == -999)
                {
                    startFlankPosX = transform.position.x;
                }
                if (flankDirection == 0)
                {
                transform.position = new Vector3(startFlankPosX + amplitude * Mathf.Sin(time),transform.position.y - 3f*Time.deltaTime);
                }
                else if(flankDirection == 1)
                {
                transform.position = new Vector3(startFlankPosX - amplitude * Mathf.Sin(time), transform.position.y - 3f * Time.deltaTime);
                } 
               // - 3 * Time.deltaTime
                time += Time.deltaTime * SinSpeed;
                if (ShootTime <= 0)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    ShootTime = 0.7f;
                }
            }
            else
            {
                completeFlank = true;
                transform.position = new Vector3(transform.position.x, 4.9f);
                startPos = transform.position;
                time = 0;
                startFlankPosX = -999;
                flankDirection = Random.Range(0, 2);
            }
               
            

        }

        ShootTime -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
