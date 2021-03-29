using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallStart : MonoBehaviour
{
    public static BallStart instance;
    public float speed = 1.0f;
    public int score;
    public Text scoreDisplay;
    public Text highScore;
    public GameObject trailRenderer;
    public GameObject trailRenderer2;
    public PlayfabManager playfabManager;

    private AudioSource audioSource;
    public AudioClip[] bounce;
    private AudioClip bounceClip;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            playfabManager.SendLeaderboard(score);
            trailRenderer.SetActive(true);
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
            StartCoroutine("HighScoreEffect");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            int index = Random.Range(0, 2);
            bounceClip = bounce[index];
            audioSource.clip = bounceClip;
            audioSource.Play();
            StartCoroutine((BallMove()));
            score++;
            Debug.Log(score);
        }

        else
        {
            score = score + 0;
            /*if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathSoundZone"))
        {
            trailRenderer.SetActive(true);
            bounceClip = bounce[3];
            audioSource.clip = bounceClip;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("KillZone"))
        {
            score = 0;
            Debug.Log(score);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone"))
        {
            score = 0;
            Destroy(this.gameObject);
            Debug.Log(score);
            //GetComponent<Rigidbody>().AddForce(Vector2.up * 10);
            SceneManager.LoadScene("StartScreen");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            StartCoroutine((BallMove2()));
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
        scoreDisplay.text = "0";
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    IEnumerator HighScoreEffect()
    {
        highScore.color = Color.green;
        scoreDisplay.color = Color.green;
        //trailRenderer.SetActive(true);
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator BallMove()
    {
        float adjustedSpeed = speed * 3;
        float adjustedSpeed2 = speed * 4;
        float adjustedSpeed3 = speed * 3;
        float adjustedSpeed4 = speed * 5;
        float adjustedSpeed5 = speed * 6;
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed2);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed3);
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().AddForce(adjustedSpeed * Vector3.up * 1);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed2);
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().AddForce(adjustedSpeed * Vector3.up * 1);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed4);
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed);
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed5);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed2);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(adjustedSpeed * Vector3.up * 1);
        yield return new WaitForSeconds(1);

    }

    public IEnumerator BallMove2()
    {
        float adjustedSpeed = speed * 3;
        float adjustedSpeed2 = speed * 5;
        float adjustedSpeed3 = speed * 4;
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed2);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed2);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(adjustedSpeed * Vector3.up * 1);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed);
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().AddForce(adjustedSpeed * Vector3.up * 1);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().AddForce(Vector2.right * adjustedSpeed);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().AddForce(Vector2.left * adjustedSpeed);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(adjustedSpeed * Vector3.up * 1);
        yield return new WaitForSeconds(1);

    }

}


