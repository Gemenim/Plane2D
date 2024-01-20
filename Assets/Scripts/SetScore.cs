using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SetScore : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scorCounter;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scorCounter.ChangingScore += SetAccount;
    }

    private void OnDisable()
    {
        _scorCounter.ChangingScore -= SetAccount;
    }

    private void SetAccount(int score)
    {
        _text.text = score.ToString();
    }
}
