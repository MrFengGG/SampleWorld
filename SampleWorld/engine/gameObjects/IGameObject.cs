using Microsoft.Xna.Framework;
using SampleWorld.engine.components;
using SampleWorld.engine.support;
using System.Collections.Generic;
namespace SampleWorld.engine.gameObjects
{
    interface IGameObject : IAdjustable
    {
        //获取父对象
        IGameObject GetParent();

        //获取子组件
        List<T> GetComponentList<T>() where T : ILocalComponent;

        //获取子组件
        T GetComponent<T>() where T : ILocalComponent;

        //获取父节点子组件
        List<T> GetParentComponentList<T>() where T : ILocalComponent;

        //获取父节点子组件
        T GetParentComponent<T>() where T : ILocalComponent;

        //获取所有父节点子组件
        List<T> GetParentsComponentList<T>() where T : ILocalComponent;

        //获取所有父节点子组件
        T GetParentsComponent<T>() where T : ILocalComponent;

        //添加组件
        void AddComponent<T>(T component) where T : ILocalComponent;

        void Destory();
    }
}
