using System;
using Configuration;
using LilPuter;
using UnityEngine;

public class PinView : ViewBase<Pin, int>
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void OnComponentUpdate(int newValue)
    {
        _meshRenderer.material = newValue == 0 ? SettingsManager.CurrentSettings._pinOffMat : SettingsManager.CurrentSettings._pinOnMat;
    }
    
}
