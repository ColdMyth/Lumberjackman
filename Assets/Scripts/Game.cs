using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TrunkManager trunkManager;
    [SerializeField] GUI gui;
    [SerializeField] ScreenOver screenOver;
    [SerializeField] ParticleSystem speedBoostParticle;
    [SerializeField] ParticleSystem doubleScoreParticle;

    private float totalTime = 5.0f;
    private float currentTime;
    private bool isOver = true;

    // Immortal
    private bool isImmortal = false;
    private float immortalTime = 5.0f;
    private float currentImmortalTime = 0.0f;
    // Double Score
    private bool isDoubleScoreActive = false;
    private float doubleScoreTime = 5.0f;
    private float currentDoubleScoreTime = 0.0f;
    // Score
    private int score = 0;
    private int bestScore = 0;

    public int getScore()
    {
        return score;
    }

    public int getBestScore()
    {
        return bestScore;
    }

    void Start()
    {
        currentTime = totalTime;
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic();
        }
    }

    private void onOver()
    {
        Debug.Log("Öldünüz!");
        isOver = true;
        player.die();
        screenOver.show();

        if (bestScore < score)
        {
            bestScore = score;
        }
        screenOver.show();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopMusic();
        }
    }

    void Update()
    {
        if (isOver) return;

        if (isImmortal)
        {
            currentImmortalTime -= Time.deltaTime;
            if (currentImmortalTime <= 0)
            {
                isImmortal = false;
                player.setImmortal(false);
                speedBoostParticle.Stop();
            }
        }

        if (isDoubleScoreActive)
        {
            currentDoubleScoreTime -= Time.deltaTime;
            if (currentDoubleScoreTime <= 0)
            {
                isDoubleScoreActive = false;
                doubleScoreParticle.Stop();
            }
        }

        currentTime -= Time.deltaTime;
        gui.setBar(currentTime / totalTime);

        if (currentTime <= 0)
        {
            onOver();
        }
    }

    public void OnTap(string direction)
    {
        if (isOver) return;

        player.changeDirection(direction);
        player.showCutAnimation();

        trunkManager.cutFirstTrunk(direction);

        int pointsToAdd = 1;
        if (isDoubleScoreActive)
            pointsToAdd *= 2;

        if (isImmortal || direction != trunkManager.getDirectionFirstTrunk())
        {
            score += pointsToAdd;
            gui.setScore(score);
            currentTime += 0.25f;

            if (currentTime > totalTime)
            {
                currentTime = totalTime;
            }
        }
        else if (!isImmortal)
        {
            onOver();
        }
    }

    public void reset()
    {
        isOver = false;

        score = 0;
        gui.setScore(score);

        currentTime = totalTime;
        gui.setBar(1);

        player.respawn();
        trunkManager.reset();

        gui.gameObject.SetActive(true);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic();
        }
    }

    public void activateImmortality()
    {
        isImmortal = true;
        currentImmortalTime = immortalTime;
        player.setImmortal(true);
        speedBoostParticle.Play();
    }

    public void activateDoubleScore()
    {
        isDoubleScoreActive = true;
        currentDoubleScoreTime = doubleScoreTime;
        doubleScoreParticle.Play();
    }
}
