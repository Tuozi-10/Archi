<<<<<<< HEAD
﻿using Service;

public interface ISceneService : IService
{
    public interface ISceneService : IService
    {
=======
namespace Service.SceneService
{
    public interface ISceneService : IService
    {
        void LoadScene(string key);
        void LoadScene(uint index);
    }
}
