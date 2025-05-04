using System;
using UnityEngine;
using UnityEngine.UI;

public class DebugSetActiveButton : MonoBehaviour
{
    [SerializeField] private Button _targetButtonSpawnAll;
    [SerializeField] private Button _targetButtonSpawnOne;
    public void SetActiveButton()
    {
        _targetButtonSpawnAll.gameObject.SetActive(!_targetButtonSpawnAll.gameObject.activeSelf);
        _targetButtonSpawnOne.gameObject.SetActive(!_targetButtonSpawnOne.gameObject.activeSelf);
    }
}
