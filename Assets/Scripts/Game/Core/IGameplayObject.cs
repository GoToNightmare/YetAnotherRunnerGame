using Cysharp.Threading.Tasks;

namespace Game.Core
{
    public interface IGameplayObject
    {
        UniTask Init();


        UniTask CustomEnable();


        UniTask CustomDisable();


        void Reset();
    }
}