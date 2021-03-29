using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Transform PaddleEdge;
    public float speed = 1.5f;
    float touchStartTime = 0f;
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartTime = Time.time;
            animator.SetTrigger("flipTrigger");

        }
        if(Input.GetMouseButtonUp(0))
        {
            float delta = Time.time - touchStartTime;
            float adjustedSpeed = speed * delta;
        }

    }

    public IEnumerator PaddleMove()
    {
        PaddleEdge.transform.eulerAngles = new Vector3(80, 0, 0);
        yield return new WaitForSeconds(0.2f);
        PaddleEdge.transform.eulerAngles = new Vector3(90, 0, 0);
    }

    public IEnumerator PaddleMove2()
    {
        PaddleEdge.transform.eulerAngles = new Vector3(70, 0, 0);
        yield return new WaitForSeconds(0.2f);
        PaddleEdge.transform.eulerAngles = new Vector3(90, 0, 0);
    }
}
