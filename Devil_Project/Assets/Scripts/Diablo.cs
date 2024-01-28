using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diablo : MonoBehaviour
{
    public CharacterSO Hunt(CharacterSO victim)
    {
        
        victim.SetIsDiavlo(false);

        return victim;
    }
    
}
