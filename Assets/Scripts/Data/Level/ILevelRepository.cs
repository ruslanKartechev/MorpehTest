using Game.Level.Impl;

namespace Data.Level
{
    public interface ILevelRepository
    {
        int CurrentLevelIndex { get; set; }
        int TotalLevelsPassed { get; set; }
        int NextLevel();
        int PrevLevel();
        int CorrectIndex(int index);
        LevelView GetPrefab(int index);
        int GetTotalCount();
    }
}