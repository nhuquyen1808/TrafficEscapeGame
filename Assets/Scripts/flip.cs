using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class FlipCardCharacter : MonoBehaviour
{
    public float x, y, z;
    public GameObject cardBack;
    public bool cardBackIsActive;
    public int timer;

    private void Start()
    {
        cardBackIsActive = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartFlip();

        }
    }
    void StartFlip()
    {
        StartCoroutine(CaluclateFlip());
    }
    public void Flip()
    {
        if (cardBackIsActive == true)
        {
            cardBack.SetActive(false);
            cardBackIsActive = false;

        }
        else
        {
            cardBack.SetActive(true);
            cardBackIsActive = true;
        }
    }
    IEnumerator CaluclateFlip()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(x, y, z);
            timer++;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
    }
}


