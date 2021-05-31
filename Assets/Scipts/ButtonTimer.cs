using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scipts
{
    public class ButtonTimer : MonoBehaviour
    {
        [SerializeField] UnityEvent onFullChoosed;

        public int index = 0;
        private bool _selected;
        private  Image _cl;
        public float selectTime = 2.0f;

        public void Start()
        {
        
            _cl = gameObject.GetComponentInChildren<Mask>().gameObject.GetComponent<Image>();
            //AutoIndex
            if (index == 0)
            {
                var a = String.Concat(gameObject.name.Where(char.IsDigit));
                if(a=="") a="0";
                int.TryParse(a, out index);
            }

        }

        public void Update()
        {
        
            if (_selected && EventSystem.current?.currentSelectedGameObject?.name == gameObject.name)
            {
                _cl.fillAmount += 1.0f / selectTime * Time.deltaTime;
            }

            if (_cl.fillAmount >= 1.0f)
            {
                onFullChoosed.Invoke();
     
            }
        }

        public void onPress()
        {
        
            _selected = true;
        }

        public void onRelease()
        {
       
            _selected = false;
            _cl.fillAmount = 0;
        }
    }
}