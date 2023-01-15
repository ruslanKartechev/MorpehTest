using Ecs.Components;
using Scellecs.Morpeh;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI.Impl
{
    public class PlayerHudUI : BaseUI, IPlayerHoodUI
    {
        [SerializeField] private Button _boostButton;
        [SerializeField] private TextMeshProUGUI _speedText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private TextMeshProUGUI _radText;
        [SerializeField] private TextMeshProUGUI _killCount;

        private Entity _playerEntity;
        
        public override void Show()
        {
            IsVisible = true;
        }

        public override void Hide()
        {
            IsVisible = false;
        }

        public void Init(Entity playerCharacter, Entity player)
        {
            _playerEntity = playerCharacter;
            ref var speedComp = ref _playerEntity.GetComponent<MoveSpeedComponent>();
            speedComp.Property.Subscribe(val =>
            {
                _speedText.text = $"Speed: {val}";
            });

            ref var rangeComp = ref _playerEntity.GetComponent<DamageRangeComponent>();
            rangeComp.Property.Subscribe(val =>
            {
                _radText.text = $"Range: {val}";
            });

            ref var damageComp = ref _playerEntity.GetComponent<DamageComponent>();
            damageComp.Property.Subscribe(val =>
            {
                _damageText.text = $"Damage: {val}";
            });

            ref var killComp = ref player.GetComponent<KillCountComponent>();
            killComp.Property.Subscribe(val =>
            {
                _killCount.text = $"Killed: {val}";
            });

            _boostButton.OnClickAsObservable().Subscribe(t =>
            {
                Debug.Log("boost button");
                _playerEntity.AddComponent<ApplyRandomBoostComponent>();
            });

        }
        
        
    }
}