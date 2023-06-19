using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParticleConfiguration", menuName = "ScriptableObjects/ParticleConfiguration", order = 3)]

public class ParticleSO : ScriptableObject
{
    public GameObject particle;
    public ParticleType particleType;
}
