using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [CreateAssetMenu(fileName = "New Act Node", menuName = "Scriptable Object/Dialog/Act Node", order = 52)]
    public class ActNode : ScriptableObject
    {
        public List<ActorToCreate> actorsToCreate;

        private List<Actor> _actors;
        private int _currentTransitionIndex;

        public void Initialize(Transform stage)
        {
            _actors = new List<Actor>();
            _currentTransitionIndex = 0;

            foreach (var actorToCreate in actorsToCreate)
            {
                GameObject actorGameObject = new GameObject();
                Actor actor = actorGameObject.AddComponent<Actor>();
                _actors.Add(actor);

                actor.transform.SetParent(stage);

                actor.Initialize(actorToCreate);
            }
        }

        public void NextTransition()
        {
            for (int i = _actors.Count - 1; i >= 0; i--)
            {
                if (_actors[i].TransitionCount <= _currentTransitionIndex)
                {
                    GameObject actorGameObject = _actors[i].gameObject;
                    _actors.RemoveAt(i);
                    Destroy(actorGameObject);
                    continue;
                }

                _actors[i].ApplyTransition(_currentTransitionIndex);

                _currentTransitionIndex++;
            }
        }
    }
}
