using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float bulletSpeed;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position = transform.position + new Vector3(0,  bulletSpeed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        //from https://docs.unity3d.com/ScriptReference/Renderer.OnBecameInvisible.html
    }
}
