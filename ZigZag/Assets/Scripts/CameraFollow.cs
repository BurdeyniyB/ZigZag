using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject myBall;
    Vector3 offset;
    public float Lerp_rate;
    public bool gameOver;

	void Start () {
        offset = myBall.transform.position - transform.position;
        gameOver = false;
	}

	void Update () {
        if (!gameOver)
            Follow();
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = myBall.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, Lerp_rate * Time.deltaTime);
        transform.position = pos;
    }
}
