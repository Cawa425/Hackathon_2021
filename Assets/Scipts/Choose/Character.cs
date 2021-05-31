using UnityEngine;

namespace Scipts.Choose
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
    public class Character:ScriptableObject
    {
        public string fullName;
    }
}