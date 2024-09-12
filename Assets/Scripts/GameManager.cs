
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("FireSettings")]
    [SerializeField] ParticleSystem fireParticle;
    public static int fireNumber;
    GameObject firePoint;
    private int targetFireNumber { get; } = 3;

    [Header("SceneSettings")]
    [SerializeField] Animator sceneAnimator;
    [Space]
    public int transitionTime = 1;

    [Header("AudioClips")]
    [SerializeField] private AudioClip scoreSound;
    [Space]
    [SerializeField] AudioClip onFireSound;


    [Header("LevelText")]
    [SerializeField] TextMeshProUGUI levelText;

    private int levelNumber = 12;

    private void Awake()
    {
        levelText.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex.ToString();
        firePoint = GameObject.FindWithTag("NextLevel");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SaveCurrentLevel()
    {
        int saveCurrentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved Level", saveCurrentLevel);
    }

    private IEnumerator LoadLevel(int level)
    {
        yield return new WaitForSeconds(transitionTime);

        sceneAnimator.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);

    }
    private void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    void NextLevel(bool isNextLevel)
    {
        if (isNextLevel)
        {

            FireCheck(); 
            SaveCurrentLevel();

            if (PlayerPrefs.GetInt("Saved Level") == levelNumber)
            {

                GameObject endGameLevel = GameObject.FindWithTag("EndLevel");
                endGameLevel.GetComponent<EndGame>().EndGamePanel();
                return;
            }

            LoadNextLevel();

        }
        else if (!isNextLevel)
        {
            fireNumber = 0;

            Replay();
        }

    }

    void FireCheck()
    {

        fireNumber++;

        bool isOnFire = (fireNumber == targetFireNumber) ? true : false;

        if (isOnFire)
        {

            SFXController.instance.PlayAudio(onFireSound);
            Instantiate(fireParticle, firePoint.transform.position + Vector3.up, Quaternion.identity);
            fireNumber = 0;

        }
        else
        {
            SFXController.instance.PlayAudio(scoreSound);
        }

    }

    private void OnEnable()
    {
        BallManager.OnScored += NextLevel;
    }
    private void OnDisable()
    {
        BallManager.OnScored -= NextLevel;
    }

}
