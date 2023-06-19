using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private TMP_Text levelCounterText;
    private int sceneIndex = 0;

    private void OnEnable()
    {
        MainMenuButton.OnMainMenuScene += GoToMainMenu;
        RestartButton.OnRestartButtonClick += RestartLevel;
        NextLevelButton.OnNextLevelButton += GoToNextLevel;
    }
    private void OnDisable()
    {
        MainMenuButton.OnMainMenuScene -= GoToMainMenu;
        NextLevelButton.OnNextLevelButton -= GoToNextLevel;
        RestartButton.OnRestartButtonClick -= RestartLevel;

    }
    private void Awake()
    {
        levelCounterText=GameObject.FindGameObjectWithTag("LevelCounterText").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        levelCounterText.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex.ToString();
        StartCoroutine(DisableLevelText());
    }

    private void GoToMainMenu()
    {
        sceneIndex = 0;
        SceneManager.LoadScene(sceneIndex);
    }
    private void RestartLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    private void GoToNextLevel()
    {
        sceneIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        if (sceneIndex == 5)
        {
            sceneIndex = 0;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private IEnumerator DisableLevelText()
    {
        yield return new WaitForSeconds(1f);
        levelCounterText.gameObject.transform.DOScale(0, 0.5f);
    }

   
}
