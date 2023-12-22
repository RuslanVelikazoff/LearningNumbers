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

    public InterstitialAds ad;

    private void Start()
    {
        ButtonClickAction();
    }

    public void OpenPanel()
    {
        AudioManager.Instance.Play("Lose");
        animations.OpenPanel(panelObject, losePanel);
    }

    private void ButtonClickAction()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                ad.ShowAd();
                SceneManager.LoadScene(1);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                SceneManager.LoadScene(0);
            });
        }
    }
}
