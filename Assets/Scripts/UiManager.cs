
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiManager : MonoBehaviour
{
    public GameObject goldBar;
    public GameObject iconCoin;
    public Vector3 desCoin;

    public static UiManager ins;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        desCoin = Camera.main.ScreenToWorldPoint(transform.position);
    }

}
