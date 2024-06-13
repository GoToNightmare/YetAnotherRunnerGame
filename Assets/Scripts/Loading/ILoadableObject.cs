using Cysharp.Threading.Tasks;

namespace Loading
{
    public interface ILoadableObject
    {
        UniTask Load();
    }
}