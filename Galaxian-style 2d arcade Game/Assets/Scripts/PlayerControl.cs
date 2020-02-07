using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float shootSpeed;
    public GameObject bullet;
    public BoxCollider2D background;

    private float shootInterval;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x < 8)
        {

            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
            

        }
        else if (Input.GetAxis("Horizontal") < 0 && transform.position.x > -8)
        {

            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
           
        }

        if (Input.GetAxis("Vertical") > 0 && transform.position.y <4.6)
        {

            transform.position += new Vector3(0, moveSpeed * Time.deltaTime);


        }
        else if (Input.GetAxis("Vertical") < 0 && transform.position.y > -4.6)
        {

            transform.position += new Vector3( 0, -moveSpeed * Time.deltaTime);

        }

        if (Input.GetAxis("Fire1") > 0 && shootInterval>shootSpeed)
        {
            Debug.Log("Fire");
            Instantiate(bullet, transform.position, Quaternion.identity);
            shootInterval = 0;
        }
        shootInterval += Time.deltaTime;
    }
}
