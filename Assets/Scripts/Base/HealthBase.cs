using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class HealthBase : MonoBehaviour,IDamageable
{
    [SerializeField] public Slider healthBarSlider;
    [SerializeField] protected Image healthBarFillImage;
    [SerializeField] protected Color maxHealthColor, minHealthColor;

    internal float health;
    protected abstract internal void CheckIfDead();

    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    private void Awake()
    {
        SetHealthBarUI();
    }

    protected virtual void Update()
    {
        SetHealthBarUI();
    }
    public virtual Transform GetTransform()
    {
        return transform;
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        SetHealthBarUI();
        CheckIfDead();
    }
    private IEnumerator HealthBarActivationCo()
    {
        healthBarSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        healthBarSlider.gameObject.SetActive(false);
    }
    public virtual void ScaleHealthBar()
    {
        StartCoroutine(HealthBarActivationCo());
    }

    private void SetHealthBarUI()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthBarSlider.value = healthPercentage;
        healthBarFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, healthPercentage / healthBarSlider.maxValue);


    }
    private float CalculateHealthPercentage()
    {
        return (Health / healthBarSlider.maxValue) * healthBarSlider.maxValue;
    }

}
