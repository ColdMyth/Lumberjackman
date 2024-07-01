using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMenu : MonoBehaviour
{
    [SerializeField] Game game;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void onPlay()
    {
        game.reset();

        gameObject.SetActive(false);
    }
}
