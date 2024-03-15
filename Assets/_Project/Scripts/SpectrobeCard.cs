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
        public TMP_Text spectrobeName;
        public TMP_Text hpText;
        public TMP_Text attackText;
        public Image artwork;
        public Image frontArt;
        public Image typeSprite;
        public TMP_Text chAttackName;
        public TMP_Text chAttackDesc;

        // Start is called before the first frame update
        void Start()
        {
            spectrobeName.text = spectrobeData.spectrobeName;
            hpText.text = spectrobeData.hp.ToString();
            attackText.text = spectrobeData.attack.ToString();
            artwork.sprite = spectrobeData.cardArt;
            frontArt.sprite = spectrobeData.cardFrontSprite;
            typeSprite.sprite = spectrobeData.typeSprite;
            chAttackName.text = spectrobeData.chAttackName;
            chAttackDesc.text = spectrobeData.chAttackDescription;
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
