using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    private Text text;
    private int stars = 0;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        text.text = stars.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        stars += amount;
        text.text = stars.ToString();
        print(amount + "added to display");
    }

}
