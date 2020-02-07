using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletController : MonoBehaviour
{

    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -bulletSpeed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        ////from https://docs.unity3d.com/ScriptReference/Renderer.OnBecameInvisible.html
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
