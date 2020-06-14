using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SampleWorld.engine.components;
using SampleWorld.engine.components.physic;

namespace SampleWorld.engine.gameObjects
{
    public class GameObject : IGameObject
    {
        Vector2 position;

        public Vector2 Position
        {
            get
            {
                if(Parent == null)
                {
                    return position;
                }
                return new Vector2(Parent.Position.X + position.X, Parent.Position.Y + position.Y);
            }
            set
            {
                List<ColliderComponent> colliderComponents = GetComponentList<ColliderComponent>();
                Vector2 delta = new Vector2(value.X - Position.X, value.Y - Position.Y);
                foreach(ColliderComponent component in colliderComponents)
                {
                    if(ObjectManager.PhysicSystem.DetectionMove(component, ref delta)){
                        position.X += delta.X;
                        position.Y += delta.Y;
                        return;
                    }
                }
                position = value;
            }
        }

        public Vector2 Scale { get; set; }

        public float Rotation { get; set; }

        public GameObject Parent { get; }

        private List<GameObject> children;

        public GameObjectManager ObjectManager { get; }

        bool isActive;

        public GameObject(GameObjectManager manager, GameObject parent)
        {
            Scale = new Vector2(1, 1);
            Rotation = 0;

            ObjectManager = manager;
            Parent = parent;
            isActive = true;

            Position = new Vector2(0, 0);
        }

        public void Active()
        {
            isActive = true;
            foreach(ILocalComponent component in ObjectManager.getAllComponents(this))
            {
                component.Active();
            }
        }

        public void Passive()
        {
            isActive = true;
            foreach (ILocalComponent component in ObjectManager.getAllComponents(this))
            {
                component.Passive();
            }
        }

        public void AddComponent<T>(T component) where T : LocalComponent
        {
            ObjectManager.AddComponent(this, component);
        }

        public T GetComponent<T>() where T : LocalComponent
        {
            return ObjectManager.GetComponent<T>(this);
        }

        public List<T> GetComponentList<T>() where T : LocalComponent
        {
            return ObjectManager.GetComponents<T>(this);
        }

        public T GetParentComponent<T>() where T : LocalComponent
        {
            return Parent.GetComponent<T>();
        }

        public List<T> GetParentComponentList<T>() where T : LocalComponent
        {
            return Parent.GetComponentList<T>();
        }

        public List<T> GetParentsComponentList<T>() where T : LocalComponent
        {
            return Parent == null ? GetComponentList<T>() : Parent.GetParentsComponentList<T>();
        }

        public T GetParentsComponent<T>() where T : LocalComponent
        {
            return Parent == null ? GetParentsComponent<T>() : Parent.GetParentsComponent<T>();
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void Destory()
        {
            if(children == null || children.Count == 0)
            {
                ObjectManager.RemoveObject(this);
            }
            foreach(IGameObject child in children)
            {
                child.Destory();
            }
        }

        public void AddChild(GameObject gameObject)
        {
            if(children == null)
            {
                children = new List<GameObject>();
            }
            children.Add(gameObject);
        }

        public void RemoveComponent(LocalComponent component)
        {
            ObjectManager.RemoveComponent(this, component);
        }

        public List<LocalComponent> GetAllComponents()
        {
            return ObjectManager.getAllComponents(this);
        }
    }
}
