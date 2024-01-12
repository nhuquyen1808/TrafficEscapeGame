using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    public static KnifeManager ins;
    public GameObject wheel;
    public Transform point;
    public GameObject knifePref;
    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnKnife();
        }
    }
    public void SpawnKnife()
    {
        GameObject knifeClone = Instantiate(knifePref, point.position, Quaternion.identity);
        knifeClone.GetComponent<Rigidbody2D>().AddForce(transform.up*20, ForceMode2D.Impulse);
    }
}
