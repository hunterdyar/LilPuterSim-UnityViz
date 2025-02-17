using System;
using Configuration;
using UnityEditor;
using UnityEngine;

public class ArrowVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer _arrowRenderer;
    [SerializeField] private MeshRenderer _boxRenderer;
    private Material OnMat => VizSettings.CurrentSettings.PinOnMat;
    private Material OffMat => VizSettings.CurrentSettings.PinOffMat;

    private void Awake()
    {
        SetState(false, true);
    }

    public void SetState(bool on, bool directionIsRight)
    {
        if (_arrowRenderer == null || _boxRenderer == null)
        {
            return;
        }
        
        _arrowRenderer.enabled = on;
        _boxRenderer.enabled = !on;
        _arrowRenderer.material = on ? OnMat : OffMat;
        _boxRenderer.material = OffMat;
        if (directionIsRight)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
