
using UnityEngine;
using System.Collections;

public class TrafficLightView : MonoBehaviour
{
    [SerializeField] LightView RedLight;
    [SerializeField] LightView YellowLight;
    [SerializeField] LightView GreenLight;

    [SerializeField] float lightDuration = 5f;

    readonly Color disabledColor = Color.gray;

    void Start()
    {
        StartCoroutine(RunTrafficLight());
    }

    IEnumerator RunTrafficLight()
    {
        while (true)
        {
            yield return RunLight(RedLight, Color.red);

            yield return RunLight(YellowLight, Color.yellow);

            yield return RunLight(GreenLight, Color.green);
        }
    }

    IEnumerator RunLight(LightView activeLight, Color activeColor)
    {
        float remainingTime = lightDuration;

        while (remainingTime > 0f)
        {
            SetLight(activeLight, activeColor, Mathf.CeilToInt(remainingTime).ToString());

            float waitTime = Mathf.Min(1f, remainingTime);
            yield return new WaitForSeconds(waitTime);
            remainingTime -= waitTime;
        }
    }

    void SetLight(LightView activeLight, Color activeColor, string secondText)
    {
        ResetLight(RedLight);
        ResetLight(YellowLight);
        ResetLight(GreenLight);

        activeLight.SetColor(activeColor);
        activeLight.SetSecond(secondText);
    }

    void ResetLight(LightView light)
    {
        light.SetColor(disabledColor);
        light.SetSecond(string.Empty);
    }
}
