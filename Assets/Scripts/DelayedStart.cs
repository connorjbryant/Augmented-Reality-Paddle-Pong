using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    public GameObject countDown;

    public void Start()
    {
        StartCoroutine("StartDelay");
    }

    public void Update()
    {

    }

    public void StartAnimation()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        GameObject.FindWithTag("Ball").GetComponent<BallStart>().enabled = false;
        float pauseTime = Time.realtimeSinceStartup + 7f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
        GameObject.FindWithTag("Ball").GetComponent<BallStart>().enabled = true;
    }
}
