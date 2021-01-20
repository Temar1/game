﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPatrolRL : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform point1;
    public Transform point2;
    public float speed;
    public float waitTime;
    bool canGo = true;

    // Start is called before the first frame update
    void Start()
    {
      
 
            transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (canGo)
            transform.position = Vector3.MoveTowards(transform.position, point2.position, speed * Time.deltaTime);
        if (transform.position == point2.position)
        {
            Transform t;
            t = point1;
            point1 = point2;
            point2 = t;

            canGo = false;
            StartCoroutine(waiting());
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(waitTime);
        if (transform.rotation.y == 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
        canGo = true;
    }
}