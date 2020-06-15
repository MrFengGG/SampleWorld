using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.managers;
using System.Collections.Generic;

namespace SampleWorld.engine.components
{
    public class GameObjectManager : DrawableGameComponent
    {
        public SpriteBatch SpriteBatch { get; }

        Dictionary<GameObject, List<LocalComponent>> objectComponentMap = new Dictionary<GameObject, List<LocalComponent>>();

        List<LocalComponent> toRemoveComponents = new List<LocalComponent>();

        List<LocalComponent> toAddComponents = new List<LocalComponent>();

        List<GameObject> toRemoveObject = new List<GameObject>();

        List<GameObject> toAddObject = new List<GameObject>();

        public PhysicSystem PhysicSystem { get; }

        public GameObjectManager(Game game) : base(game)
        {
            game.Components.Add(this);
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            PhysicSystem = new PhysicSystem();
        }

        //渲染组件
        public override void Draw(GameTime gameTime)
        {
            foreach(GameObject gameObject in objectComponentMap.Keys){
                foreach (LocalComponent component in objectComponentMap[gameObject])
                {
                    DrawableLocalComponent drawableComponent = component as DrawableLocalComponent;
                    if (drawableComponent != null)
                    {
                        drawableComponent.Draw(gameTime);
                    }
                }
            }
        }
        //更新组件
        public override void Update(GameTime gameTime)
        {
            if(toAddObject.Count > 0)
            {
                foreach(GameObject gameObject in toAddObject)
                {
                    objectComponentMap[gameObject] = new List<LocalComponent>();
                }
                toAddObject.Clear();
            }
            if (toAddComponents.Count > 0)
            {
                foreach (LocalComponent component in toAddComponents)
                {
                    AddComponent(component);
                }
                toAddComponents.Clear();
            }
            if (toRemoveComponents.Count > 0)
            {
                foreach (LocalComponent component in toRemoveComponents)
                {
                    RemoveComponent(component);
                }
                toRemoveComponents.Clear();
            }
            if (toRemoveObject.Count > 0)
            {
                foreach (GameObject gameObject in toRemoveObject)
                {
                    destoryGameObject(gameObject);
                }
                toRemoveObject.Clear();
            }
            foreach (GameObject gameObject in objectComponentMap.Keys)
            {
                foreach (LocalComponent component in objectComponentMap[gameObject])
                {
                    component.Update(gameTime);
                }
            }
        }
        //添加游戏对象
        public void AddObject(GameObject gameObject)
        {
            toAddObject.Add(gameObject);
        }
        //获取对象组件
        public T GetComponent<T>(GameObject gameObject) where T : LocalComponent
        {
            foreach (LocalComponent component in objectComponentMap[gameObject])
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return default(T);
        }
        //获取对象组件列表
        public List<T> GetComponents<T>(GameObject gameObject) where T : LocalComponent
        {
            List<T> components = new List<T>();
            if (objectComponentMap.ContainsKey(gameObject))
            {
                foreach (LocalComponent component in objectComponentMap[gameObject])
                {
                    if (component.GetType().Equals(typeof(T)))
                    {
                        components.Add((T)component);
                    }
                }
            }
            return components;
        }
        //获取对象所有组件
        public List<LocalComponent> getAllComponents(GameObject gameObject)
        {
            return objectComponentMap[gameObject];
        }
        //获取所有游戏对象
        public List<T> getGameObjects<T>() where T : GameObject
        {
            List<T> gameObjects = new List<T>();
            foreach (GameObject gameObject in objectComponentMap.Keys)
            {
                if (gameObject.GetType().Equals(typeof(T)))
                {
                    gameObjects.Add((T)gameObject);
                }
            }
            return gameObjects;
        }
        //获取游戏对象
        public T getGameObject<T>() where T : GameObject
        {
            foreach (GameObject gameObject in objectComponentMap.Keys)
            {
                if (gameObject.GetType().Equals(typeof(T)))
                {
                    return (T)gameObject;
                }
            }
            return default(T);
        }
        //删除游戏对象
        public void RemoveObject(GameObject gameObject)
        {
            toRemoveObject.Add(gameObject);
        }
        //为对象添加组件
        public void AddComponent(LocalComponent localComponent)
        {
            objectComponentMap[localComponent.Parent].Add(localComponent);
            if(localComponent is ColliderComponent)
            {
                PhysicSystem.AddComponent((ColliderComponent)localComponent);
            }
        }
        //下次更新时添加组件
        public void AddComponentLazy(LocalComponent localComponent)
        {
            toAddComponents.Add(localComponent);
        }
        //删除组件
        public void RemoveComponent(LocalComponent localComponent)
        {
            objectComponentMap[localComponent.Parent].Remove(localComponent);
            if (localComponent is ColliderComponent)
            {
                PhysicSystem.RemoveComponent((ColliderComponent)localComponent);
            }
        }
        //下次更新时删除组件
        public void RemoveComponentLazy(LocalComponent localComponent)
        {
            toRemoveComponents.Add(localComponent);
        }
        //销毁对象
        private void destoryGameObject(GameObject gameObject)
        {
            objectComponentMap.Remove(gameObject);
            PhysicSystem.DestoryObject(gameObject);
        }
    }
}
