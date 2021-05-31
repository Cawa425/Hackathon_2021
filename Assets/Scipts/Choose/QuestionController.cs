using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scipts.Choose
{
    public class QuestionController : MonoBehaviour
    {
        public Question question;
         public Text questionText;
        public Button choiceButton;

        private List<ChoiceController> choiceControllers = new List<ChoiceController>();

        public void Change(Question question)
        {
            RemoveChoices();
            this.question = question;
            gameObject.SetActive(true);
            Initialize();
        }

        public void Hide(Conversation conversation)
        {
            RemoveChoices();
            gameObject.SetActive(false);
        }

        private void RemoveChoices()
        {
            foreach (var choiceController in choiceControllers)
            {
                Destroy(choiceController.gameObject);
            }
            choiceControllers.Clear();
        }

        private void Initialize()
        {
            questionText.text = question.text;
            for(var index=0;index<question.choices.Length;index++)
            {
                var c = ChoiceController.AddChoiceButton(choiceButton,question.choices[index],index);
                choiceControllers.Add(c);
            }

            choiceButton.gameObject.SetActive(false);
        }
    }
}