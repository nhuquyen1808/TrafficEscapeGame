using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotz;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateWing();

    }

    public void RotateWing()
    {
        rotz += 200 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }

    public void SetRotateTarget()
    {

    }
}
