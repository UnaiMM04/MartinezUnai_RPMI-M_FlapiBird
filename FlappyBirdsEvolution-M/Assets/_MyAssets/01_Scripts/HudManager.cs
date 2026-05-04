using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text msgText;


    //Método público que actualica la barra de salud, lo llamaremos desde el PlayerManager
    public void UpdateHealth(int health)
    {
        healthSlider.value = health;
        healthText.text = health.ToString();
    }

    //Método público que actualica las vidas, lo llamaremos desde el PlayerManager
    public void UpdateLives(int lives)
    {
        livesText.text = lives.ToString();
    }

    public void PrintMessage(string message)
    {
        msgText.text = message;
    }

}
