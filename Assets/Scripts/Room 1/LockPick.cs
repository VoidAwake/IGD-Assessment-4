using UnityEngine;
using UnityEngine.SceneManagement;

public class LockPick : MonoBehaviour
{
    [SerializeField] private int nextSceneBuildIndex;

    [SerializeField] private Camera cam;
    [SerializeField] private Transform innerLock;
    [SerializeField] private Transform pickPosition;

    [SerializeField] private float maxAngle = 90;
    [SerializeField] private float lockSpeed = 5;

    [Range(1,25)]
    [SerializeField] private float lockRange = 10;

    private float eulerAngle;
    private float unlockAngle;

    private int KeyPressTime => Input.GetMouseButton(0) ? 1 : 0;

    void Start()
    {
	    // Ensure the unlocking angle is larger than the lock range.
	    unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
	    
	    transform.localPosition = pickPosition.position;
    }

    void Update()
    {
	    if (!Input.GetMouseButton(0))
		    RotatePick();

	    RotateLock();

	    if (Input.GetMouseButtonDown(0))
		    Debug.Log(eulerAngle);
    }

    private void RotatePick()
    {
	    Vector3 dir = Input.mousePosition -cam.WorldToScreenPoint(transform.position);

	    eulerAngle = Vector3.Angle(dir, new Vector3(0,1,0));

	    Vector3 cross = Vector3.Cross(Vector3.up, dir);
	    if (cross.z <= 0)
	    {
		    eulerAngle = -eulerAngle;
	    }

	    eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

	    Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
	    transform.rotation = rotateTo;
    }

    private void RotateLock()
    {
	    float angleDifference = Mathf.Abs(eulerAngle - unlockAngle);
	    float normalisedAngleDifference = angleDifference / 180;
	    float percentage = (1 - normalisedAngleDifference) * 100;
	    float lockRotation = percentage / 100 * maxAngle * KeyPressTime;
	    float maxRotation = percentage / 100 * maxAngle;

	    //returns a float range of the min and max, with lockspeed * time.deltatime being the increments.
	    float lockLerp = Mathf.Lerp(innerLock.eulerAngles.z, lockRotation, lockSpeed * Time.deltaTime);
	    innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

	    if (lockLerp >= maxRotation - 1)
	    {
		    if (WithinUnlockRange())
		    {
			    // Does something once it unlocks.
			    SceneManager.LoadScene(nextSceneBuildIndex);
		    }
		    else
		    {
			    // The pick will shake if incorrect.
			    float randomRotation = Random.insideUnitCircle.x;
			    transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));
		    }
	    }
    }

    private bool WithinUnlockRange()
    {
	    return eulerAngle < unlockAngle + lockRange && eulerAngle > unlockAngle - lockRange;
    }
}
