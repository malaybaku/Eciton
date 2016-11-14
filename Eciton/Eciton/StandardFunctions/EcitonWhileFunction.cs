namespace Eciton
{
    public class EcitonWhileFunction : EcitonObject
    {
        public IEcitonIn<EcitonBool> Condition => _condition;
        public IEcitonIn<object> Proc => _proc;

        private readonly EcitonFuncArgument<EcitonBool> _condition = new EcitonFuncArgument<EcitonBool>();
        private readonly EcitonNullableIn<object> _proc = new EcitonNullableIn<object>(EcitonEmpty.Empty);

        public override object Eval()
        {
            object result = EcitonEmpty.Empty;
            while(_condition.PullArg())
            {
                result = _proc.GetValueOrDefault();
            }
            return result;
        }
    }
}
