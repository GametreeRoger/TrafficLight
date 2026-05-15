public enum TrafficLightPhase { Red, Yellow, Green }

public interface ITrafficLightView
{
    event System.Action OnCloseRequested;
    void SetLight(TrafficLightPhase phase, string second);
}
