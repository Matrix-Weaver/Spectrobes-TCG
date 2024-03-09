using UnityEngine;

namespace SpectrobesTCG
{

    public class CardManager : MonoBehaviour
    {
        public static CardManager instance;
        public static float stackCardSpacing = 0.005f;
        public SpectrobeCard spectrobeCardPrefab;
        public Sprite[] propertyIcons;
        public Sprite[] spectrobeCardFront;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public enum SpectrobeProperty
        {
            aurora,
            corona,
            flash,
        }

        public enum SpectrobeForm
        {
            adult,
            child,
            evolved,
        }

        public enum CardType
        {
            spectrobe,
            weapon,
            mineral,
        }
    }
}
