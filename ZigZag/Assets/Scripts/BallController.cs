using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;
    public GameObject storeButton;

    [SerializeField] private float speed;
    [SerializeField] private float fallSpeed;
    private bool started;
    private bool gameOver;

    private int LoadAuto;
    private Rigidbody rb;

    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject closet;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Start () {
        started = false;
        gameOver = false;
	}

	void Update()
	{
      InGame();

      LoadAuto = PlayerPrefs.GetInt("AutoMode");

      if(LoadAuto == 1 && started)
      {
          enemy = GameObject.FindGameObjectsWithTag("Obstacle");
          DistanceForAuto();
          AutoDirection();
      }
	}

    void DistanceForAuto()
    {
    float distance = Mathf.Infinity;
    Vector3 positionS = transform.position;
      foreach(GameObject go in enemy)
      {
         // Vector3 diff = go.transform.position - position;
        //float curDistance = diff.sqrMagnitude;
          float curDistance = Vector3.Distance(go.transform.position, positionS);
          if(curDistance < distance)
          {
              distance = curDistance;
              closet = go;
          }
      }
    }

	void InGame()
	{
	        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))
            {
                gameOver = true;
                rb.velocity = new Vector3(0, -fallSpeed, 0);
                Destroy(gameObject, 1.0f);

                Camera.main.GetComponent<CameraFollow>().gameOver = true;

                GameManager.instance.GameOver();
            }
	}

	public void Touch () {
        if (!started)
        {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.GameStart();
                UiManager.instance.ActiveGameScore();

                PlayerPrefs.SetInt("Ball", 1);

                storeButton.SetActive(false);
        }
      if(LoadAuto == 0)
      {
        if (!gameOver)
        {
            SwitchDirections();
            ScoreManager.instance.IncrementScore();
            PlayerPrefs.SetInt("Ball", 1);

        }
       }
	}

    void SwitchDirections()
    {
        if (rb.velocity.z > 0)
            rb.velocity = new Vector3(speed, 0, 0);
        else if (rb.velocity.x > 0)
            rb.velocity = new Vector3(0, 0, speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1.0f);
            ScoreManager.instance.DiamondScore();

            PlayerPrefs.SetInt("DiamondSound", 1);
        }

        if (col.gameObject.tag == "CubeObstacle")
        {
         if(LoadAuto == 1 && started)
         {
         Debug.Log("Destroy position = " + col.gameObject.transform.position);
         Destroy(col.gameObject);
         closet.tag = "Untagged";
         closet = null;
         }
        }
    }

    void AutoDirection()
    {
      if(closet != null)
      {
       if(closet.transform.position.x >= transform.position.x)
          rb.velocity = new Vector3(speed, 0, 0);
       else if (closet.transform.position.z >= transform.position.z)
          rb.velocity = new Vector3(0, 0, speed);
       if (closet.transform.position.x == transform.position.x && closet.transform.position.z == transform.position.z)
       {
         //closet.tag = "Untagged";
       }
      }
    }
}
