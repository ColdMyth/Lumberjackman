using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public GameObject leftTutorial;
    public GameObject rightTutorial;
    public float displayDuration = 1.0f;

    void Start()
    {
        StartCoroutine(DisplayTutorials());
    }

    IEnumerator DisplayTutorials()
    {
        while (true)
        {
            leftTutorial.SetActive(true);
            rightTutorial.SetActive(false);
            yield return new WaitForSeconds(displayDuration);

            leftTutorial.SetActive(false);
            rightTutorial.SetActive(true);
            yield return new WaitForSeconds(displayDuration);
        }
    }
}
