using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundData", menuName = "RoundData")]
public class RoundDatas : ScriptableObject
{
    public string roundName; // Name of the round
    public int timeforRound; // Time available for the round
    public ScriptableObject[] questions;
}
