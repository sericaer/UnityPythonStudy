using UnityEngine;
using IronPython.Hosting;
using System;
using UnityEngine.UI;

namespace Exodrifter.UnityPython.Examples
{
    public class PythonCallFunc : MonoBehaviour
    {
        public Text text;

        void Start()
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();

            string code = @"
def GetText(str):
    return str + '_append'";

            var source = engine.CreateScriptSourceFromString(code);
            source.Execute(scope);

            var funcGetText = scope.GetVariable<Func<string, string>>("GetText");
            text.text = funcGetText("abc");
        }
    }
}