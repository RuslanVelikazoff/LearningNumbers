using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panelObject;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button exitButton;

    private AnimationUI animations = new AnimationUI();

    private void Start()
    {
        ButtonClickAction();
    }

    public void OpenPanel()
    {
        AudioManager.Instance.PlaySound("Win");
        animations.OpenPanel(panelObject, winPanel);
    }

    private void ButtonClickAction()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
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
