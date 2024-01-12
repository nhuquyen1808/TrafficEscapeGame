using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider health;
    public Slider energy;
    public Slider exp;
    //public Gradient gradient;
    public Image healthFill;
    public Image energyFill;
    public Image expFill;

    private void Start()
    {
    }

    private void Update()
    {
        
    }
    public void SetMaxHealth(int health)
    {
        this.health.maxValue = health;
        this.health.value = health;
        //gradient.Evaluate(1f);
    }

    public void SetMaxExp(int exp)
    {
        this.exp.maxValue = exp;
        this.exp.value = exp;
    }
    public void SetHealth(int health)
    {
        this.health.value = health;
       // fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
