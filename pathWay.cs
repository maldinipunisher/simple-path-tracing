using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathWay : MonoBehaviour
{
    public Transform[] pathPoint;
    public GameObject ai;
    private Vector3 currentPos, nextPos; 
    int i,a = 0; 

    void Start()
    {
        ai.transform.position = pathPoint[0].position + new Vector3(0, transform.localScale.y  - 0.097f,0 );
        StartCoroutine(newCounter());
    }

    void Update()
    {
        currentPos = ai.transform.position;
        nextPos = pathPoint[a].position;
        Debug.Log(a);

        Vector3 newPos = new Vector3(nextPos.x, nextPos.y + (ai.transform.localScale.y / 1) , nextPos.z);

        ai.transform.position = Vector3.MoveTowards(currentPos,newPos, .1f);
    }

    IEnumerator newCounter()
    {
        for(a = 0; a < pathPoint.Length - 1; a++)
        {
            yield return new WaitForSeconds(1f);
        }
    }

    void OnDrawGizmos()
    {
        for (i = 1; i < pathPoint.Length; i++)
        {
            while(i == pathPoint.Length)
            {
                i = pathPoint.Length - 1 ;
            }
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pathPoint[i - 1].position, pathPoint[i].position);
            Gizmos.DrawSphere(pathPoint[i].position, .1f);
        }

    }

}

