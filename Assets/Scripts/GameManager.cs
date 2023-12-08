using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button[] numberButton;
    [SerializeField]
    private Text[] numberText;

    [Space(7)]

    [SerializeField]
    private GameObject[] animal;
    [SerializeField]
    private GameObject[] bears;
    [SerializeField]
    private GameObject[] foxes;
    [SerializeField]
    private GameObject[] hedgehogs;
    [SerializeField]
    private GameObject[] rabbits;
    [SerializeField]
    private GameObject[] squirrels;

    [Space(7)]

    [SerializeField]
    private WinPanel winPanel;
    [SerializeField]
    private LosePanel losePanel;

    private int correctButton;

    private int randomNumber;
    private int randomAnimal;

    private string text1;
    private string text2;

    private AnimationUI animations = new AnimationUI();

    private void Awake()
    {
        SetCorrectRandomButton();
        SetRandomAnimal();
        SetRandomNumber();
    }

    private void Start()
    {
        SetAnimal();
        TextCorrected();
        SetButtonText();
        ButtonClickAction();
    }

    private void SetRandomNumber()
    {
        if (!PlayerPrefs.HasKey("RandomNumber"))
        {
            randomNumber = Random.Range(1, 10);
            PlayerPrefs.SetInt("RandomNumber", randomNumber);
        }
        else
        {
            randomNumber = Random.Range(1, 10);

            if (randomNumber == PlayerPrefs.GetInt("RandomNumber"))
            {
                SetRandomNumber();
            }
            else
            {
                PlayerPrefs.SetInt("RandomNumber", randomNumber);
            }
        }
    }

    private void SetRandomAnimal()
    {
        if (!PlayerPrefs.HasKey("RandomAnimal"))
        {
            randomAnimal = Random.Range(0, animal.Length - 1);
            PlayerPrefs.SetInt("RandomAnimal", randomAnimal);
        }
        else
        {
            randomAnimal = Random.Range(0, animal.Length - 1);

            if (randomAnimal == PlayerPrefs.GetInt("RandomAnimal"))
            {
                SetRandomAnimal();
            }
            else
            {
                PlayerPrefs.SetInt("RandomAnimal", randomAnimal);
            }
        }
    }

    private void SetCorrectRandomButton()
    {
        if (!PlayerPrefs.HasKey("RandomCorrect"))
        {
            correctButton = Random.Range(0, numberButton.Length - 1);
            PlayerPrefs.SetInt("RandomCorrect", correctButton);
        }
        else
        {
            correctButton = Random.Range(0, numberButton.Length - 1);

            if (correctButton == PlayerPrefs.GetInt("RandomCorrect"))
            {
                SetCorrectRandomButton();
            }
            else
            {
                PlayerPrefs.SetInt("RandomCorrect", correctButton);
            }
        }
    }

    private void SetAnimal()
    {
        switch (randomAnimal)
        {
            case 0:
                //Bears
                Debug.Log($"{randomAnimal} Bears is spawned: {randomNumber}");

                for (int i = 0; i < animal.Length - 1; i++)
                {
                    if (i == randomAnimal)
                    {
                        animal[i].SetActive(true);
                    }
                    else
                    {
                        animal[i].SetActive(false);
                    }
                }

                for (int i = 0; i < randomNumber; i++)
                {
                    bears[i].SetActive(true);
                }
                break;

            case 1:
                //Foxes
                Debug.Log($"{randomAnimal} Foxes is spawned: {randomNumber}");

                for (int i = 0; i < animal.Length - 1; i++)
                {
                    if (i == randomAnimal)
                    {
                        animal[i].SetActive(true);
                    }
                    else
                    {
                        animal[i].SetActive(false);
                    }
                }

                for (int i = 0; i < randomNumber; i++)
                {
                    foxes[i].SetActive(true);
                }
                break;

            case 2:
                //Hedgehogs
                Debug.Log($"{randomAnimal} Hedgehogs is spawned: {randomNumber}");

                for (int i = 0; i < animal.Length - 1; i++)
                {
                    if (i == randomAnimal)
                    {
                        animal[i].SetActive(true);
                    }
                    else
                    {
                        animal[i].SetActive(false);
                    }
                }

                for (int i = 0; i < randomNumber; i++)
                {
                    hedgehogs[i].SetActive(true);
                }
                break;

            case 3:
                //Rabbits
                Debug.Log($"{randomAnimal} Rabbits is spawned: {randomNumber}");

                for (int i = 0; i < animal.Length - 1; i++)
                {
                    if (i == randomAnimal)
                    {
                        animal[i].SetActive(true);
                    }
                    else
                    {
                        animal[i].SetActive(false);
                    }
                }

                for (int i = 0; i < randomNumber; i++)
                {
                    rabbits[i].SetActive(true);
                }
                break;

            case 4:
                //Squirrels
                Debug.Log($"{randomAnimal} Squirrels is spawned: {randomNumber}");

                for (int i = 0; i < animal.Length - 1; i++)
                {
                    if (i == randomAnimal)
                    {
                        animal[i].SetActive(true);
                    }
                    else
                    {
                        animal[i].SetActive(false);
                    }
                }

                for (int i = 0; i < randomNumber; i++)
                {
                    squirrels[i].SetActive(true);
                }
                break;
        }
    }

    private void SetButtonText()
    {
        switch (correctButton)
        {
            case 0:
                numberText[0].text = randomNumber.ToString();
                numberText[1].text = text1;
                numberText[2].text = text2;
                break;

            case 1:
                numberText[0].text = text1;
                numberText[1].text = randomNumber.ToString();
                numberText[2].text = text2;
                break;

            case 2:
                numberText[0].text = text1;
                numberText[1].text = text2;
                numberText[2].text = randomNumber.ToString();
                break;
        }
    }

    private void TextCorrected()
    {
        if (randomNumber - 1 <= 0 || randomNumber - 2 <= 0)
        {
            text1 = (randomNumber + Random.Range(1, 2)).ToString();
            text2 = (randomNumber + Random.Range(3, 4)).ToString();
        }
        else if (randomNumber + 1 >= 10 || randomNumber + 2 >= 10)
        {
            text1 = (randomNumber - Random.Range(1, 2)).ToString();
            text2 = (randomNumber - Random.Range(3, 4)).ToString();
        }
        else
        {
            text1 = (randomNumber - Random.Range(1, 2)).ToString();
            text2 = (randomNumber + Random.Range(1, 2)).ToString();
        }
    }

    private void ButtonClickAction()
    {
        switch (correctButton)
        {
            case 0:
                Debug.Log("Correct button index " + correctButton);

                //Buttons funcion
                if (numberButton[0] != null)
                {
                    numberButton[0].onClick.RemoveAllListeners();
                    numberButton[0].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[0]);

                        winPanel.OpenPanel();
                    });
                }
                if (numberButton[1] != null)
                {
                    numberButton[1].onClick.RemoveAllListeners();
                    numberButton[1].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[1]);

                        losePanel.OpenPanel();
                    });
                }
                if (numberButton[2] != null)
                {
                    numberButton[2].onClick.RemoveAllListeners();
                    numberButton[2].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[2]);

                        losePanel.OpenPanel();
                    });
                }
                break;

            case 1:
                Debug.Log("Correct button index " + correctButton);

                //Buttons funcion
                if (numberButton[0] != null)
                {
                    numberButton[0].onClick.RemoveAllListeners();
                    numberButton[0].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[0]);

                        losePanel.OpenPanel();
                    });
                }
                if (numberButton[1] != null)
                {
                    numberButton[1].onClick.RemoveAllListeners();
                    numberButton[1].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[1]);

                        winPanel.OpenPanel();
                    });
                }
                if (numberButton[2] != null)
                {
                    numberButton[2].onClick.RemoveAllListeners();
                    numberButton[2].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[2]);

                        losePanel.OpenPanel();
                    });
                }
                break;

            case 2:
                Debug.Log("Correct button index " + correctButton);

                //Buttons funcion
                if (numberButton[0] != null)
                {
                    numberButton[0].onClick.RemoveAllListeners();
                    numberButton[0].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[0]);

                        losePanel.OpenPanel();
                    });
                }
                if (numberButton[1] != null)
                {
                    numberButton[1].onClick.RemoveAllListeners();
                    numberButton[1].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[1]);

                        losePanel.OpenPanel();
                    });
                }
                if (numberButton[2] != null)
                {
                    numberButton[2].onClick.RemoveAllListeners();
                    numberButton[2].onClick.AddListener(() =>
                    {
                        animations.Click(numberButton[2]);

                        winPanel.OpenPanel();
                    });
                }
                break;
        }
    }

}
