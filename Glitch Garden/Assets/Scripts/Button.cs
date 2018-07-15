using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static Defender selectedDefender;
    public Defender defender;
    private SpriteRenderer spriteRenderer;
    private Button[] buttonArray;
	// Use this for initialization
	void Start ()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        //return sprite to normal colour
        foreach(Button button in buttonArray)
        {
            button.spriteRenderer.color = Color.black;
        }
        spriteRenderer.color = Color.white;
        selectedDefender = defender;
        
    }
}
