using System.Collections.Generic;
using Infrastructure.Services;
using Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
         GameObject CreateHero(GameObject initialPoint);
         List<ISavedProgressReader> ProgressReaders { get; }
         List<ISavedProgress> ProgressWriters { get; }
         void Cleanup();
    }
}