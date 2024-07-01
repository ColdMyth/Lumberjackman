using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOver : MonoBehaviour
{
    [SerializeField] Text txtScore;
    [SerializeField] Game game;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void onReplay()
    {
        game.reset();
        hide();
    }
    public void show()
    {
        txtScore.text = game.getScore() + "";

        gameObject.SetActive(true);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
}
