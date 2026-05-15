using UnityEngine;

public class Main : MonoBehaviour
{
    async void Start()
    {
        await UIController.Get.OpenAsync<TrafficLightPresenter>();
    }
}
