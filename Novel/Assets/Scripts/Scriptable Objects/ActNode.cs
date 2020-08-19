using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [CreateAssetMenu(fileName = "New Act Node", menuName = "Scriptable Object/Dialog/Act Node", order = 52)]
    public class ActNode : ScriptableObject
    {
        public List<Actor> actors;
        public int currentTransitionIndex;

        public void NextTransition()
        {
            for (int i = actors.Count - 1; i >= 0; i--)
            {
                if (actors[i].TransitionCount <= currentTransitionIndex)
                {
                    GameObject actorGameObject = actors[i].gameObject;
                    actors.RemoveAt(i);
                    Destroy(actorGameObject);
                    continue;
                }

                if (currentTransitionIndex == 0)
                {
                    actors[i].ApplyTransition(currentTransitionIndex);
                    currentTransitionIndex++;
                }

                actors[i].ApplyTransition(currentTransitionIndex);

                currentTransitionIndex++;
            }
        }
    }
}
