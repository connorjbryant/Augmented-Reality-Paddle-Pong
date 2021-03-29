using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleRotate : MonoBehaviour
{
    public Transform PaddleEdge;
    float rotSpeed = 20;
    float moveSpeed = 20;

    void Start()
    {
        //StartCoroutine(PaddleMove());
    }

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, -rotY);
    }

    void OnMouseDown()
    {
        float rotX = Input.GetAxis("Mouse X") * moveSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * moveSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, -rotY);
    }

    public IEnumerator PaddleMove()
    {
        PaddleEdge.transform.eulerAngles = new Vector3(80, 0, 0);
        yield return new WaitForSeconds(0.2f);
        PaddleEdge.transform.eulerAngles = new Vector3(90, 0, 0);
    }
}
