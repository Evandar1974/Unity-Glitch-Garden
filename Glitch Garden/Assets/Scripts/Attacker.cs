using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left *currentSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + "trigger enter");
    }

    private void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //called from animator
    private void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
         Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.TakeDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
       

    }


}
