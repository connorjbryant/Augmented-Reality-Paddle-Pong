using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleJump : MonoBehaviour
{
    public float speed = 1.0f;
    float touchStartTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            touchStartTime = Time.deltaTime;
        }
        if(Input.GetMouseButtonUp (0))
        {
            float delta = Time.time - touchStartTime;
            float adjustedSpeed = speed * delta;
            GetComponent<Rigidbody>().AddForce(Vector2.up * adjustedSpeed);
        }
    }
}
