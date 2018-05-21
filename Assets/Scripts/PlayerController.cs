using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float speed = 1;
	public Boundary boundary;
	Rigidbody rb;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 1;
    private float fireOffset = 0;
    public AudioClip shotClip;
    public AudioSource shotSource;
    public GameController gameController;

    void Start()
	{
		rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && fireOffset < Time.time)
        {
            fireOffset = Time.time + fireRate;
            var shotClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //StartCoroutine(MakeCoroutineToDestroyInSeconds(shotClone, 2));
            gameController.AddShot();
        }
    }

    IEnumerator MakeCoroutineToDestroyInSeconds(UnityEngine.Object obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(obj);
    }

	void FixedUpdate () {
        //CrossPlatformInputManager.GetAxis
        var h = CrossPlatformInputManager.GetAxis("Horizontal");
		var v = CrossPlatformInputManager.GetAxis("Vertical");

		rb.velocity = new Vector3(h, 0, v) * speed;
		// rb.AddForce(new Vector3(h, 0, v)) * speed;
		var x = Mathf.Clamp(rb.position.x, boundary.xLeft, boundary.xRight);
		var y = 0f;
		var z = Mathf.Clamp(rb.position.z, boundary.zTop, boundary.zBottom);
		rb.position = new Vector3(x, y, z);

		rb.rotation = Quaternion.Euler(0, 0, -h*45f);
	}
}

[System.Serializable]
public class Boundary
{
	public float xLeft, xRight, zTop, zBottom;
}