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
        public Image frontCard;
        private string childType;
        public TMP_Text abilityName;
        public TMP_Text abilityDesc;

        // Start is called before the first frame update
        void Start()
        {
            spectrobeName.text = childData.spectrobeName;
            childType = childData.elementType.ToString();
            string typePath = "Icons/" + childType;
            abilityName.text = childData.AbilityName;
            abilityDesc.text = childData.AbilityDescription;
            type.sprite = Resources.Load<Sprite>(typePath);
            frontCard.sprite = Resources.Load<Sprite>("Card/Card_Front_Child");
            artwork.sprite = Resources.Load<Sprite>(childData.artworkPath);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

