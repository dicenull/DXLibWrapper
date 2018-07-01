using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxLibUtilities
{
    public interface IScene
    {
        IScene Update();

        void Draw();
    }
}
