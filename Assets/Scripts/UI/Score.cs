using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int scorePerFrame = 1;

    [SerializeField] private GameObject endMenu;
    [SerializeField] private Crosshair crosshair;

    [SerializeField] private GameObject[] stuffToDeactivate;
    [SerializeField] private List<GameObject> cities;
    [SerializeField] public int score = 0;

    public void FixedUpdate()
    {
        cities.RemoveAll(city => city == null);
        score += scorePerFrame * cities.Count;

        if (cities.Count == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        endMenu.transform.GetChild(0).gameObject.SetActive(true);
        crosshair.SetVisible(false);
    }
}
