using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcitonEditor
{
    /// <summary>EcitonEditorの要素に一意なIDを割り当てる処理を定義します。</summary>
    public static class EcitonElementIdProvider
    {
        private static object _provideIdLock = new object();
        //TODO: ファイル等でプログラム再起動時にもTotalIdを維持してほしい
        //というか単純インクリメントだと限度があるので、実際に使用されているIdを把握できるべき？実用的でない？
        private static int _totalId = 0;

        public static int ProvideUnusedId()
        {
            lock(_provideIdLock)
            {
                int result = _totalId;
                _totalId++;
                return result;
            }
        }

    }
}
