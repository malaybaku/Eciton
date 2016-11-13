namespace Eciton
{
    public class EcitonEmpty : EcitonObject
    {
        private EcitonEmpty() { }

        private static readonly EcitonEmpty _instance = new EcitonEmpty();

        public static EcitonEmpty Empty => _instance;
        public override object Eval() => Empty;
    }
}
