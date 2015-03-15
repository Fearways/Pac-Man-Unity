using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmallDot : MonoBehaviour
{
    public Text score;
    public int scoretogive = 1;
    void OnTriggerEnter2D(Collider2D co)
    {

        if (co.name == "Pacman")
        {
            score.text = (int.Parse(score.text) + scoretogive).ToString();
            Destroy(gameObject);
        }
    }
}