using System;

namespace Repository.Models
{
    [Flags]
    public enum EnumPlanos
    {
        UNIMED = 0,
        AMIL = 1, 
        SAUDE_SERVIDOR = 2,
        BRADESCO = 3,
        OUTROS = 4
    }
}