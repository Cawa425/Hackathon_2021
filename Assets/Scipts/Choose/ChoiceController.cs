using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scipts.Choose
{
    [System.Serializable]
    public class ConversationChangeEvent : UnityEvent<Conversation>
    {
    }

    public class ChoiceController:MonoBehaviour
    {
        public Choice choice;
        public ConversationChangeEvent conversationChangeEvent;

        public static ChoiceController AddChoiceButton(Button choiceButtonTamplate, Choice choice, int index)
        {
            const int buttonSpacing = -44;
            var button = Instantiate(choiceButtonTamplate, choiceButtonTamplate.transform.parent, true);
            var buttonTrans = button.transform;
            buttonTrans.localScale = Vector3.one;
            buttonTrans.localPosition = new Vector3(0,index*buttonSpacing,0);
            button.name = "Choice " + (index + 1);
            button.gameObject.SetActive(true);

            ChoiceController choiceController = button.GetComponent<ChoiceController>();
            choiceController.choice = choice;
            return choiceController;
        }
        public void Start()
        {
            if(conversationChangeEvent==null) conversationChangeEvent=new ConversationChangeEvent();
            GetComponentInChildren<Text>().text = choice.text;
        }

        public void MakeChoice()
        {
            conversationChangeEvent.Invoke(choice.conversation);
        }
    }
}