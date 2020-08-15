using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog
{
    [CreateAssetMenu(fileName = "New Act", menuName = "Scriptable Object/Dialog/Act", order = 52)]
    public class ActNode : ScriptableObject
    {
        List<ActState> states;
    }
}
