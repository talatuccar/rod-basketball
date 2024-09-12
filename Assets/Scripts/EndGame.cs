using System.Collections;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endGamePanel;

    int endPanelTime = 1;

    public void EndGamePanel()
    {
        StartCoroutine(EndLevel());
    }
    IEnumerator EndLevel()
    {

        yield return new WaitForSeconds(endPanelTime);
        endGamePanel.SetActive(true);
    }

}
