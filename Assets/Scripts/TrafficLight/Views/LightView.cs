
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LightView : MonoBehaviour
{
    [SerializeField] Image m_light;
    [SerializeField] TMP_Text m_secondText;
    
    public void SetColor(Color color)
    {
        m_light.color = color;
    }

    public void SetSecond(string text)
    {
        m_secondText.text = text;
    }
}
