
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrafficLightView : MonoBehaviour
{
    [SerializeField] Image RedLight;
    [SerializeField] Image YellowLight;
    [SerializeField] Image GreenLight;

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
            SetLight(RedLight, Color.red);
            yield return new WaitForSeconds(lightDuration);

            SetLight(YellowLight, Color.yellow);
            yield return new WaitForSeconds(lightDuration);

            SetLight(GreenLight, Color.green);
            yield return new WaitForSeconds(lightDuration);
        }
    }

    void SetLight(Image activeLight, Color activeColor)
    {
        RedLight.color = disabledColor;
        YellowLight.color = disabledColor;
        GreenLight.color = disabledColor;

        activeLight.color = activeColor;
    }
}
