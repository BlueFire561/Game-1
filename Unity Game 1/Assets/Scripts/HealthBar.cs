using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public float MaxValue;
    public float Value;

    private float fillAmount;

    public Image image;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        fillAmount = Value / MaxValue;

        image.fillAmount = fillAmount;
	}
}
