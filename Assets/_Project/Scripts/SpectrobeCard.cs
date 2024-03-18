using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace SpectrobesTCG
{

    public class SpectrobeCard : Card
    {
        public SpectrobeData spectrobeData;
        public SpectrobeData evolvedData;
        public TMP_Text spectrobeName;
        public TMP_Text hpText;
        public TMP_Text attackText;
        public Image artwork;
        public Image type;
        public Image frontCard;
        public TMP_Text chAttackName;
        public TMP_Text chAttackDesc;
        private string spectrobeType;
        public bool isEvolved = false;

        // Start is called before the first frame update
        void Start()
        {
            spectrobeName.text = spectrobeData.spectrobeName;
            spectrobeType = spectrobeData.elementType.ToString();
            string typePath = "Icons/" + spectrobeType;
            hpText.text = spectrobeData.hp.ToString();
            attackText.text = spectrobeData.attack.ToString();
            artwork.sprite = Resources.Load<Sprite>(spectrobeData.artworkPath);
            frontCard.sprite = Resources.Load<Sprite>("Card/Card_Front_Adult");
            type.sprite = Resources.Load<Sprite>(typePath);
            chAttackName.text = spectrobeData.chAttackName;
            chAttackDesc.text = spectrobeData.chAttackDescription;
        }

        public void evolution()
        {
            spectrobeName.text = evolvedData.spectrobeName;
            hpText.text = evolvedData.hp.ToString();
            attackText.text = evolvedData.attack.ToString();
            artwork.sprite = Resources.Load<Sprite>(evolvedData.artworkPath);
            chAttackName.text = evolvedData.chAttackName;
            frontCard.sprite = Resources.Load<Sprite>("Card/Card_Front_Evolved");
            chAttackDesc.text = evolvedData.chAttackDescription;
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