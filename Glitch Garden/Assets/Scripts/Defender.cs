using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Defender : MonoBehaviour {
    private Animator anim;
    private float currentSpeed;
    private GameObject currentTarget;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + "trigger enter");
    }

    private void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        Debug.Log(obj);
        currentTarget = obj;
    }
}
