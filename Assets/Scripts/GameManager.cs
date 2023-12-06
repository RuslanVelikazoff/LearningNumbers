using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text exerciseText;

    [SerializeField]
    private Button[] numberButton;

    [SerializeField]
    private string[] exerciseString;

    private int exercise;

    [SerializeField]
    private WinPanel winPanel;
    [SerializeField]
    private LosePanel losePanel;

    private void Start()
    {
        RandomExercise();

        SetExerciseText(exercise);

        SetButtonAction(0, exercise);
        SetButtonAction(1, exercise);
        SetButtonAction(2, exercise);
        SetButtonAction(3, exercise);
        SetButtonAction(4, exercise);
        SetButtonAction(5, exercise);
        SetButtonAction(6, exercise);
        SetButtonAction(7, exercise);
        SetButtonAction(8, exercise);
        SetButtonAction(9, exercise);
    }

    private void RandomExercise()
    {
        exercise = Random.Range(0, 9);

        if (exercise == PlayerPrefs.GetInt("Exercise"))
        {
            RandomExercise();
        }
        else
        {
            PlayerPrefs.SetInt("Exercise", exercise);
        }
    }

    private void SetExerciseText(int index)
    {
        exerciseText.text = exerciseString[index];
    }

    private void SetButtonAction(int index, int exercise)
    {
        if (numberButton[index] != null)
        {
            numberButton[index].onClick.RemoveAllListeners();
            numberButton[index].onClick.AddListener(() =>
            {
                if (index == exercise)
                {
                    winPanel.OpenPanel();
                    Debug.Log("Win");
                }
                else
                {
                    losePanel.OpenPanel();
                    Debug.Log("Lose");
                }
            });
        }
    }
}
