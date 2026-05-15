using System;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightView : UIBase, ITrafficLightView
{
    [SerializeField] Button m_closeButton;
    [SerializeField] LightView m_redLight;
    [SerializeField] LightView m_yellowLight;
    [SerializeField] LightView m_greenLight;

    readonly Color m_disabledColor = Color.gray;

    void Awake()
    {
        m_closeButton.onClick.AddListener(onClose);
    }

    public event Action OnCloseRequested;

    void onClose()
    {
        OnCloseRequested?.Invoke();
    }

    public void SetLight(TrafficLightPhase phase, string second)
    {
        resetAllLights();

        (LightView light, Color color) = phaseToLight(phase);
        light.SetColor(color);
        light.SetSecond(second);
    }

    (LightView, Color) phaseToLight(TrafficLightPhase phase) => phase switch
    {
        TrafficLightPhase.Red    => (m_redLight,    Color.red),
        TrafficLightPhase.Yellow => (m_yellowLight,  Color.yellow),
        TrafficLightPhase.Green  => (m_greenLight,  Color.green),
        _ => throw new ArgumentOutOfRangeException(nameof(phase))
    };

    void resetAllLights()
    {
        resetLight(m_redLight);
        resetLight(m_yellowLight);
        resetLight(m_greenLight);
    }

    void resetLight(LightView light)
    {
        light.SetColor(m_disabledColor);
        light.SetSecond(string.Empty);
    }
}
