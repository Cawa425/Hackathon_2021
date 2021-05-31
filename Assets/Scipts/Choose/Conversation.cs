using UnityEngine;

namespace Scipts.Choose
{
    [System.Serializable]
    public struct Line
    {
        public Character character;
        [TextArea(2, 5)] public string text;
    }
    [CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
    public class Conversation:ScriptableObject
    {
        public Character speaker;
        public Question question;
        public Conversation nextConversation;
        public Line[] lines;
    }
}