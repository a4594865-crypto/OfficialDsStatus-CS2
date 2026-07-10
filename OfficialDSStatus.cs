using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using System.Linq; // 確保有引用 LINQ

namespace OfficialDSStatus
{
    public class OfficialDSStatus : BasePlugin
    {
        public override string ModuleName => "OfficialDSStatus";
        public override string ModuleAuthor => "E!N (Fixed by Optimized)";
        public override string ModuleVersion => "v1.2_Fix";

        [GameEventHandler]
        public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
        {
            // 【修復】使用 FirstOrDefault 避免空集合崩潰
            var proxy = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").FirstOrDefault();
            
            // 【修復】確認真的有找到實體，且 GameRules 不為 null 才執行
            if (proxy != null && proxy.GameRules != null)
            {
                proxy.GameRules.IsValveDS = true;
            }
            
            return HookResult.Continue;
        }
    }
}
