using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterManager : MonoBehaviour
{
    public enum BoostType
    {
        None,
        SpeedBoost,
        DoubleScore,
    }

    public BoostType boostType;

    public void ApplyBoostEffect()
    {
        Game gameController = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<Game>();
        if (gameController != null)
        {
            switch (boostType)
            {
                case BoostType.SpeedBoost:
                    gameController.activateImmortality();
                    break;

                case BoostType.DoubleScore:
                    gameController.activateDoubleScore();
                    break;

                default:
                    break;
            }
        }
    }
}
