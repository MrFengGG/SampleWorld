
using Microsoft.Xna.Framework;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.events;
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
                    if(component.Level != systemComponent.Level)
                    {
                        continue;
                    }
                    if (component.Collider.IsRigid && component.Collider.IsRigid)
                    {
                        if (component.Collider.Detection(systemComponent.Collider, ref moveDelta))
                        {
                            component.OnEvent(new EventArgs(engine.components.events.EventTypeEnum.Colliding, systemComponent));
                            systemComponent.OnEvent(new EventArgs(engine.components.events.EventTypeEnum.Colliding, component));
                            return true;
                        }
                    }
                    else
                    {
                        if (component.Collider.Detection(systemComponent.Collider))
                        {
                            component.OnEvent(new EventArgs(engine.components.events.EventTypeEnum.Colliding, systemComponent));
                            systemComponent.OnEvent(new EventArgs(engine.components.events.EventTypeEnum.Colliding, component));
                            return true;
                        }
                    }
                }
            }
                
            return false;
        }

        public void AddComponent(ColliderComponent component)
        {
            if (!components.ContainsKey(component.Parent))
            {
                components[component.Parent] = new List<ColliderComponent>();
            }
            components[component.Parent].Add(component);
        }

        public void RemoveComponent(ColliderComponent component)
        {
            components[component.Parent].Remove(component);
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
