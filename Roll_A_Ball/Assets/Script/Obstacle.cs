using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float ran1, ran2;
    private void Start()
    {
        ran1 = Random.Range(-8.5f, 8.5f);
        ran2 = Random.Range(-8.5f, 8.5f);
        transform.position = new Vector3(ran1, 0.5f, ran2);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
