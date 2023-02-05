using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource backgroundMusic;
    public AudioSource victorySound;
    public AudioSource fireworkSound;
    public AudioSource alarmSound;
    public AudioSource successSound;
    public AudioSource failureSound;
    public AudioSource deathSound;

    private void Start()
    {
        backgroundMusic.Play();
    }

    public void PlayVictorySound()
    {
        victorySound.Play();
    }

    public void PlayFireworkSound()
    {
        fireworkSound.Play();
    }

    public void PlayAlarmSound()
    {
        alarmSound.Play();
    }

    public void PlaySuccessSound()
    {
        successSound.Play();
    }

    public void PlayFailureSound()
    {
        failureSound.Play();
    }

    public void PlayDeathSound()
    {
        deathSound.Play();
    }
}