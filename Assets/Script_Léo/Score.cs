using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("                                           ---Slider Rouge---")]
    public Slider sliderRed;
    public int scoreRed = 100;

    [Header("                                           ---Slider Bleu---")]
    public Slider sliderBlue;
    public int scoreBlue = 50;

    private void Update()
    {
        sliderRed.value = scoreRed;
        sliderBlue.value = scoreBlue;
    }
}