using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataKeys", menuName = "DataKeys")]
public class DataKeys : ScriptableObject
{
    [SerializeField] private string _tickets;

    [SerializeField] private string _character1;
    [SerializeField] private string _character2;
    [SerializeField] private string _character3;

    [SerializeField] private string _location1;
    [SerializeField] private string _location2;
    [SerializeField] private string _location3;

    [SerializeField] private string _lastLvl;

    [SerializeField] private string _lastDate;

    [SerializeField] private string _lastBonusDate;
    [SerializeField] private string _nextBonusNumber;

    public string Tickets => _tickets;
    public string Character1 => _character1;
    public string Character2 => _character2;
    public string Character3 => _character3;
    public string Location1 => _location1;
    public string Location2 => _location2;
    public string Location3 => _location3;
    public string LastLvl => _lastLvl;
    public string LastDate => _lastDate;
    public string LastBonusDate => _lastBonusDate;
    public string NextBonusNumber => _nextBonusNumber;
}
