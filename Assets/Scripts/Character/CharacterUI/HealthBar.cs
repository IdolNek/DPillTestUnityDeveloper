using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Character.CharacterUI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetValue(float currentHP, float maxHP) =>
            _image.fillAmount = currentHP / maxHP;
    }
}