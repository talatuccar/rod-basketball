using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class StartManager : MonoBehaviour
{
    float buttonLoadingTime=0.3f;
    public float buttonfadeTime=0.25f;


    private int savedLevelNumber { get; set; }



    [SerializeField] List<Button> levelButtons;
    [SerializeField] GameObject levelPanel;

  
    public void CheckLevel()
    {
        if (!PlayerPrefs.HasKey("Saved Level"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            levelPanel.SetActive(true);

            LoadButtons();

        }
    }
   
    void LoadButtons()
    {
        savedLevelNumber = PlayerPrefs.GetInt("Saved Level");

        for (int i = 0; i < levelButtons.Count; i++)
        {

            if (i + 1 <= savedLevelNumber)
            {
                
                int index = i+ 1;
               
                levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text=index.ToString();
                levelButtons[i].onClick.AddListener(delegate { LoadSavedLevel(index); });
                
            }
            else
            {
                levelButtons[i].interactable = false;

            }

        }

        StartCoroutine(ActivateLevel());

    }
    void LoadSavedLevel(int savedLevel)
    {
        SceneManager.LoadScene(savedLevel);
    }
  
    IEnumerator ActivateLevel()
    {
        ResetButtonScale();
        foreach (var item in levelButtons)
        {
           
            item.transform.DOScale(1f, buttonfadeTime).SetEase(Ease.InBounce);

            item.GetComponentInChildren<TextMeshProUGUI>().text = item.gameObject.name;

            yield return new WaitForSeconds(buttonLoadingTime);

        }
    }

    void ResetButtonScale()
    {
        foreach (var item in levelButtons)
        {
            item.transform.localScale= Vector3.zero;
            
        }
    }
   
}
