using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _scripts.UI.Language
{
    [CreateAssetMenu(fileName = "ComplexText", menuName = "Text/ComplexText", order = 0)]
    public class ComplexText : ScriptableObject
    {
        [SerializeField] private List<TextScriptable> textInDifferentLanguages;

        public TextScriptable MainText =>
            textInDifferentLanguages.FirstOrDefault(text =>
                text.textLanguage == GlobalConfiguration.GlobalLanguage);
    }
}