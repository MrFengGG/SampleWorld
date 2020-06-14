using Microsoft.Xna.Framework;
using SampleWorld.engine.components;
using SampleWorld.engine.support;
using System.Collections.Generic;
namespace SampleWorld.engine.gameObjects
{
    public interface IGameObject : IAdjustable
    {
        List<LocalComponent> GetAllComponents();
        
        //获取子组件
        List<T> GetComponentList<T>() where T : LocalComponent;

        //获取子组件
        T GetComponent<T>() where T : LocalComponent;

        //获取父节点子组件
        List<T> GetParentComponentList<T>() where T : LocalComponent;

        //获取父节点子组件
        T GetParentComponent<T>() where T : LocalComponent;

        //获取所有父节点子组件
        List<T> GetParentsComponentList<T>() where T : LocalComponent;

        //获取所有父节点子组件
        T GetParentsComponent<T>() where T : LocalComponent;

        //添加子对象
        void AddChild(GameObject gameObject);

        //添加组件
        void AddComponent<T>(T component) where T : LocalComponent;

        //删除组件
        void RemoveComponent(LocalComponent component);

        //销毁自身
        void Destory();
    }
}
