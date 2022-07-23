using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private GameObject levelEndPanel;
    [SerializeField] private GameObject gamePlayPanel;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI levelEndText;
    [SerializeField] private TextMeshProUGUI pressText;
    [SerializeField] private TextMeshProUGUI cupBallText;

    /*[Header("Buttons")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button tryAgainButton;*/
    PlayerInputActions uiInputActions;

    private void Awake()
    {
       uiInputActions = new PlayerInputActions();
        uiInputActions.UI.Enable();
        GameEvents.INSTANCE.winGame += SetWinGamePanel;
        GameEvents.INSTANCE.looseGame += SetLooseGamePanel;
        GameEvents.INSTANCE.ballToCup += SetCupBallTxt;

    }
    



    private void SetWinGamePanel()
    {
        levelEndPanel.gameObject.SetActive(true);
        levelEndText.text = "LEVEL \n COMPLETED!";
        pressText.text = "Press to continue";
        uiInputActions.UI.PressToContinue.performed += NextButton;
    }
    private void SetLooseGamePanel()
    {
        levelEndPanel.gameObject.SetActive(true);
        levelEndText.text = "LEVEL \n FAILED!";
        pressText.text = "Press to restart";
        uiInputActions.UI.PressToTryAgain.performed += TryAgainButton;
    }
    private void NextButton(InputAction.CallbackContext context)
    {
        Debug.Log("NextLevel");
        levelEndPanel.gameObject.SetActive(false);
        uiInputActions.UI.PressToContinue.performed -= NextButton;
        GameEvents.INSTANCE.StartLevel();
    }
    private void TryAgainButton(InputAction.CallbackContext context)
    {
        Debug.Log("Try Again");
        levelEndPanel.gameObject.SetActive(false);
        uiInputActions.UI.PressToTryAgain.performed -= TryAgainButton;
        GameEvents.INSTANCE.StartLevel();
    }
    private void SetCupBallTxt()
    {
        int levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
        int collectedBall = LevelManager.INSTANCE.currentLevel._ballNumberInTheCup;
        int desiredNumber = LevelConfigurations.Instance.ballNumber[levelNumber];
        cupBallText.text = collectedBall + "/" + desiredNumber;
    }

}
