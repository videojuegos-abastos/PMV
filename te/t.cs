using UnityEngine;

class Cannon : MonoBehaviour {


	[SerializeField]
	Transform _target;

	public Transform target
	{
		get { return _target; }
		set { _target = value; }
	}

	[SerializeField]
	GameObject bullet;

	[SerializeField]
	[Range(.2f, 3f)]
	float reloadTime;

	[SerializeField]
	[Range(.1f, 10f)]
	float power;



	float timer = 0;


	void Start()
	{


		SetBullet();



	}


	void Update()
	{

		timer += Time.deltaTime;

		if (timer > reloadTime)
		{

			Shoot();
			timer = 0;
		}


		transform.LookAt(target.position); // https://docs.unity3d.com/ScriptReference/Transform.LookAt.html

	}

	void Shoot()
	{

		GameObject b = Instantiate( bullet, transform.position, transform.rotation, gameObject ); // https://docs.unity3d.com/ScriptReference/Object.Instantiate.html

		// https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
		// https://docs.unity3d.com/ScriptReference/Transform-forward.html
		b.GetComponent<Rigidbody>().AddForce( transform.forward * power, ForceMode.VelocityChange);

		Debug.Log("BOOM");

	}

	void SetBullet() {
		
		if (bullet == null)
		{
			Debug.Warning("No hemos asignado un proyectil a nuestro cañón.");
			return;
		}


		Rigidbody rb = bullet.GetComponent<Rigidbody>(); // https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html

		if (rb == null) {

			rb = bullet.AddComponent<Rigidbody>(); // https://docs.unity3d.com/ScriptReference/GameObject.AddComponent.html

		}

		
	}


}