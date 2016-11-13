namespace Eciton
{
    public class EcitonBreak : EcitonObject
    {
        private EcitonBreak() { }

        private static readonly EcitonBreak _instance = new EcitonBreak();

        public static EcitonBreak Break => _instance;
        public override object Eval() => Break;
    }
}
