using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITest 
{
    void ShowSound();
}


public class TestInterFace : MonoBehaviour
{

    tesstInterFace ts = new tesstInterFace();
    /*void ShowSound()
    {
        Debug.Log("aaaaa");
    }*/
    private void Start()
    {
        ts.     ShowSound();
    }
}
