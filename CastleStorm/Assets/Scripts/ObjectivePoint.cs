using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePoint : MonoBehaviour {

    public int life = 10;
    
    public Text lifeDisplay;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        lifeDisplay.text = life.ToString();
    }

    public void Damage(int damage) {
        if (life > 0)
            life -= damage;
    }
}
