using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectrobeCardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public SpectrobeData SpectrobeData;

    public Text spectrobeName;
    public Text hp;
    public Text attack;
    public Image artwork;
    public Image frontArt;
    public Text chAttackName;
    public Text chAttackDesc;
    void Start()
    {
        spectrobeName.text = SpectrobeData.spectrobeName;
        ;
    }
}
