using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    private bool isImmortal = false;
    private AudioSource audioSource; // AudioSource referansý
    [SerializeField] private AudioClip cutSound; // Kesme sesi referansý

    void Start()
    {
        m_animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // AudioSource bileþenini alýn
    }

    public void changeDirection(string direction)
    {
        if (direction == "LEFT")
        {
            gameObject.transform.localPosition = new Vector3(-0.1615664f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
        else
        {
            gameObject.transform.localPosition = new Vector3(1.5482664f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
    }

    public void showCutAnimation()
    {
        m_animator.Play("cut_animation", 0, 0);
        PlayCutSound(); // Kesme sesini çal
    }

    public void PlayCutSound()
    {
        if (audioSource != null && cutSound != null)
        {
            audioSource.PlayOneShot(cutSound);
        }
    }

    public void die()
    {
        if (!isImmortal)
        {
            gameObject.transform.Find("RipSprite").gameObject.SetActive(true);
            gameObject.transform.Find("PlayerSprite").gameObject.SetActive(false);

            // Ölme müziðini çal
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Oyun menü müziðini durdur
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.StopMusic();
            }
        }
    }

    public void respawn()
    {
        gameObject.transform.Find("RipSprite").gameObject.SetActive(false);
        gameObject.transform.Find("PlayerSprite").gameObject.SetActive(true);
    }

    public void setImmortal(bool value)
    {
        isImmortal = value;
    }
}