using System.Reflection;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace rox.mt4.rest
{
    public class SwagerTagFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // add responses swagger
            operation.Responses.Add("401", new OpenApiResponse
            {
                Description = "Unauthorized",
            });
            operation.Responses.Add("400", new OpenApiResponse
            {
                Description = "Client error",
                Headers = new Dictionary<string, OpenApiHeader>
                {
                    { "application/json", new OpenApiHeader() }
                }
            });

            operation.Tags.RemoveAt(0);
            operation.Tags.Add(Tag(context.MethodInfo));
        }
        public static OpenApiTag Tag(MethodInfo m)
        {
            var tag = new OpenApiTag();
            switch (m.Name)
            {
                case "ExposureGet": tag.Name = "Assets"; break;
                case "ExposureValueGet": tag.Name = "Assets"; break;
                case "ConnectionInfo": tag.Name = "Common"; break;
                case "ErrorDescription": tag.Name = "Common"; break;
                case "WorkingDirectory": tag.Name = "Common"; break;
                case "PumpingSwitch": tag.Name = "Common"; break;
                case "PumpingSwitchEx": tag.Name = "Common"; break;
                case "BytesSent": tag.Name = "Common"; break;
                case "BytesReceived": tag.Name = "Common"; break;
                case "LogsOut": tag.Name = "Common"; break;
                case "LogsMode": tag.Name = "Common"; break;
                case "LicenseCheck": tag.Name = "Common"; break;
                case "IsConnected": tag.Name = "Connect"; break;
                case "Login": tag.Name = "Connect"; break;
                case "LoginSecured": tag.Name = "Connect"; break;
                case "Logout": tag.Name = "Connect"; break;
                case "KeysSend": tag.Name = "Connect"; break;
                case "Ping": tag.Name = "Connect"; break;
                case "PasswordChange": tag.Name = "Connect"; break;
                case "ManagerRights": tag.Name = "Connect"; break;
                case "SrvFeeders": tag.Name = "DataSource"; break;
                case "SrvFeederLog": tag.Name = "DataSource"; break;
                case "SrvFeedsRestart": tag.Name = "DataSource"; break;
                case "DealerSwitch": tag.Name = "Deling"; break;
                case "DealerRequestGet": tag.Name = "Deling"; break;
                case "DealerSend": tag.Name = "Deling"; break;
                case "DealerReject": tag.Name = "Deling"; break;
                case "DealerReset": tag.Name = "Deling"; break;
                case "MailSend": tag.Name = "Notify"; break;
                case "MailsRequest": tag.Name = "Notify"; break;
                case "MailLast": tag.Name = "Notify"; break;
                case "NewsSend": tag.Name = "Notify"; break;
                case "NewsGet": tag.Name = "Notify"; break;
                case "NewsTotal": tag.Name = "Notify"; break;
                case "NewsTopicGet": tag.Name = "Notify"; break;
                case "NewsBodyRequest": tag.Name = "Notify"; break;
                case "NewsBodyGet": tag.Name = "Notify"; break;
                case "NotificationsSend": tag.Name = "Notify"; break;
                case "OnlineRequest": tag.Name = "OnlineConnection"; break;
                case "OnlineGet": tag.Name = "OnlineConnection"; break;
                case "OnlineRecordGet": tag.Name = "OnlineConnection"; break;
                case "ChartRequest": tag.Name = "PriceData"; break;
                case "ChartAdd": tag.Name = "PriceData"; break;
                case "ChartUpdate": tag.Name = "PriceData"; break;
                case "ChartDelete": tag.Name = "PriceData"; break;
                case "TicksRequest": tag.Name = "PriceData"; break;
                case "TickInfoLast": tag.Name = "PriceData"; break;
                case "HistoryCorrect": tag.Name = "PriceData"; break;
                case "ExternalCommand": tag.Name = "ProtocolExtensions"; break;
                case "ReportsRequest": tag.Name = "Reports"; break;
                case "DailyReportsRequest": tag.Name = "Reports"; break;
                case "DailySyncStart": tag.Name = "Reports"; break;
                case "DailySyncRead": tag.Name = "Reports"; break;
                case "BackupInfoUsers": tag.Name = "Reservations"; break;
                case "BackupInfoOrders": tag.Name = "Reservations"; break;
                case "BackupRequestUsers": tag.Name = "Reservations"; break;
                case "BackupRequestOrders": tag.Name = "Reservations"; break;
                case "BackupRestoreUsers": tag.Name = "Reservations"; break;
                case "BackupRestoreOrders": tag.Name = "Reservations"; break;
                case "SrvRestart": tag.Name = "ServerManagment"; break;
                case "SrvChartsSync": tag.Name = "ServerManagment"; break;
                case "SrvLiveUpdateStart": tag.Name = "ServerManagment"; break;
                case "PerformanceRequest": tag.Name = "ServerManagment"; break;
                case "JournalRequest": tag.Name = "ServerManagment"; break;
                case "ServerTime": tag.Name = "ServerManagment"; break;
                case "SummaryGet": tag.Name = "Summary"; break;
                case "SummaryGetAll": tag.Name = "Summary"; break;
                case "SummaryGetByCount": tag.Name = "Summary"; break;
                case "SummaryGetByType": tag.Name = "Summary"; break;
                case "SummaryCurrency": tag.Name = "Summary"; break;
                case "SymbolsRefresh": tag.Name = "Symbols"; break;
                case "SymbolsGetAll": tag.Name = "Symbols"; break;
                case "SymbolGet": tag.Name = "Symbols"; break;
                case "SymbolInfoGet": tag.Name = "Symbols"; break;
                case "SymbolInfoUpdated": tag.Name = "Symbols"; break;
                case "SymbolsGroupsGet": tag.Name = "Symbols"; break;
                case "SymbolAdd": tag.Name = "Symbols"; break;
                case "SymbolHide": tag.Name = "Symbols"; break;
                case "SymbolSendTick": tag.Name = "Symbols"; break;
                case "SymbolChange": tag.Name = "Symbols"; break;
                case "AdmUsersRequest": tag.Name = "Users"; break;
                case "AdmBalanceCheck": tag.Name = "Users"; break;
                case "AdmBalanceFix": tag.Name = "Users"; break;
                case "UsersRequest": tag.Name = "Users"; break;
                case "UserRecordsRequest": tag.Name = "Users"; break;
                case "UserRecordNew": tag.Name = "Users"; break;
                case "UserRecordsNew": tag.Name = "Users"; break;
                case "UserRecordUpdate": tag.Name = "Users"; break;
                case "UsersGroupOp": tag.Name = "Users"; break;
                case "UserPasswordCheck": tag.Name = "Users"; break;
                case "UserPasswordSet": tag.Name = "Users"; break;
                case "UsersGet": tag.Name = "Users"; break;
                case "UserRecordGet": tag.Name = "Users"; break;
                case "UsersSyncStart": tag.Name = "Users"; break;
                case "UsersSyncRead": tag.Name = "Users"; break;
                case "UsersSnapshot": tag.Name = "Users"; break;
                case "CfgRequestSymbol": tag.Name = "Characters"; break;
                case "CfgUpdateSymbol": tag.Name = "Characters"; break;
                case "CfgDeleteSymbol": tag.Name = "Characters"; break;
                case "CfgShiftSymbol": tag.Name = "Characters"; break;
                case "CfgRequestSymbolGroup": tag.Name = "Characters"; break;
                case "CfgUpdateSymbolGroup": tag.Name = "Characters"; break;
                case "CfgRequestDataServer": tag.Name = "DataServer"; break;
                case "CfgUpdateDataServer": tag.Name = "DataServer"; break;
                case "CfgDeleteDataServer": tag.Name = "DataServer"; break;
                case "CfgShiftDataServer": tag.Name = "DataServer"; break;
                case "CfgRequestFeeder": tag.Name = "DataSources"; break;
                case "CfgUpdateFeeder": tag.Name = "DataSources"; break;
                case "CfgDeleteFeeder": tag.Name = "DataSources"; break;
                case "CfgShiftFeeder": tag.Name = "DataSources"; break;
                case "CfgRequestAccess": tag.Name = "Firewall"; break;
                case "CfgUpdateAccess": tag.Name = "Firewall"; break;
                case "CfgDeleteAccess": tag.Name = "Firewall"; break;
                case "CfgShiftAccess": tag.Name = "Firewall"; break;
                case "CfgRequestGatewayAccount": tag.Name = "Gatway"; break;
                case "CfgUpdateGatewayAccount": tag.Name = "Gatway"; break;
                case "CfgDeleteGatewayAccount": tag.Name = "Gatway"; break;
                case "CfgShiftGatewayAccount": tag.Name = "Gatway"; break;
                case "CfgRequestGatewayMarkup": tag.Name = "Gatway"; break;
                case "CfgShiftGatewayMarkup": tag.Name = "Gatway"; break;
                case "CfgUpdateGatewayMarkup": tag.Name = "Gatway"; break;
                case "CfgDeleteGatewayMarkup": tag.Name = "Gatway"; break;
                case "CfgRequestGatewayRule": tag.Name = "Gatway"; break;
                case "CfgShiftGatewayRule": tag.Name = "Gatway"; break;
                case "CfgUpdateGatewayRule": tag.Name = "Gatway"; break;
                case "CfgDeleteGatewayRule": tag.Name = "Gatway"; break;
                case "CfgRequestGroup": tag.Name = "Group"; break;
                case "CfgUpdateGroup": tag.Name = "Group"; break;
                case "CfgDeleteGroup": tag.Name = "Group"; break;
                case "CfgShiftGroup": tag.Name = "Group"; break;
                case "GroupsRequest": tag.Name = "Group"; break;
                case "GroupsGet": tag.Name = "Group"; break;
                case "GroupRecordGet": tag.Name = "Group"; break;
                case "CfgRequestHoliday": tag.Name = "Holiday"; break;
                case "CfgUpdateHoliday": tag.Name = "Holiday"; break;
                case "CfgDeleteHoliday": tag.Name = "Holiday"; break;
                case "CfgShiftHoliday": tag.Name = "Holiday"; break;
                case "CfgRequestLiveUpdate": tag.Name = "LiveUpdate"; break;
                case "CfgUpdateLiveUpdate": tag.Name = "LiveUpdate"; break;
                case "CfgDeleteLiveUpdate": tag.Name = "LiveUpdate"; break;
                case "CfgShiftLiveUpdate": tag.Name = "LiveUpdate"; break;
                case "CfgRequestManager": tag.Name = "Manager"; break;
                case "CfgUpdateManager": tag.Name = "Manager"; break;
                case "CfgDeleteManager": tag.Name = "Manager"; break;
                case "CfgShiftManager": tag.Name = "Manager"; break;
                case "CfgRequestPlugin": tag.Name = "Plugin"; break;
                case "CfgUpdatePlugin": tag.Name = "Plugin"; break;
                case "CfgShiftPlugin": tag.Name = "Plugin"; break;
                case "PluginUpdate": tag.Name = "Plugin"; break;
                case "PluginsGet": tag.Name = "Plugin"; break;
                case "PluginParamGet": tag.Name = "Plugin"; break;
                case "CfgRequestBackup": tag.Name = "Redundancy"; break;
                case "CfgUpdateBackup": tag.Name = "Redundancy"; break;
                case "CfgRequestSync": tag.Name = "Sync"; break;
                case "CfgUpdateSync": tag.Name = "Sync"; break;
                case "CfgDeleteSync": tag.Name = "Sync"; break;
                case "CfgShiftSync": tag.Name = "Sync"; break;
                case "CfgRequestCommon": tag.Name = "SystemWide "; break;
                case "CfgUpdateCommon": tag.Name = "SystemWide "; break;
                case "ManagerCommon": tag.Name = "SystemWide "; break;
                case "CfgRequestTime": tag.Name = "Time"; break;
                case "CfgUpdateTime": tag.Name = "Time"; break;
                case "MarginsGet": tag.Name = "MarginStatus"; break;
                case "MarginLevelGet": tag.Name = "MarginStatus"; break;
                case "MarginLevelRequest": tag.Name = "MarginStatus"; break;
                case "AdmTradesRequest": tag.Name = "Orders"; break;
                case "AdmTradesDelete": tag.Name = "Orders"; break;
                case "AdmTradeRecordModify": tag.Name = "Orders"; break;
                case "TradeTransaction": tag.Name = "Orders"; break;
                case "TradesRequest": tag.Name = "Orders"; break;
                case "TradeRecordsRequest": tag.Name = "Orders"; break;
                case "TradesUserHistory": tag.Name = "Orders"; break;
                case "TradesGet": tag.Name = "Orders"; break;
                case "TradeRecordGet": tag.Name = "Orders"; break;
                case "TradesGetBySymbol": tag.Name = "Orders"; break;
                case "TradesGetByLogin": tag.Name = "Orders"; break;
                case "TradesGetByMarket": tag.Name = "Orders"; break;
                case "TradeClearRollback": tag.Name = "Orders"; break;
                case "TradeCheckStops": tag.Name = "Service"; break;
                case "TradeCalcProfit": tag.Name = "Service"; break;
                case "TradesSnapshot": tag.Name = "Service"; break;
                case "RequestsGet": tag.Name = "TradingRequests"; break;
                case "RequestInfoGet": tag.Name = "TradingRequests"; break;

                default: tag.Name = "Unknown"; break;
            }

            return tag;
        }
    }
}
