using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcitonEditor
{
    /// <summary>EcitonEditorでノードとして配置される要素を表します。</summary>
    public class EcitonNode
    {
        /// <summary>グラフィック的にノード左端の位置を表します。</summary>
        public int X { get; set; }
        /// <summary>グラフィック的なノード上端の位置を表します。</summary>
        public int Y { get; set; }


    }
}
