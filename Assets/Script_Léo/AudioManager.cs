using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("                                           ---Mettre l'Audio Ici---")]
    public AudioClip backgroundMusic;
    public AudioClip victorySound;
    public AudioClip fireworkSound;
    public AudioClip alarmSound;
    public AudioClip successSound;
    public AudioClip failureSound;
    public AudioClip deathSound;
    public AudioClip clicSound;

    [Header("                                           ---Audio Listener---")]
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceEffect;

    [Header("                                           ---Volume Music & Volume---")]
    public float musicVolume;
    public float effectVolume;


    private void Start()
    {
        audioSourceMusic.PlayOneShot(backgroundMusic, musicVolume);
    }

    public void PlayVictorySound()
    {
        audioSourceEffect.PlayOneShot(victorySound, effectVolume);
    }

    public void PlayFireworkSound()
    {
        audioSourceEffect.PlayOneShot(fireworkSound, effectVolume);
    }

    public void PlayAlarmSound()
    {
        audioSourceEffect.PlayOneShot(alarmSound, effectVolume);
    }

    public void PlaySuccessSound()
    {
        audioSourceEffect.PlayOneShot(successSound, effectVolume);
    }

    public void PlayFailureSound()
    {
        audioSourceEffect.PlayOneShot(failureSound, effectVolume);
    }

    public void PlayDeathSound()
    {
        audioSourceEffect.PlayOneShot(deathSound, effectVolume);
    }
    public void PlayClicSound()
    {
        //audioSourceEffect.PlayOneShot(clicSound, effectVolume);
    }
}