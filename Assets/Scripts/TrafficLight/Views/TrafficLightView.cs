
using UnityEngine;
using System.Collections;

public class TrafficLightView : UIBase
{
    [SerializeField] LightView m_redLight;
    [SerializeField] LightView m_yellowLight;
    [SerializeField] LightView m_greenLight;

    [SerializeField] float m_lightDuration = 5f;

    readonly Color m_disabledColor = Color.gray;

    void Start()
    {
        StartCoroutine(runTrafficLight());
    }

    IEnumerator runTrafficLight()
    {
        while (true)
        {
            yield return runLight(m_redLight, Color.red);

            yield return runLight(m_yellowLight, Color.yellow);

            yield return runLight(m_greenLight, Color.green);
        }
    }

    IEnumerator runLight(LightView activeLight, Color activeColor)
    {
        float remainingTime = m_lightDuration;

        while (remainingTime > 0f)
        {
            setLight(activeLight, activeColor, Mathf.CeilToInt(remainingTime).ToString());

            float waitTime = Mathf.Min(1f, remainingTime);
            yield return new WaitForSeconds(waitTime);
            remainingTime -= waitTime;
        }
    }

    void setLight(LightView activeLight, Color activeColor, string secondText)
    {
        resetLight(m_redLight);
        resetLight(m_yellowLight);
        resetLight(m_greenLight);

        activeLight.SetColor(activeColor);
        activeLight.SetSecond(secondText);
    }

    void resetLight(LightView light)
    {
        light.SetColor(m_disabledColor);
        light.SetSecond(string.Empty);
    }
}
