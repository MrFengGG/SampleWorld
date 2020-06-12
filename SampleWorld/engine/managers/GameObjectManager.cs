using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;
using System.Collections.Generic;

namespace SampleWorld.engine.components
{
    public class GameObjectManager : DrawableGameComponent
    {
        Dictionary<IGameObject, List<ILocalComponent>> objectComponentMap = new Dictionary<IGameObject, List<ILocalComponent>>();

        List<IGameObject> toRemoveObject = new List<IGameObject>();

        public GameObjectManager(Game game) : base(game)
        {
            game.Components.Add(this);
        }

        //渲染组件
        public override void Draw(GameTime gameTime)
        {
            foreach(IGameObject gameObject in objectComponentMap.Keys){
                foreach (ILocalComponent component in objectComponentMap[gameObject])
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
            foreach(IGameObject gameObject in toRemoveObject)
            {
                destoryGameObject(gameObject);
            }
            foreach (IGameObject gameObject in objectComponentMap.Keys)
            {
                foreach (ILocalComponent component in objectComponentMap[gameObject])
                {
                    component.Update(gameTime);
                }
            }
        }
        //添加游戏对象
        public void AddObject(IGameObject gameObject)
        {
            objectComponentMap[gameObject] = new List<ILocalComponent>();
        }
        //获取对象组件
        public T GetComponent<T>(IGameObject gameObject) where T : ILocalComponent
        {
            foreach (ILocalComponent component in objectComponentMap[gameObject])
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return default(T);
        }
        //获取对象组件列表
        public List<T> GetComponents<T>(IGameObject gameObject) where T : ILocalComponent
        {
            List<T> components = new List<T>();
            foreach (ILocalComponent component in objectComponentMap[gameObject])
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    components.Add((T)component);
                }
            }
            return components;
        }
        //获取对象所有组件
        public List<ILocalComponent> getAllComponents(IGameObject gameObject)
        {
            return objectComponentMap[gameObject];
        }
        //删除游戏对象
        public void RemoveObject(IGameObject gameObject)
        {
            toRemoveObject.Add(gameObject);
        }
        //为对象添加组件
        public void AddComponent(IGameObject gameObject, ILocalComponent localComponent)
        {
            objectComponentMap[gameObject].Add(localComponent);
        }
        //删除组件
        public void RemoveComponent(IGameObject gameObject, ILocalComponent localComponent)
        {
            objectComponentMap[gameObject].Remove(localComponent);
        }
        //销毁对象
        private void destoryGameObject(IGameObject gameObject)
        {
            objectComponentMap.Remove(gameObject);
        }
    }
}
