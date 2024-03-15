using SpectrobesTCG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpectrobesTCG 
{
    public class ChildCard : Card
    {
        public ChildData childData;
        public TMP_Text spectrobeName;
        public Image artwork;
        public Image type;
        public TMP_Text abilityName;
        public TMP_Text abilityDesc;

        // Start is called before the first frame update
        void Start()
        {
            spectrobeName.text = childData.spectrobeName;
            abilityName.text = childData.AbilityName;
            abilityDesc.text = childData.AbilityDescription;
            artwork.sprite = childData.artwork;
            type.sprite = childData.type;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

