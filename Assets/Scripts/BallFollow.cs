using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    GameObject target;
    float speed;
    public Transform Player;
    public Transform target2;

    void Start()
    {
        speed = 3f;
        target = GameObject.Find("Paddle");
    }

    void Update()
    {

        Vector3 lookVector = Player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Random.Range(5, 20) * Time.deltaTime);

    }
}
