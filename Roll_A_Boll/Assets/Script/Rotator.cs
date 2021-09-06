using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float ran1, ran2;
    private void Start()
    {
        ran1 = Random.Range(-9f, 9f);
        ran2 = Random.Range(-9f, 9f);
        transform.position = new Vector3(ran1, 0.5f, ran2);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
