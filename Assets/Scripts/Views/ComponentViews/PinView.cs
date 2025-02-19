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
        if(_meshRenderer != null && VizSettings.CurrentSettings != null){
            _meshRenderer.material = newValue == 0
                ? VizSettings.CurrentSettings.PinOffMat
                : VizSettings.CurrentSettings.PinOnMat;
        }
    }
    
}
