using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLimb : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("Collision");
		if (collision.gameObject.tag == "Limb")
		{
            Destroy(gameObject);
			collision.gameObject.GetComponent<SpringJoint2D>().enabled = false;
		}
		if (collision.gameObject.tag == "Vital")
		{
			gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
		}
	}
}
