using System;
using Scellecs.Morpeh;
using UniRx;

namespace Ecs.Components
{
    public struct FloatReactiveComponent : IComponent, IReactiveProperty<float>
    {
        public float Val;
        
        public IDisposable Subscribe(IObserver<float> observer)
        {
           observer.OnNext(Val);
           return Disposable.Empty;
        }

        public float Value { get; set; }
        public bool HasValue { get; }
        
    }
}