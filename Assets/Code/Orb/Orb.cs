using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Orb : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _strength;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Text _strengthText;
    


    public OrbStatsUIToggle orbToggle;

    public enum OrbStates { active, inactive };
    public OrbStates orbState;

    public float Health
    {
        get => _health;
        set { _health = value; }

    }

    public float Strength
    {
        get => _strength;
        set { _strength = value; }

    }

    public TextMeshProUGUI HealthUI
    {
        get => _healthText;
        set { _healthText = value; }

    }
    public Text StrengthUI
    {
        get => _strengthText;
        set { _strengthText = value; }

    }
    public void SetHealth(float value)
    {
        Health = value;
    }
    public void IncreaseHealth(float value)
    {
        float start = this.Health;
        start += value;
        this.Health = start;
    }
    public void DecreaseHealth(float value)
    {
        float start = this.Health;
        start -= value;
        this.Health = start;
    }

    public void SetStrength(float value)
    {
        Strength = value;
    }
    public void IncreaseStrength(float value)
    {
        float start = this.Strength;
        start += value;
        this.Strength = start;
    }
    public void DecreaseStrength(float value)
    {
        float start = this.Strength;
        start -= value;
        this.Strength = start;
    }
    // Start is called before the first frame update
    void Start()
    {
        orbState = OrbStates.inactive;
    }

    // Update is called once per frame
    void Update()
    {
        switch (orbState)
        {
            case OrbStates.active:
                orbToggle.ToggleStats(_canvas, true);


                break;
            case OrbStates.inactive:
                orbToggle.ToggleStats(_canvas, false);
                break;

        }
    }

    public void OrbStateToggle()
    {
        switch (orbState) {
            case OrbStates.active:
                orbState = OrbStates.inactive;
                break;
            case OrbStates.inactive:
                orbState = OrbStates.active;
                break;

        }
    }
}