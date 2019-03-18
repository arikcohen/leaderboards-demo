#if !DISABLE_PLAYFABENTITY_API
using PlayFab.CloudScriptModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<ExecuteEntityCloudScriptRequest> OnCloudScriptExecuteEntityCloudScriptRequestEvent;
        public event PlayFabResultEvent<ExecuteCloudScriptResult> OnCloudScriptExecuteEntityCloudScriptResultEvent;
        public event PlayFabRequestEvent<ExecuteFunctionRequest> OnCloudScriptExecuteFunctionRequestEvent;
        public event PlayFabResultEvent<ExecuteFunctionResult> OnCloudScriptExecuteFunctionResultEvent;
        public event PlayFabRequestEvent<GetArgumentsForExecuteFunctionRequest> OnCloudScriptGetArgumentsForExecuteFunctionRequestEvent;
        public event PlayFabResultEvent<GetArgumentsForExecuteFunctionResult> OnCloudScriptGetArgumentsForExecuteFunctionResultEvent;
        public event PlayFabRequestEvent<RegisterFunctionRequest> OnCloudScriptRegisterFunctionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptRegisterFunctionResultEvent;
    }
}
#endif
