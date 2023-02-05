using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerDuration = 120f; // Durée du timer en secondes
    private float timerValue;
    public Text timerText;
    public Animator animator;
    public GameObject audioManager; 
    private bool timerIsRunning = true;
    
    public SO_Midlemen midlemen;

    private void Start()
    {
        timerValue = timerDuration;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            timerValue -= Time.deltaTime;
            midlemen.timer = timerValue;
            int minutes = Mathf.FloorToInt(timerValue / 60);
            int seconds = Mathf.FloorToInt(timerValue % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timerValue <= 30f && !animator.GetBool("lastSecond"))
            {
                animator.SetBool("lastSecond", true);
            }

            if (timerValue <= 1f && !animator.GetBool("endChrono"))
            {
                timerIsRunning = false;
                animator.SetBool("endChrono", true);
                audioManager.GetComponent<AudioManager>().PlayAlarmSound();
                Invoke("waitFirework", 2f);
                // Déclenchez l'événement "game over" ici
            }
        }
    }
    private void waitFirework()
    {
        audioManager.GetComponent<AudioManager>().PlayVictorySound();
        audioManager.GetComponent<AudioManager>().PlayFireworkSound();
    }
}




