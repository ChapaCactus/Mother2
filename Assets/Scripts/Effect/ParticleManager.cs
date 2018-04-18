using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParticleManager : SingletonMonoBehaviour<ParticleManager>
{
    [SerializeField]
    private List<ParticleMaster> _masters = new List<ParticleMaster>();

    public ParticleSystem SearchParticleSystem(string key)
    {
        if (_masters == null) return null;

        return _masters.FirstOrDefault(master => master.name == key).particlePrefab;
    }
}
