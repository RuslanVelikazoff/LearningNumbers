using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panelObject;

    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button exitButton;

    private AnimationUI animations = new AnimationUI();

    private void Start()
    {
        ButtonClickAction();
    }

    public void OpenPanel()
    {
        AudioManager.Instance.PlaySound("Lose");
        animations.OpenPanel(panelObject, losePanel);
    }

    private void ButtonClickAction()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlaySound("Click");
                SceneManager.LoadScene(1);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlaySound("Click");
                SceneManager.LoadScene(0);
            });
        }
    }
}
