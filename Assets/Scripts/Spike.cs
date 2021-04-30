using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int destroyAfterSeconds;

    private float destroyTime;
    
    void Start()
    {
        destroyTime = Time.time + destroyAfterSeconds;
    }

    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Floor")
		{
            Destroy(gameObject);
		}
	}
}
