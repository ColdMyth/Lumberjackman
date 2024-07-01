using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
    public string direction;

    private float target;
    private float velocity;
    private float totalTime = 0.5f;
    private float currentTime = 0;

    private bool isAnimate = false;

    void Update()
    {
        if (!isAnimate) return;
        UpdatePositionAndRotation(Time.deltaTime);
        CheckAnimationEnd();
    }
    

    public void onAnimateDestroy(string _directionPlayer)
    {
        target = (_directionPlayer == "RIGHT") ? -5 : 5;
        velocity = (target - gameObject.transform.localPosition.x) / totalTime;
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - 1);
        currentTime = 0;
        isAnimate = true;
    }
    void UpdatePositionAndRotation(float deltaTime)
    {
        float newPositionX = gameObject.transform.localPosition.x + (velocity * deltaTime);
        gameObject.transform.localPosition = new Vector3(newPositionX, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        gameObject.transform.Rotate(Vector3.forward, 150f * deltaTime, Space.Self);
    }

    void CheckAnimationEnd()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= totalTime)
        {
            Destroy(gameObject);
            isAnimate = false;
        }
    }
}
