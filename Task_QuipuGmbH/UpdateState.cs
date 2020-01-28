using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_QuipuGmbH
{
    public enum UpdateState
    {
        /// <summary>Ничего не делает</summary>
        None,

        /// <summary>Обновление запущено</summary>
        Started,

        /// <summary>Обновление успешно завершено</summary>
        Completed
    }
}
