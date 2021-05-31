using UnityEngine;
using UnityEngine.UI;

namespace Scipts.Choose
{
    public class SpeakerUI:MonoBehaviour
    {
        public Text dialog;
        public Text fullName;

        private Character speaker;

        public Character Speaker
        {
            get => speaker;
            set
            {
                speaker = value;
                fullName.text = speaker.fullName;
            }
        }

        public string Dialog
        {
            set => dialog.text = value;
        }

        public bool HadSpeaker => speaker != null;

        public void Show()
        {
            gameObject.SetActive(true);
        } 
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}