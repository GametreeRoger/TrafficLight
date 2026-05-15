using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class TrafficLightPresenter : PresenterBase
{
    const float LightDuration = 5f;

    ITrafficLightView m_view;

    public override Task LoadAsync(IPrepareData data)
    {
        m_view = UIManager.Get.Open<TrafficLightView>();
        m_view.OnCloseRequested += onCloseRequested;
        return Task.CompletedTask;
    }

    void onCloseRequested() => Hide();

    public override void OnHide()
    {
        UIManager.Get.Close<TrafficLightView>();
    }

    public override IEnumerator Run()
    {
        while (true)
        {
            yield return runPhase(TrafficLightPhase.Red);
            yield return runPhase(TrafficLightPhase.Yellow);
            yield return runPhase(TrafficLightPhase.Green);
        }
    }

    IEnumerator runPhase(TrafficLightPhase phase)
    {
        float remainingTime = LightDuration;

        while (remainingTime > 0f)
        {
            m_view.SetLight(phase, Mathf.CeilToInt(remainingTime).ToString());

            float waitTime = Mathf.Min(1f, remainingTime);
            yield return new WaitForSeconds(waitTime);
            remainingTime -= waitTime;
        }
    }
}
