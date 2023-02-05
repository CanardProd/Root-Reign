using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerDuration = 120f; // Durée du timer en secondes
    private float timerValue;
    public Text timerText;
    public Animator animator;
    public Animator animatorIntro;
    public GameObject audioManager; 
    private bool timerIsRunning = true;
    
    public SO_Midlemen midlemen;
    private static readonly int VictoryBlue = Animator.StringToHash("Victory_Blue");

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
                Debug.Log("fin timer");

                if (midlemen.scorePlayer1 > midlemen.scorePlayer2) // Si le joueur RED Gagne
                {
                    animatorIntro.SetBool("VictoryRed", true);
                    Debug.Log("Red Victory");

                }
                else // si le joueur Bleu gagne
                {
                    animatorIntro.SetBool("VictoryBlue", true);
                    Debug.Log("Blue Victory");

                }
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




