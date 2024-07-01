using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] string direction;
    [SerializeField] Game game;

    void OnMouseDown()
    {
        game.OnTap(direction);
        Debug.Log("Tap " + direction);
    }
}
