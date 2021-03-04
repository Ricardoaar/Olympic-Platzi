using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace _scripts.UI.Language
{
    [CreateAssetMenu(fileName = "ComplexText", menuName = "Text/ComplexText", order = 0)]
    public class ComplexText : ScriptableObject
    {
        [SerializeField] private List<TextScriptable> textInDifferentLanguages;

        public TextScriptable MainText
        {
            get
            {
                foreach (var text in textInDifferentLanguages)
                {
                    if (text.textLanguage == GlobalSettings.GlobalLanguage)
                    {
                        return text;
                    }
                }

                return null;
            }
        }
    }
}