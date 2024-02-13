using System;
using UnityEngine;

[Serializable]
public class ResultMenuHeaderConfig
{
    [SerializeField] private string _text;
    [SerializeField] private Color _color;

    public string Text => _text;

    public Color Color => _color;
}
