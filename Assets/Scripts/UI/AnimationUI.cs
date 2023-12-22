using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationUI
{
    [SerializeField]
    private float timePanelAnimation = .5f;
    [SerializeField]
    private float timeButtonAnimation = .3f;

    public void OpenPanel(GameObject panel, GameObject image)
    {
        Sequence sequence = DOTween.Sequence();

        panel.SetActive(true);
        image.SetActive(true);

        sequence.Append(image.transform.DOScale(new Vector3(1.2f, 1.2f, 1f), timePanelAnimation))
            .Append(image.transform.DOScale(new Vector3(1f, 1f, 1f), timePanelAnimation));
    }

    public void Click(Button button)
    {
        Sequence sequence = DOTween.Sequence();

        AudioManager.Instance.Play("Click");

        sequence.Append(button.transform.DOScale(new Vector3(.8f, .8f, 1f), timeButtonAnimation))
            .Append(button.transform.DOScale(new Vector3(1f, 1f, 1f), timeButtonAnimation));
    }
}
