using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class FuelPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _fuelPanel;
    [SerializeField] private PlayerMovable _playerMovable;

    private void Start()
    {
        _fuelPanel = GetComponent<TMP_Text>();
        _fuelPanel.text = _playerMovable.Fuel.ToString();
    }

    private void Update()
    {
        _fuelPanel.text = _playerMovable.Fuel.ToString();
    }
}
