using System.Collections.Generic;
using SampleWorld.engine.components;

namespace SampleWorld.engine.gameObjects
{
    class GameObject : IGameObject
    {

        private List<ILocalComponent> gameComponents = new List<ILocalComponent>();

        private IGameObject parent;

        private List<IGameObject> children;

        private GameObjectManager objectManager;

        bool isActive;

        public void Active()
        {
            isActive = true;
            foreach(ILocalComponent component in gameComponents)
            {
                component.Active();
            }
        }

        public void AddComponent<T>(T component) where T : ILocalComponent
        {
            gameComponents.Add(component);
        }

        public T GetComponent<T>() where T : ILocalComponent
        {
            foreach (ILocalComponent component in gameComponents)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return default(T);
        }

        public List<T> GetComponentList<T>() where T : ILocalComponent
        {
            List<T> components = new List<T>();
            foreach (ILocalComponent component in gameComponents)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    components.Add((T)component);
                }
            }
            return components;
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

        public void Passive()
        {
            isActive = false;
        }

        public void Destory()
        {
            if(children == null || children.Count == 0)
            {

            }
        }
    }
}
