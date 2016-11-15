namespace Eciton
{
    public class EcitonWhileFunction : EcitonObject
    {
        public IEcitonIn<EcitonBool> Condition => _condition;
        public IEcitonIn<object> Proc => _proc;

        private readonly EcitonIn<EcitonBool> _condition = new EcitonIn<EcitonBool>();
        private readonly EcitonInWithDefault<object> _proc = new EcitonInWithDefault<object>(new EcitonIn<object>(), EcitonEmpty.Empty);

        public override object Eval()
        {
            object result = EcitonEmpty.Empty;
            while(_condition.Pull())
            {
                result = _proc.Pull();
            }
            return result;
        }
    }
}
