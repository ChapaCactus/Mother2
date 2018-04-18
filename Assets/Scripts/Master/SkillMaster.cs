using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateMaster/SkillMaster")]
public class SkillMaster : ScriptableObject
{
    public string skillName = "";
    public ParticleMaster particle;
}
