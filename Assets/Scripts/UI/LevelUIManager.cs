using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Button restartButton;

    [Space(7)]

    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private GameObject settingsPanel;

    [Space(7)]

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite musicOnSprite;
    [SerializeField]
    private Sprite musicOffSprite;

    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOffSprite;

    private AnimationUI animations = new AnimationUI();

    private void Start()
    {
        ButtonClickAction();

        SetSprites();
    }

    private void ButtonClickAction()
    {
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlaySound("Click");
                SceneManager.LoadScene(1);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                animations.Click(settingsButton);

                if (settingsPanel.activeInHierarchy)
                {
                    settingsPanel.SetActive(false);
                }
                else
                {
                    settingsPanel.SetActive(true);
                }
            });
        }
        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                animations.Click(musicButton);

                if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
                {
                    AudioManager.Instance.OffMusic();
                }
                else
                {
                    AudioManager.Instance.OnMusic();
                }

                SetSprites();
            });
        }
        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                animations.Click(soundButton);

                if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
                {
                    AudioManager.Instance.OffSounds();
                }
                else
                {
                    AudioManager.Instance.OnSounds();
                }

                SetSprites();
            });
        }
    }

    private void SetSprites()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
    }
}
