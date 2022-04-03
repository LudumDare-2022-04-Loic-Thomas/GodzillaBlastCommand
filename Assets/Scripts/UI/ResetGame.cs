using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public Crosshair crosshair;

    private void Start()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }

    public void ResetGameToDefault()
    {
        SceneManager.LoadScene("GameScene");
        crosshair.SetVisible(true);
        transform.parent.parent.gameObject.SetActive(false);
    }
}
