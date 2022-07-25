using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private GameObject levelEndPanel;
    [SerializeField] private GameObject transitionPanel;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI levelEndText;
    [SerializeField] private TextMeshProUGUI pressText;
    [SerializeField] private TextMeshProUGUI cupBallText;
    [SerializeField] private TextMeshProUGUI levelNumberText;

    [Header("Transition Curve")]
    [SerializeField] private AnimationCurve transitionCurve;
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
        GameEvents.INSTANCE.setLevelTxt += SetLevelNumberTxt;
    }
    



    private void SetWinGamePanel()
    {
        Debug.Log("Win Game Panel");
        levelEndPanel.gameObject.SetActive(true);
        levelEndText.text = "LEVEL \n COMPLETED!";
        pressText.text = "Press to continue";
        uiInputActions.UI.PressToContinue.started += NextButton;
        ParticleManager.INSTANCE._confetti.Play();
        ParticleManager.INSTANCE._snow.Play();
    }
    private void SetLooseGamePanel()
    {
        levelEndPanel.gameObject.SetActive(true);
        levelEndText.text = "LEVEL \n FAILED!";
        pressText.text = "Press to restart";
        uiInputActions.UI.PressToTryAgain.started += TryAgainButton;
    }
    private void NextButton(InputAction.CallbackContext context)
    {
       
        levelEndPanel.gameObject.SetActive(false);
        uiInputActions.UI.PressToContinue.started -= NextButton;
        int levelNumberTxt = PlayerPrefs.GetInt("LevelNumberTxt", 1);
        levelNumberTxt++;
        PlayerPrefs.SetInt("LevelNumberTxt", levelNumberTxt);
        StartCoroutine(MakeTransition());
        
    }
    private void TryAgainButton(InputAction.CallbackContext context)
    {
        
        levelEndPanel.gameObject.SetActive(false);
        uiInputActions.UI.PressToTryAgain.started -= TryAgainButton;
        StartCoroutine(MakeTransition());
       
    }
    private void SetCupBallTxt()
    {
        int levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
        int collectedBall = LevelManager.INSTANCE.currentLevel._ballNumberInTheCup;
        int desiredNumber = LevelConfigurations.Instance.ballNumber[levelNumber];
        cupBallText.text = collectedBall + "/" + desiredNumber;
    }
    private void SetLevelNumberTxt()
    {
        int levelNumberTxt = PlayerPrefs.GetInt("LevelNumberTxt", 1);
        levelNumberText.text = "Level " + levelNumberTxt.ToString();
    }
    private IEnumerator MakeTransition()
    {
        float timeLapse = 0, totaltime = 2.0f;
        Image backgroundImage = transitionPanel.GetComponent<Image>();
        Color transitionColor=Color.black;
        transitionColor.a = 0;
        bool startNewLevel=false;
        while(timeLapse<=totaltime)
        {
            transitionColor.a = transitionCurve.Evaluate(timeLapse / totaltime);
            backgroundImage.color = transitionColor;
            timeLapse += Time.deltaTime;
            if(timeLapse/totaltime>=0.5f && !startNewLevel)
            {
                GameEvents.INSTANCE.StartLevel();
                startNewLevel = true;
            }
            yield return null;
        }
        ParticleManager.INSTANCE._confetti.Stop();
    }

}
