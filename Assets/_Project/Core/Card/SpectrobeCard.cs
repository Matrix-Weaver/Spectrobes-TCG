using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SpectrobesTCG
{

    public class SpectrobeCard : Card
    {
        public CardManager.SpectrobeForm form = CardManager.SpectrobeForm.adult;
        public CardManager.SpectrobeProperty property = CardManager.SpectrobeProperty.aurora;
        public int attack;
        public int hp;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnPlayed()
        {
            Debug.Log("OnPlayCard: Using SpectrobeCard");
        }
    }
}
