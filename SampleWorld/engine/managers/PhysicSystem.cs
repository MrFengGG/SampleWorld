
using Microsoft.Xna.Framework;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.gameObjects;
using System.Collections.Generic;

namespace SampleWorld.engine.managers
{
    public class PhysicSystem
    {
        Dictionary<GameObject, List<ColliderComponent>> components = new Dictionary<GameObject, List<ColliderComponent>>();

        public bool DetectionMove(ColliderComponent component, ref Vector2 moveDelta)
        {

            foreach(GameObject key in components.Keys)
            {
                foreach (ColliderComponent systemComponent in components[key])
                {
                    if (component.Collider.IsRigid && component.Collider.IsRigid)
                    {
                        if (component.Collider.Detection(systemComponent.Collider, ref moveDelta))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (component.Collider.Detection(systemComponent.Collider))
                        {
                            return true;
                        }
                    }
                }
            }
                
            return false;
        }

        public void AddComponent(GameObject parent, ColliderComponent component)
        {
            if (!components.ContainsKey(parent))
            {
                components[parent] = new List<ColliderComponent>();
            }
            components[parent].Add(component);
        }

        public void RemoveComponent(GameObject parent, ColliderComponent component)
        {
            components[parent].Remove(component);
        }

        public void DestoryObject(GameObject parent)
        {
            components.Remove(parent);
        }

        public void AddObject(GameObject parent)
        {
            components[parent] = parent.GetComponentList<ColliderComponent>();
        }
    }
}
