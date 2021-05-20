using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public Camera cam;
    public Transform innerLock;
    public Transform pickPosition;

    public float maxAngle = 90;
    public float lockSpeed = 5;

    [Range(1,25)]
    public float lockRange = 10;

    private float eulerAngle;
    private float unlockAngle;
    private Vector2 unlockRange;

    private float keyPressTime = 0;

    private bool movePick;
    // Start is called before the first frame update
    void Start()
    {
        newLock();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pickPosition.position;

		if (movePick)
		{
            Vector3 dir = Input.mousePosition -cam.WorldToScreenPoint(transform.position);

            eulerAngle = Vector3.Angle(dir, new Vector3(0,1,0));

            Vector3 cross = Vector3.Cross(Vector3.up, dir);
            if (cross.z < 1)
			{
                eulerAngle = -eulerAngle;
			}

            eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

            Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
            transform.rotation = rotateTo;
		}
        if (Input.GetMouseButtonDown(0))
		{
            movePick = false;
            keyPressTime = 1;
		}
        if (Input.GetMouseButtonUp(0))
		{
            movePick = true;
            keyPressTime = 0;
		}

        //The Turn angle of the inner lock. If it matches the 90 degrees.
		float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
        float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
        float maxRotation = (percentage / 100) * maxAngle;

        float lockLerp = Mathf.Lerp(innerLock.eulerAngles.z, lockRotation, lockSpeed *Time.deltaTime);
        innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

        if (lockLerp >= maxRotation -1)
		{
            if (eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
			{
                //Does something once it unlocks.
                Debug.Log("It Unlocks");

                movePick = true;
                keyPressTime = 0;
			}
			else
			{
                //The Pin will Shake if incorrect.
                float randomRotation = Random.insideUnitCircle.x;
                transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));
			}
		}
    }

    void newLock()
	{
        //Ensure the unlocking angle is larger than the lock range.
        unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
    }
}
