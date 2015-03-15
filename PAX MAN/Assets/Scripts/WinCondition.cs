using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour
{
    public GameObject SmallDots;
    public GameObject BigDots;
    public GameObject Wincondition;
    public GameObject pacman;
    public GameObject ghosts;

    // Update is called once per frame
    void Update()
    {
        if (SmallDots.transform.childCount == 0 && BigDots.transform.childCount == 0)
        {
            Wincondition.SetActive(true);
            Destroy(pacman);
            Destroy(ghosts);
        }
    }
}
