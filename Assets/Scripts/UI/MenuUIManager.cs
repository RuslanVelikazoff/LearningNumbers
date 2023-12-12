using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [Space(7)]

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite musicOnSprite;
    [SerializeField]
    private Sprite musicOffSprite;

    [Space(7)]

    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOffSprite;

    [Space(7)]

    [SerializeField]
    private Text recordText;

    private AnimationUI animations = new AnimationUI();

    private void Start()
    {
        SetSprites();
        SetRecordText();

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
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

    private void SetRecordText()
    {
        if (!PlayerPrefs.HasKey("Record"))
        {
            PlayerPrefs.SetInt("Record", 0);
            recordText.text = "Рекорд: " + PlayerPrefs.GetInt("Record").ToString();
        }
        else
        {
            recordText.text = "Рекорд: " + PlayerPrefs.GetInt("Record").ToString();
        }
    }
}
