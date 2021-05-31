using UnityEngine;
using UnityEngine.Events;

namespace Scipts.Choose
{
    [System.Serializable]
    public class QuestionEvent : UnityEvent<Question> {}
    public class ConversationController:MonoBehaviour
    {
        public QuestionEvent questionEvent;
        public Conversation conversation;
        public GameObject Speaker;
        
        private SpeakerUI speakerUi;

        private int activeLineIndex;
        private bool conversationStarted;
        public void ChangeConversation(Conversation nextConversation)
        {
            conversationStarted = false;
            conversation = nextConversation;
            AdvanceLine();
        }

        private void Start()
        {
            speakerUi = Speaker.GetComponent<SpeakerUI>();
            Initialize();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)|| OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Any))AdvanceLine();
            else if (Input.GetKeyDown(KeyCode.X)) EndConversation();
        }

        private void EndConversation()
        {
            conversation = null;
            conversationStarted = false;
            speakerUi.Hide();
        }

        private void Initialize()
        {
            conversationStarted = true;
            activeLineIndex = 0;
            speakerUi.Speaker = conversation.speaker;
        }

        private void AdvanceLine()
        {
            if (conversation == null) return;
            if(!conversationStarted) Initialize();
            if (activeLineIndex < conversation.lines.Length)
                DisplayLine();
            else AdvanceConversation();
        }

        private void DisplayLine()
        {
            Line line = conversation.lines[activeLineIndex];
            var character = line.character;
            SetDialog(speakerUi, line.text);
            activeLineIndex++;
        }

        private void AdvanceConversation()
        {
            if (conversation.question != null) questionEvent.Invoke(conversation.question);
            else if (conversation.nextConversation != null)
                ChangeConversation(conversation.nextConversation);
            else EndConversation();
        }

        private void SetDialog(SpeakerUI activeSpeakerUI, string text)
        {
            activeSpeakerUI.Dialog = text;
            activeSpeakerUI.Show();
        }
    }
}