
using UnityEngine;
using UnityEngine.UI;


public abstract class UIManager : MonoBehaviour
{
   
    [SerializeField] Button button;

    protected GameManager gameManager;

    private void OnEnable()
    {
        gameManager=FindObjectOfType<GameManager>();

        button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClicked);  
    }

    protected virtual void OnClicked()
    {
        //all buttons have overridden this function.
    }

}
