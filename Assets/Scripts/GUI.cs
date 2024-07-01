using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] Text txtScore;
    [SerializeField] Image barRed;

    public void setScore(int value)
    {
        txtScore.text = value + "";
    }

    public void setBar(float percent)
    {
        percent = Mathf.Clamp01(percent);

        float total = 179.2f;
        float p = total - (percent * total);
        barRed.transform.localPosition = new Vector3(0.2f - p, barRed.transform.localPosition.y, barRed.transform.localPosition.z);
    }
}
