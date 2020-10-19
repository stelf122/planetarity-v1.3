using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlanetView : MonoBehaviour
{
    [SerializeField] private Image _enemyLine;

    [SerializeField] private Slider _health;
    [SerializeField] private Slider _cooldown;

    [SerializeField] private TMP_Text _healthLabel;
    [SerializeField] private TMP_Text _cooldownLabel;

    private RectTransform RectTransform => (RectTransform)transform;

    public void SetPosition(Vector2 position)
    {
        RectTransform.anchoredPosition = position;
    }

    public void SetMark(bool isPlayer)
    {
        _enemyLine.gameObject.SetActive(!isPlayer);
    }

    public void SetHealth(float value, float maxValue)
    {
        _health.value = value / maxValue;

        _healthLabel.text = $"{value.ToString("0")} / {maxValue.ToString("0")}";
    }

    public void SetCooldown(float value, float maxValue)
    {
        _cooldown.value = value / maxValue;

        _cooldownLabel.text = value.ToString("0.0");
    }
}
