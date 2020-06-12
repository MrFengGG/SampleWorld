using System.Collections.Generic;
using SampleWorld.engine.components;

namespace SampleWorld.engine.gameObjects
{
    public class GameObject : IGameObject
    {
        private IGameObject parent;

        private List<IGameObject> children;

        private GameObjectManager objectManager;

        bool isActive;

        public GameObject(GameObjectManager manager, IGameObject parent)
        {
            objectManager = manager;
            manager.AddObject(this);
            this.parent = parent;
            isActive = true;
        }

        public void Active()
        {
            isActive = true;
            foreach(ILocalComponent component in objectManager.getAllComponents(this))
            {
                component.Active();
            }
        }

        public void Passive()
        {
            isActive = true;
            foreach (ILocalComponent component in objectManager.getAllComponents(this))
            {
                component.Passive();
            }
        }

        public void AddComponent<T>(T component) where T : ILocalComponent
        {
            objectManager.AddComponent(this, component);
        }

        public T GetComponent<T>() where T : ILocalComponent
        {
            return objectManager.GetComponent<T>(this);
        }

        public List<T> GetComponentList<T>() where T : ILocalComponent
        {
            return objectManager.GetComponents<T>(this);
        }

        public IGameObject GetParent()
        {
            return parent;
        }

        public T GetParentComponent<T>() where T : ILocalComponent
        {
            return parent.GetComponent<T>();
        }

        public List<T> GetParentComponentList<T>() where T : ILocalComponent
        {
            return parent.GetComponentList<T>();
        }

        public List<T> GetParentsComponentList<T>() where T : ILocalComponent
        {
            return parent == null ? GetComponentList<T>() : parent.GetParentsComponentList<T>();
        }

        public T GetParentsComponent<T>() where T : ILocalComponent
        {
            return parent == null ? GetParentsComponent<T>() : parent.GetParentsComponent<T>();
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void Destory()
        {
            if(children == null || children.Count == 0)
            {
                objectManager.RemoveObject(this);
            }
            foreach(IGameObject child in children)
            {
                child.Destory();
            }
        }

        public void AddChild(IGameObject gameObject)
        {
            if(children == null)
            {
                children = new List<IGameObject>();
            }
            children.Add(gameObject);
        }

        public void RemoveComponent(ILocalComponent component)
        {
            objectManager.RemoveComponent(this, component);
        }

        public List<ILocalComponent> GetAllComponents()
        {
            return objectManager.getAllComponents(this);
        }
    }
}
