using UnityEngine;

[CreateAssetMenu(fileName = "ResultMenuConfig", menuName = "MenuConfig/ResultMenuConfig")]
public class ResultMenuConfig : ScriptableObject
{
    [SerializeField] private ResultMenuHeaderConfig _victory;
    [SerializeField] private ResultMenuHeaderConfig _deffeat;

    public ResultMenuHeaderConfig Victory => _victory;

    public ResultMenuHeaderConfig Deffeat => _deffeat;
}
