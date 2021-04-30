using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLimb : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
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
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Limb")
		{
			collision.gameObject.tag = "Fallen";
		}
	}
}