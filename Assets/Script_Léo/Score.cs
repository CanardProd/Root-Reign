using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public SO_Midlemen midlemen;
    [Header("                                           ---Slider Rouge---")]
    public Slider sliderRed;

    [Header("                                           ---Slider Bleu---")]
    public Slider sliderBlue;

    private void Update()
    {
        sliderRed.value = midlemen.scorePlayer1;
        sliderBlue.value = midlemen.scorePlayer2;
    }
}